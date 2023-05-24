using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;
using System.Windows.Forms;
using static Launcher.NewFolder.UIControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using Button = System.Windows.Forms.Button;
using NLog;

namespace Launcher.NewFolder//TODO:待改介面
{
    public class UIControl
    {
        public MainForm mainForm;

        FrontEndJudgment judgment = new FrontEndJudgment();

        public LoggerCrtl LoggerCrtl = new LoggerCrtl();

        //TIFFF tIFFF;
        public Dictionary<string, object> GameInfo = new Dictionary<string, object>();
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

            //tIFFF = new TIFFF(mainForm);

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
            }));
        }
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
            if (judgment.LoginVerification(mainForm.TrainingAccount_TB.Text, mainForm.TrainingPW_TB.Text).IsVerified)
            {
                SetText(mainForm.loginstate_lb, "登入 - - - - - - - - - - - - - - - -  ✔", Color.PaleGreen);

                LoggerCrtl.Sand(LoggerCrtl.Levels.info, $"用戶 {mainForm.TrainingAccount_TB.Text} 登入 : {DateTime.Now}");

                DelayLogin();
            }
        }
        async void DelayLogin()
        {
            await Task.Delay(1000); // TODO:替代為等待

            UImethod[PanelType.Login]();
        }
        /// <summary>
        /// 驗證
        /// </summary>
        public void Verify()
        {
            if (judgment.VerifyIdentity(mainForm.SerialNumber.Text))
            {
                UImethod[PanelType.Verfiy]();

                LoggerCrtl.Sand(LoggerCrtl.Levels.info,$"驗證通知 : {DateTime.Now}");
            }
        }
        /// <summary>
        /// 可執行軟體
        /// </summary>
        public void SpawnSoftware(string GameVersion, string GameName, string Detail)
        {
            try
            {
                GameData gameData = new GameData(GameVersion, GameName, Detail); //登入成功後拉本機DT (假設本機有DT)
                GameInfo.Add(gameData.getName, gameData);

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
            };
        }
        /// <summary>
        /// 路徑檢查
        /// </summary>
        public void CheckPath()
        {
            SetText(mainForm.mypath_tb, null, (Directory.Exists(mainForm.mypath_tb.Text)) ? Color.BurlyWood : Color.IndianRed);
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
