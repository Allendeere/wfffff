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
    public class TIF
    {
        //Launcher當前版本
        //string LauncherVersion = "0.0.0";

        public MainForm mainForm;

        TIFF tIFF = new TIFF();
        TIFFF tIFFF ;

        SystemInformationPage systemInformationpg;
        //可執行軟體字典
        public Dictionary<string, object> gameDT = new Dictionary<string, object>();

        public TIF(MainForm mainForm)
        {
            tIFF.OnlyOneProcess();

            this.mainForm = mainForm;
            mainForm._tiF = this;

            tIFFF = new TIFFF(mainForm);

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
                SpawnPage();

                mainForm.TrainingAccount_TB.Text = "";
                mainForm.TrainingPW_TB.Text = "";
                mainForm.SerialNumber.Text = "";
                mainForm.Login.Enabled = true;
                mainForm.Login_panel.Visible = false;
                mainForm.Login_panel.Enabled = false;
            }
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
            }
        }
        /// <summary>
        /// 登入成功後生成的子頁
        /// 【啟動器頁面】
        /// </summary>
        void SpawnPage()
        {
            systemInformationpg = SystemInformationPage.Create();

            mainForm.optionspanel.Size = new Size(195, 518);
            mainForm.LVersionlabel.Location = new Point(130, 403);
            mainForm.pictureBox3.Location = new Point(8, 350);
            mainForm.LoginP.Visible = true;
            mainForm.Title_LB.Text = "Name";
            #region 頁面生成
            systemInformationpg.SystemInformation = new TabPage();
            systemInformationpg.panel2 = new Panel();
            systemInformationpg.flowLayoutPanel1 = new FlowLayoutPanel();
            systemInformationpg.panel1 = new Panel();
            systemInformationpg.labellauncherv = new Label();
            systemInformationpg.GameName_Lb = new Label();
            systemInformationpg.Detail_Lb = new Label();
            systemInformationpg.LoadGame_Btn = new Button();
            systemInformationpg.SystemInformationpanel1 = new Panel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            systemInformationpg.SystemInformationpanel1.SuspendLayout();
            systemInformationpg.SystemInformation.SuspendLayout();
            systemInformationpg.panel1.SuspendLayout();

            mainForm.tabControl1.Controls.Add(systemInformationpg.SystemInformation);
            // 
            // LoadGame_Btn
            // 
            systemInformationpg.LoadGame_Btn.BackColor = Color.FromArgb(81, 81, 89);
            systemInformationpg.LoadGame_Btn.Location = new Point(0, 158);
            systemInformationpg.LoadGame_Btn.Name = "LoadGame_Btn";
            systemInformationpg.LoadGame_Btn.Size = new Size(188, 35);
            systemInformationpg.LoadGame_Btn.TabIndex = 14;
            systemInformationpg.LoadGame_Btn.FlatStyle = FlatStyle.Flat;
            systemInformationpg.LoadGame_Btn.FlatAppearance.BorderSize = 0;
            systemInformationpg.LoadGame_Btn.ForeColor = Color.White;
            systemInformationpg.LoadGame_Btn.Text = "啟動遊戲";
            systemInformationpg.LoadGame_Btn.UseVisualStyleBackColor = true;
            systemInformationpg.LoadGame_Btn.Visible = false;
            // 
            // SystemInformation
            // 
            var c = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            c = c.Substring(0, c.Length - 24) + "IMG\\";
            systemInformationpg.SystemInformation.BackgroundImage = Image.FromFile(c + "background4.jpg");
            systemInformationpg.SystemInformation.BackgroundImageLayout = ImageLayout.Stretch;
            systemInformationpg.SystemInformation.BackColor = Color.FromArgb(41, 41, 52);
            systemInformationpg.SystemInformation.Controls.Add(systemInformationpg.flowLayoutPanel1);
            systemInformationpg.SystemInformation.Controls.Add(systemInformationpg.panel1);
            systemInformationpg.SystemInformation.Controls.Add(systemInformationpg.panel2);
            systemInformationpg.SystemInformation.Controls.Add(systemInformationpg.SystemInformationpanel1);
            systemInformationpg.SystemInformation.Location = new Point(4, 44);
            systemInformationpg.SystemInformation.Name = "SystemInformation";
            systemInformationpg.SystemInformation.Text = "系統資訊";
            systemInformationpg.SystemInformation.Padding = new Padding(3);
            systemInformationpg.SystemInformation.Size = new Size(608, 389);
            systemInformationpg.SystemInformation.TabIndex = 1;
            // 
            // GameName_Lb
            // 
            systemInformationpg.GameName_Lb.AutoSize = true;
            systemInformationpg.GameName_Lb.Location = new Point(0, 28);
            systemInformationpg.GameName_Lb.ForeColor = Color.White;
            systemInformationpg.GameName_Lb.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            systemInformationpg.GameName_Lb.Name = "GameName_Lb";
            systemInformationpg.GameName_Lb.Size = new Size(42, 15);
            systemInformationpg.GameName_Lb.TabIndex = 13;
            systemInformationpg.GameName_Lb.Text = "Game Name";
            // 
            // INFO
            // 
            systemInformationpg.panel1.BackColor = Color.Transparent;
            systemInformationpg.panel1.Parent = systemInformationpg.SystemInformationpanel1;
            systemInformationpg.panel1.Controls.Add(systemInformationpg.LoadGame_Btn);
            systemInformationpg.panel1.Controls.Add(systemInformationpg.GameName_Lb);
            systemInformationpg.panel1.Controls.Add(systemInformationpg.Detail_Lb);
            systemInformationpg.panel1.Controls.Add(systemInformationpg.labellauncherv);
            systemInformationpg.panel1.Location = new Point(408, 104);
            systemInformationpg.panel1.Name = "panel1";
            systemInformationpg.panel1.Size = new Size(188, 193);
            systemInformationpg.panel1.TabIndex = 0;
            // 
            // GameImageBig
            // 
            //panel2.BackColor = Color.Gray;
            systemInformationpg.panel2.BackgroundImage = Image.FromFile(c + "background3.png");
            systemInformationpg.panel2.BackgroundImageLayout = ImageLayout.Stretch;
            systemInformationpg.panel2.Location = new Point(27, 54);
            systemInformationpg.panel2.Name = "panel2";
            systemInformationpg.panel2.Size = new Size(362, 246);
            systemInformationpg.panel2.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            systemInformationpg.flowLayoutPanel1.BackColor = Color.Transparent;
            systemInformationpg.flowLayoutPanel1.Parent = systemInformationpg.SystemInformationpanel1;
            systemInformationpg.flowLayoutPanel1.AutoScroll = true;
            systemInformationpg.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            systemInformationpg.flowLayoutPanel1.Location = new Point(27, 320);
            systemInformationpg.flowLayoutPanel1.Name = "flowLayoutPanel1";
            systemInformationpg.flowLayoutPanel1.Size = new Size(568, 100);
            systemInformationpg.flowLayoutPanel1.TabIndex = 1;

            //
            // labellauncherv  啟動器版本
            // 
            systemInformationpg.labellauncherv.AutoSize = true;
            systemInformationpg.labellauncherv.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            systemInformationpg.labellauncherv.ForeColor = SystemColors.ButtonHighlight;
            systemInformationpg.labellauncherv.Location = new Point(0, 0);
            systemInformationpg.labellauncherv.Name = "labellauncherv";
            systemInformationpg.labellauncherv.Size = new Size(42, 15);
            systemInformationpg.labellauncherv.TabIndex = 10;
            systemInformationpg.labellauncherv.Text = "啟動器版本 : " + tIFFF.localVersion.ToString();
            // 
            // Detail_Lb
            // 
            systemInformationpg.Detail_Lb.AutoSize = true;
            systemInformationpg.Detail_Lb.Location = new Point(0, 70);
            systemInformationpg.Detail_Lb.ForeColor = SystemColors.ButtonHighlight;
            systemInformationpg.Detail_Lb.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            systemInformationpg.Detail_Lb.Name = "Detail_Lb";
            systemInformationpg.Detail_Lb.Size = new Size(53, 0);
            systemInformationpg.Detail_Lb.TabIndex = 12;
            systemInformationpg.Detail_Lb.Text = "Detail";
            // 
            // SystemInformationpanel1
            // 
            systemInformationpg.SystemInformationpanel1.BackColor = Color.FromArgb(41, 41, 52);
            systemInformationpg.SystemInformationpanel1.BackgroundImage = Image.FromFile(c + "background4.jpg");
            systemInformationpg.SystemInformationpanel1.BackgroundImageLayout = ImageLayout.Stretch;
            systemInformationpg.SystemInformationpanel1.Controls.Add(systemInformationpg.panel1);
            systemInformationpg.SystemInformationpanel1.Location = new Point(-4, 2);
            systemInformationpg.SystemInformationpanel1.Name = "SystemInformationpanel1";
            systemInformationpg.SystemInformationpanel1.Size = new Size(627, 500);
            systemInformationpg.SystemInformationpanel1.TabIndex = 4;

            systemInformationpg.SystemInformation.ResumeLayout(false);
            systemInformationpg.panel1.ResumeLayout(false);
            systemInformationpg.panel1.PerformLayout();
            #endregion
            mainForm.tabControl1.TabPages["Loginsystem"].Text = "訓練帳號 : " + mainForm.TrainingAccount_TB.Text;
            mainForm.Login_panel.Visible = false;
            mainForm.Login.Text = "執行訓練";
            mainForm.User_panel.Visible = true;
            mainForm.Logout.Enabled = true;
        }
        /// <summary>
        /// 我的可執行軟體
        /// </summary>
        public void SpawnSoftware()
        {
            try
            {
                //遍俐 ----- V
                GameData gameData = new GameData("v1.0.0", "GameName_Test", "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。"); //登入成功後拉本機DT (假設本機有DT)
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

                systemInformationpg.flowLayoutPanel1.Controls.Add(pln);


                #endregion
                button.Click += (sender, e) =>
                {
                    systemInformationpg.Detail_Lb.Text = gameData.getDescribe;
                    systemInformationpg.GameName_Lb.Text = gameData.getName;

                    systemInformationpg.LoadGame_Btn.Visible = true;
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
            mainForm.pictureBox3.Location = new Point(27, 370);
            mainForm.LoginP.Visible = false;
            mainForm.Title_LB.Text = "Launcher";

            mainForm.tabControl1.TabPages["Loginsystem"].Text = "登入系統";
            mainForm.SeriaPanel.Enabled = true;
            mainForm.Login.Text = "驗證";
            mainForm.Logout.Enabled = false;
            mainForm.User_panel.Visible = false;
            mainForm.SeriaPanel.Visible = true;
            gameDT.Clear();

            if (systemInformationpg != null)
            {
                mainForm.tabControl1.Controls.Remove(systemInformationpg.SystemInformation);
                systemInformationpg = null;
            }
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
