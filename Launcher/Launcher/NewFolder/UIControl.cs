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

namespace Launcher.NewFolder//TODO:待改介面
{
    public class UIControl
    {

        public MainForm mainForm;

        TIFF tIFF = new TIFF();
        TIFFF tIFFF;

        //可執行軟體字典
        public Dictionary<string, object> gameDT = new Dictionary<string, object>();

        public enum PanelType
        {
            Login,
            Verfiy,
            Main
        }

        private Dictionary<PanelType, Panel> panels = new Dictionary<PanelType, Panel>();

        public UIControl(MainForm mainForm)
        {
            tIFF.OnlyOneProcess();

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
            mainForm.Login.FlatAppearance.BorderSize = 0;
        }
        /// <summary>
        /// 登入
        /// </summary>
        public void Login()
        {
            if (tIFF.LoginVerification(mainForm.TrainingAccount_TB.Text, mainForm.TrainingPW_TB.Text).IsVerified)
            {
                mainForm.loginstate_lb.ForeColor = Color.PaleGreen;
                mainForm.loginstate_lb.Text = "登入 - - - - - - - - - - - - - - - -  ✔";

                DelayLogin();

            }
        }
        async void DelayLogin()
        {
            await Task.Delay(1000); // TODO:替代為等待家仔完成

            SpawnPage();

            mainForm.TrainingAccount_TB.Text = "";
            mainForm.TrainingPW_TB.Text = "";
            mainForm.SerialNumber.Text = "";
            mainForm.Login.Enabled = false;
            mainForm.Login_panel.Visible = false;
            mainForm.Login_panel.Enabled = false;
            mainForm.verify_pn.Visible = false;
            mainForm.verify_pn.Enabled = false;
        }


        /// <summary>
        /// 驗證
        /// </summary>
        public void Verify()
        {
            if (tIFF.VerifyIdentity(mainForm.SerialNumber.Text))
            {
                mainForm.Login.Text = "登入";
                mainForm.Login.Enabled = false;
                mainForm.SeriaPanel.Enabled = false;
                mainForm.SeriaPanel.Visible = false;
                mainForm.Login_panel.Visible = true;
                mainForm.Login_panel.Enabled = true;
                mainForm.uuidverify_lb.ForeColor = Color.PaleGreen;
                mainForm.uuidverify_lb.Text = "驗證 - - - - - - - - - - - - - - - -  ✔";


            }
        }

        public void SetActivePanel(PanelType panelType, bool isActive)
        {
            if (panels.ContainsKey(panelType))
            {
                panels[panelType].Visible = isActive;
            }
        }

        /// <summary>
        /// 登入成功後生成的子頁
        /// 【啟動器頁面】
        /// </summary>
        void SpawnPage()
        {
            mainForm.optionspanel.Size = new Size(195, 518);
            mainForm.LVersionlabel.Location = new Point(130, 403);
            mainForm.LoginP.Visible = true;
            mainForm.Title_LB.Text = "Welcome !\n\r" + mainForm.TrainingAccount_TB.Text;
            mainForm.Title_LB.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);


            //mainForm.tabControl1.TabPages["Loginsystem"].Text = "訓練帳號 : " + mainForm.TrainingAccount_TB.Text;
            mainForm.Login_panel.Visible = false;
            mainForm.Login.Text = "執行訓練";
            mainForm.User_panel.Visible = true;
            mainForm.Logout.Enabled = true;

        }
        /// <summary>
        /// 我的可執行軟體
        /// </summary>
        public void SpawnSoftware(string GameName_Test)
        {
            try
            {
                //遍俐 ----- V
                GameData gameData = new GameData("v1.0.0", GameName_Test, "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。"); //登入成功後拉本機DT (假設本機有DT)
                gameDT.Add(gameData.getName, gameData);

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
                button.Click += (sender, e) =>
                {
                    mainForm.Detail_Lb.Text = gameData.getDescribe;
                    mainForm.GameName_Lb.Text = gameData.getName;
                    mainForm.LoadGame_Btn.Visible = true;
                };
            }
            catch (Exception)
            {
                //資料重複或異常
            }

        }
        /// <summary>
        /// 登出
        /// </summary>
        public void Logout()
        {
            mainForm.optionspanel.Size = new Size(276, 452);
            mainForm.LVersionlabel.Location = new Point(223, 403);
            mainForm.LoginP.Visible = false;
            mainForm.Title_LB.Text = "Launcher";
            mainForm.Title_LB.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);


            mainForm.tabControl1.TabPages["Loginsystem"].Text = "登入系統";
            mainForm.SeriaPanel.Enabled = true;
            mainForm.Login.Text = "驗證";
            mainForm.Logout.Enabled = false;
            mainForm.User_panel.Visible = false;
            mainForm.SeriaPanel.Visible = true;

            mainForm.verify_pn.Visible = true;
            mainForm.verify_pn.Enabled = true;

            mainForm.uuidverify_lb.ForeColor = Color.Gray;
            mainForm.uuidverify_lb.Text = "驗證 - - - - - - - - - - - - - - - -  ✘";
            mainForm.loginstate_lb.ForeColor = Color.Gray;
            mainForm.loginstate_lb.Text = "登入 - - - - - - - - - - - - - - - -  ✘";

            gameDT.Clear();

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


        // --------以下須被分割-------------------------------------------------------------------





    }
}
