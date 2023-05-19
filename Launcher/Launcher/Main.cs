using Launcher.NewFolder;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Microsoft.VisualBasic.Logging;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Launcher.Properties;
using static System.Windows.Forms.DataFormats;
using System.Reflection;

namespace Launcher
{
    public partial class MainForm : Form
    {
        //Server方面
        public readonly IServerSerice _serverSerice;
        //功能集
        public TIF _tiF;
        //通用字典
        Dictionary<string, object> gameDT = new Dictionary<string, object>();
        //當登入成功時存入生成遊戲物件的方法
        Action setup;
        Action logout;
        //Launcher當前版本
        string LauncherVersion = "0.0.0";
        public MainForm()
        {
            this.Text += $"   v {LauncherVersion}";
            _tiF = new TIF(this);
            InitializeComponent();

        }

        private void Forgotpassword_Click(object sender, EventArgs e)
        {
            ForgetPasswordForm forgetPasswordForm = new ForgetPasswordForm();
            forgetPasswordForm.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            switch (Login.Text)
            {
                //UI CTRL : 登入
                case "登入":
                    if (_tiF.LoginVerification(TrainingAccount_TB.Text, TrainingPW_TB.Text).IsVerified)
                    {
                        SetPage();

                        TrainingAccount_TB.Text = "";
                        TrainingPW_TB.Text = "";
                        SerialNumber.Text = "";
                        Login.Enabled = true;
                        Login_panel.Visible = false;
                        Login_panel.Enabled = false;
                    }
                    break;

                //UI CTRL : 驗證
                case "驗證":
                    if (_tiF.VerifyIdentity(SerialNumber.Text))
                    {
                        Login.Text = "登入";
                        Login.Enabled = false;
                        SeriaPanel.Enabled = false;
                        SeriaPanel.Visible = false;
                        Login_panel.Visible = true;
                        Login_panel.Enabled = true;
                    }

                    break;

                case "執行訓練":
                    break;
            }
        }

        void SetPage()
        {
            optionspanel.Size = new Size(240, 518);
            LVersionlabel.Location = new Point(190, 453);
            pictureBox3.Location = new Point(50, 395);
            #region 頁面生成
            TabPage SystemInformation = new TabPage();
            Panel panel2 = new Panel();
            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
            Panel panel1 = new Panel();
            Label labellauncherv = new Label();
            Label GameName_Lb = new Label();
            Label Detail_Lb = new Label();
            Button LoadGame_Btn = new Button();
            Panel SystemInformationpanel1 = new Panel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SystemInformationpanel1.SuspendLayout();
            SystemInformation.SuspendLayout();
            panel1.SuspendLayout();

            tabControl1.Controls.Add(SystemInformation);
            // 
            // LoadGame_Btn
            // 
            LoadGame_Btn.Location = new Point(0, 158);
            LoadGame_Btn.Name = "LoadGame_Btn";
            LoadGame_Btn.Size = new Size(188, 35);
            LoadGame_Btn.TabIndex = 14;
            LoadGame_Btn.Text = "啟動遊戲";
            LoadGame_Btn.UseVisualStyleBackColor = true;
            LoadGame_Btn.Visible = false;
            // 
            // SystemInformation
            // 
            var c = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            c = c.Substring(0, c.Length - 24) + "IMG\\background2.jpg";
            SystemInformation.BackgroundImage = Image.FromFile(c);
            SystemInformation.BackgroundImageLayout = ImageLayout.Stretch;
            SystemInformation.BackColor = Color.FromArgb(41, 41, 52); //TODO底條
            SystemInformation.Controls.Add(flowLayoutPanel1);
            SystemInformation.Controls.Add(panel1);
            SystemInformation.Controls.Add(panel2);
            SystemInformation.Controls.Add(SystemInformationpanel1);
            SystemInformation.Location = new Point(4, 44);
            SystemInformation.Name = "SystemInformation";
            SystemInformation.Text = "系統資訊";
            SystemInformation.Padding = new Padding(3);
            SystemInformation.Size = new Size(608, 389);
            SystemInformation.TabIndex = 1;
            // 
            // GameName_Lb
            // 
            GameName_Lb.AutoSize = true;
            GameName_Lb.Location = new Point(0, 28);
            GameName_Lb.ForeColor = Color.White;
            GameName_Lb.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GameName_Lb.Name = "GameName_Lb";
            GameName_Lb.Size = new Size(42, 15);
            GameName_Lb.TabIndex = 13;
            GameName_Lb.Text = "Game Name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Location = new Point(27, 52);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 193);
            panel2.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Parent = SystemInformationpanel1;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(27, 284);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(568, 100);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Parent = SystemInformationpanel1;
            panel1.Controls.Add(LoadGame_Btn);
            panel1.Controls.Add(GameName_Lb);
            panel1.Controls.Add(Detail_Lb);
            panel1.Controls.Add(labellauncherv);
            panel1.Location = new Point(408, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(188, 193);
            panel1.TabIndex = 0;
            //
            // labellauncherv
            // 
            labellauncherv.AutoSize = true;
            labellauncherv.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labellauncherv.ForeColor = SystemColors.ButtonHighlight;
            labellauncherv.Location = new Point(0, 0);
            labellauncherv.Name = "labellauncherv";
            labellauncherv.Size = new Size(42, 15);
            labellauncherv.TabIndex = 10;
            labellauncherv.Text = "啟動器版本 : " + LauncherVersion;
            // 
            // Detail_Lb
            // 
            Detail_Lb.AutoSize = true;
            Detail_Lb.Location = new Point(0, 60);
            Detail_Lb.ForeColor = SystemColors.ButtonHighlight;
            Detail_Lb.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Detail_Lb.Name = "Detail_Lb";
            Detail_Lb.Size = new Size(53, 0);
            Detail_Lb.TabIndex = 12;
            Detail_Lb.Text = "Detail";
            // 
            // SystemInformationpanel1
            // 
            SystemInformationpanel1.BackColor = Color.FromArgb(41, 41, 52);//TODO fhfhfhf
            SystemInformationpanel1.BackgroundImage = Image.FromFile(c);
            SystemInformationpanel1.BackgroundImageLayout = ImageLayout.Stretch;
            SystemInformationpanel1.Controls.Add(panel1);
            SystemInformationpanel1.Location = new Point(-4, 2);
            SystemInformationpanel1.Name = "SystemInformationpanel1";
            SystemInformationpanel1.Size = new Size(627, 361);
            SystemInformationpanel1.TabIndex = 4;

            SystemInformation.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            #endregion

            tabControl1.TabPages["Loginsystem"].Text = "訓練帳號 : " + TrainingAccount_TB.Text;
            Login_panel.Visible = false;
            Login.Text = "執行訓練";
            User_panel.Visible = true;
            Logout.Enabled = true;

            tabControl1.SelectedIndex = 1;


            //連接 【測試用 : 生成遊戲物件】
            setup = () =>
            {
                try
                {
                    //遍俐 ----- V
                    GameData gameData = new GameData("v1.0.0", Test_Gamename.Text, "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。"); //登入成功後拉本機DT (假設本機有DT)
                    gameDT.Add(gameData.getName, gameData);

                    //檢查是否需要更新(測試)
                    _tiF.UpdateCheck(gameData, Test_NeedUpdate.Checked);
                    //檢查是否需要更新(正式)
                    //_tiF.UpdateCheck(gameData);

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

                    flowLayoutPanel1.Controls.Add(pln);


                    #endregion
                    button.Click += (sender, e) =>
                    {
                        Detail_Lb.Text = gameData.getDescribe;
                        GameName_Lb.Text = gameData.getName;

                        LoadGame_Btn.Visible = true;
                    };
                }
                catch (Exception)
                {
                    //資料重複或異常
                }

            };
            logout = () =>
            {
                optionspanel.Size = new Size(335, 518);
                LVersionlabel.Location = new Point(286, 453);
                pictureBox3.Location = new Point(90, 420);

                tabControl1.TabPages["Loginsystem"].Text = "登入系統";
                SeriaPanel.Enabled = true;
                Login.Text = "驗證";
                Logout.Enabled = false;
                User_panel.Visible = false;
                SeriaPanel.Visible = true;
                tabControl1.Controls.Remove(SystemInformation);
                gameDT.Clear();
            };
        }//TODO : +啟動器版本檢查

        #region UI 

        private void SerialNumber_TextChanged(object sender, EventArgs e)
        {
            Login.Enabled = (SerialNumber.Text.Length > 1);
        }

        private void TrainingPW_TB_TextChanged(object sender, EventArgs e)
        {
            Login.Enabled = (TrainingAccount_TB.Text.Length > 1 && TrainingPW_TB.Text.Length > 1);
        }

        private void TrainingAccount_TB_TextChanged(object sender, EventArgs e)
        {
            Login.Enabled = (TrainingAccount_TB.Text.Length > 1 && TrainingPW_TB.Text.Length > 1);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            logout();
        }
        #endregion


        #region 測試區

        private void TEST_FakeUpdate_Click(object sender, EventArgs e)
        {
            foreach (object key in gameDT.Values)
            {
                try
                {
                    if (key is GameData gt) //搜尋遊戲名程
                    {
                        if (gt.NeedUpdates)//是否需要更新
                            MessageBox.Show($"偵測到一筆新的新版本，是否進行更新 \n\r遊戲名稱:{gt.getName} \n\r當前版本:{gt.getVersion} \n\r最新版本:9.9.9 ", "更新提示", MessageBoxButtons.YesNoCancel);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("目前沒有可更新的遊戲");
                }
            }
        }

        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e) //TODO : 移至功能集
        {
            setup();
        }

        #endregion


        private void AccountManagement_Click(object sender, EventArgs e)
        {

        }
    }
}