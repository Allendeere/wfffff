using System.Diagnostics;
using Button = System.Windows.Forms.Button;

namespace Launcher.NewFolder//TODO:待改介面
{
    public class UIControl
    {
        public MainForm mainForm;

        public FrontEndJudgment judgment = new FrontEndJudgment();

        public LoggerCrtl LoggerCrtl;

        public UpdateRelated updateRelated;

        //TIFFF tIFFF;
        public Dictionary<string, object> GameInfo = new Dictionary<string, object>();

        public bool PathLock;
        public enum PanelType
        {
            Login,
            Verfiy,
            Logout
        }

        private Dictionary<PanelType, Action> UImethod = new Dictionary<PanelType, Action>();

        public UIControl(MainForm mainForm)
        {
            judgment.OnlyOneProcess();

            this.mainForm = mainForm;
            mainForm.uictrl = this;
            LoggerCrtl = new LoggerCrtl(this);


            updateRelated = new UpdateRelated(mainForm);

            UI_Initialization();
        }
        /// <summary>
        /// UI初始
        /// </summary>
        void UI_Initialization()
        {
            mainForm.Login_panel.Parent = mainForm.pictureBox_background;
            mainForm.SeriaPanel.Parent = mainForm.pictureBox_background;

            UImethod.Add(PanelType.Login, new Action(() =>
            {
                mainForm.optionspanel.Size = new Size(195, 518);
                mainForm.LVersionlabel.Location = new Point(130, 403);
                SetActivePanel(mainForm.Login, false, false);
                SetText(mainForm.Title_LB, "Welcome !\n\r" + mainForm.TrainingAccount_TB.Text, null, null, null, new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point));
                SetActivePanel(mainForm.Login_panel, false, false);
                SetActivePanel(mainForm.LoginP, true, true);
                SetActivePanel(mainForm.Logout, true, true);
                SetActivePanel(mainForm.User_panel, true, true);
                SetText(mainForm.TrainingAccount_TB, "");
                SetText(mainForm.TrainingPW_TB, "");
                SetText(mainForm.SerialNumber, "");
                SetActivePanel(mainForm.Login, false);
                SetActivePanel(mainForm.Login_panel, false, false);
                SetActivePanel(mainForm.verify_pn, false, false);
            }));
            UImethod.Add(PanelType.Verfiy, new Action(() =>
            {
                SetActivePanel(mainForm.authentication_btn, false, false);
                SetActivePanel(mainForm.Login, false, true);
                SetText(mainForm.uuidverify_lb, "驗證 - - - - - - - - - - - - - - - -  ✔", Color.PaleGreen);
                SetActivePanel(mainForm.SeriaPanel);
                SetActivePanel(mainForm.Login_panel, true, true);
                SetActivePanel(mainForm.uuidverify_lb);
            }));
            UImethod.Add(PanelType.Logout, new Action(() =>
            {
                SetActivePanel(mainForm.authentication_btn, false, true);
                mainForm.optionspanel.Size = new Size(276, 452);
                mainForm.LVersionlabel.Location = new Point(223, 403);

                SetText(mainForm.loginstate_lb, "登入 - - - - - - - - - - - - - - - -  ✘", Color.Gray);
                SetText(mainForm.uuidverify_lb, "驗證 - - - - - - - - - - - - - - - -  ✘", Color.Gray);
                SetText(mainForm.Title_LB, "Launcher", null, null, null, new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point));
                SetActivePanel(mainForm.LoginP, false, false);
                SetActivePanel(mainForm.SeriaPanel, true, true);
                SetActivePanel(mainForm.User_panel, false, false);
                SetActivePanel(mainForm.Logout, false, false);
                SetActivePanel(mainForm.verify_pn, true, true);
                SetActivePanel(mainForm.accountmangement_btn, false, false);

            }));
        }
        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            updateRelated.CheckForUpdates(false);
        }

        /// <summary>
        /// 選擇路徑
        /// </summary>
        public void FindPath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "選擇資料夾";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mainForm.mypath_tb.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// 登入
        /// </summary>
        public void Login()
        {
            if (PathLock)
            {
                if (MessageBox.Show("你所設定的路徑不存在 \n\r"+mainForm.mypath_tb.Text +"\n\r 是否還原預設路徑", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    mainForm.mypath_tb.Text = Properties.Settings.Default.localFilePath;

                    PathLock = false;
                }
                else
                {
                    return;
                }
            }

            var loginResult = judgment.LoginVerification(mainForm.TrainingAccount_TB.Text, mainForm.TrainingPW_TB.Text);

            if (loginResult.IsVerified)
            {
                SetText(mainForm.loginstate_lb, "登入 - - - - - - - - - - - - - - - -  ✔", Color.PaleGreen);

                LoggerCrtl.Sand(LoggerCrtl.Levels.info, $"{((loginResult.IsAdmin) ? "管理員" : "用戶")} {mainForm.TrainingAccount_TB.Text} 登入 : {DateTime.Now}");
                
                DelayLogin(loginResult.IsAdmin);// TODO:登入中模擬..
            }
        }
        async void DelayLogin(bool isAdmin)
        {
            await Task.Delay(1000); 

            UImethod[PanelType.Login]();

            foreach (var gminfo in GameInfo)
            {
                SpawnSoftware(gminfo.Key);
            }

            if (isAdmin)
            {
                SetActivePanel(mainForm.accountmangement_btn, true, true);
            }

        }
        /// <summary>
        /// 驗證
        /// </summary>
        public void Verify()
        {

            if (judgment.VerifyIdentity(mainForm.SerialNumber.Text))
            {
                UImethod[PanelType.Verfiy]();

                LoggerCrtl.Sand(LoggerCrtl.Levels.info, $"驗證通知 : {DateTime.Now}");
            }
        }
        /// <summary>
        /// 可執行軟體
        /// </summary>
        public void SpawnSoftware( string GameName)
        {
            try
            {
                var gamedt = GameInfo[GameName];
                if(gamedt is GameData gameData)//登入成功後拉本機遊戲資料 (假設本機有遊戲資料)
                {

                #region UI: 創建按鈕
                Panel pln = new Panel();
                Label labelgamev = new Label();
                Label labelgamename = new Label();
                Panel G2img = new Panel();
                System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                pln.Size = new Size(185, 76);
                //
                // labelgamename
                //
                labelgamename.BackColor = Color.FromArgb(57, 56, 84);
                labelgamename.Text = gameData.getName;
                labelgamename.AutoSize = true;
                labelgamename.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                labelgamename.ForeColor = Color.White;
                labelgamename.Location = new Point(83, 11);
                labelgamename.Size = new Size(55, 15);
                //
                // labelgamev
                //
                labelgamev.Text = gameData.getVersion;
                labelgamev.BackColor = Color.FromArgb(57, 56, 84);
                labelgamev.AutoSize = true;
                labelgamev.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                labelgamev.ForeColor = Color.FromArgb(78, 78, 99);
                labelgamev.Location = new Point(88, 28);
                labelgamev.Size = new Size(40, 15);
                //
                // Button
                //
                button.FlatStyle = FlatStyle.Flat;
                button.ForeColor = Color.FromArgb(57, 56, 84);
                button.BackColor = Color.FromArgb(57, 56, 84);
                button.Size = new Size(185, 76);
                button.FlatAppearance.BorderSize = 0;
                // 
                // G2img
                // 
                G2img.BackColor = Color.White;
                G2img.Location = new Point(0, 0);
                G2img.Size = new Size(77, 76);
                G2img.BorderStyle = BorderStyle.None;

                pln.Controls.Add(G2img);
                pln.Controls.Add(labelgamev);
                pln.Controls.Add(labelgamename);
                pln.Controls.Add(button);

                mainForm.flowLayoutPanel1.Controls.Add(pln);
                #endregion

                ButtonMethod(button, gameData);
                }
            }
            catch (Exception)
            {
                //資料重複或異常
            }
        }

        void ButtonMethod(Button button, GameData gameData)
        {
            button.Click += (sender, e) =>
            {
                SetText(mainForm.Detail_Lb, gameData.getDescribe);
                SetText(mainForm.GameName_Lb, gameData.getName);
                SetActivePanel(mainForm.LoadGame_Btn, true, true);


                mainForm.action =()=> judgment.ChecklocalGame(gameData.getName);

            };
        }
        /// <summary>
        /// 設定自動更新
        /// </summary>
        public void AutoUpdateSetting()
        {
            Properties.Settings.Default.AutoUpdate = mainForm.AutoUpdate_btn.Checked;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 路徑檢查
        /// </summary>
        public void CheckPath()
        {
            SetText(mainForm.mypath_tb, null, (Directory.Exists(mainForm.mypath_tb.Text)) ? Color.BurlyWood : Color.IndianRed);

            var l = Directory.Exists(mainForm.mypath_tb.Text);

            PathLock = !l;

            if (l)
            {
                Properties.Settings.Default.localFilePath = mainForm.mypath_tb.Text;
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            GameInfo.Clear();
            UImethod[PanelType.Logout]();
        }
        /// <summary>
        /// 切換頁面
        /// </summary>
        /// <param name="page"></param>
        public void PageSwitch(short page)
        {
            switch (page)
            {
                case 0:
                    mainForm.tabControl1.SelectedIndex = 0;
                    break;
                case 1:
                    mainForm.tabControl1.SelectedIndex = 1;
                    break;
            }
        }
        /// <summary>
        /// 忘記密碼
        /// </summary>
        public void ForgetPW()
        {
            ForgetPasswordForm forgetPasswordForm = new ForgetPasswordForm();
            forgetPasswordForm.Show();
        }
        public void SetActivePanel(object objects, bool? isActive = null, bool? isVisible = null)
        {
            if (objects is Control obj)
            {
                if (isActive != null) obj.Enabled = (bool)isActive;
                if (isVisible != null) obj.Visible = (bool)isVisible;
            }
        }
        public void SetText(object objects, string? title = null, Color? color = null, bool? isActive = null, bool? isVisible = null, Font? font = null)
        {
            if (objects is Control obj)
            {
                if (isActive != null) obj.Enabled = (bool)isActive;
                if (isVisible != null) obj.Visible = (bool)isVisible;
                if (title != null) obj.Text = title;
                if (color != null) obj.ForeColor = (Color)color;
                if (font != null) obj.Font = (Font)font;
            }
        }
    }
}
