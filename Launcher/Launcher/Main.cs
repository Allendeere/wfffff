﻿using Launcher.NewFolder;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

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

        public MainForm()
        {
            InitializeComponent();
            _tiF = new TIF(this);
        }

        private void Forgotpassword_Click(object sender, EventArgs e)
        {
            string emailInput = Microsoft.VisualBasic.Interaction.InputBox("输入申請信箱並找回密碼", "忘記密碼", "");

            MessageBox.Show(new Regex("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$").IsMatch(emailInput) ? "字符串符合电子邮件格式" : "X");
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //UI CTRL : 登入
            if (Login.Text == "登入")
                if (_tiF.LoginVerification(TrainingAccount_TB.Text, TrainingPW_TB.Text).IsVerified)
                {
                    tabControl1.SelectedIndex = 1;
                    tk();
                }


            //UI CTRL : 驗證
            if (_tiF.VerifyIdentity(SerialNumber.Text))
            {
                Login.Text = "登入";
                SeriaPanel.Visible = false;
            }
        }

        void tk()
        {
            TabPage SystemInformation = new TabPage();
            Panel panel2 = new Panel();
            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
            Panel panel1 = new Panel();
            Label label4 = new Label();
            Label Version_Lb = new Label();
            Label GameName_Lb = new Label();
            Label Detail_Lb = new Label();
            Button LoadGame_Btn = new Button();
            Button canUpdate_Btn = new Button();
            SystemInformation.SuspendLayout();
            panel1.SuspendLayout();

            tabControl1.Controls.Add(SystemInformation);

            // 
            // LoadGame_Btn
            // 
            LoadGame_Btn.Location = new Point(39, 292);
            LoadGame_Btn.Name = "LoadGame_Btn";
            LoadGame_Btn.Size = new Size(135, 39);
            LoadGame_Btn.TabIndex = 15;
            LoadGame_Btn.Text = "啟動遊戲";
            LoadGame_Btn.UseVisualStyleBackColor = true;
            LoadGame_Btn.Visible = false;
            // 
            // canUpdate_Btn
            // 
            canUpdate_Btn.Enabled = false;
            canUpdate_Btn.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            canUpdate_Btn.Location = new Point(180, 292);
            canUpdate_Btn.Name = "canUpdate_Btn";
            canUpdate_Btn.Size = new Size(75, 39);
            canUpdate_Btn.TabIndex = 14;
            canUpdate_Btn.Text = "可更新";
            canUpdate_Btn.UseVisualStyleBackColor = true;
            canUpdate_Btn.Visible = false;

            // 
            // SystemInformation
            // 
            SystemInformation.BackColor = Color.Transparent;
            SystemInformation.Controls.Add(flowLayoutPanel1);
            SystemInformation.Controls.Add(panel1);
            SystemInformation.Controls.Add(panel2);
            SystemInformation.Location = new Point(4, 44);
            SystemInformation.Name = "SystemInformation";
            SystemInformation.Padding = new Padding(3);
            SystemInformation.Size = new Size(768, 340);
            SystemInformation.TabIndex = 1;
            SystemInformation.Text = "系統資訊";
            // 
            // GameName_Lb
            // 
            GameName_Lb.AutoSize = true;
            GameName_Lb.Location = new Point(12, 47);
            GameName_Lb.Name = "GameName_Lb";
            GameName_Lb.Size = new Size(54, 20);
            GameName_Lb.TabIndex = 13;
            GameName_Lb.Text = "label5";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(436, 337);
            panel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.GradientInactiveCaption;
            flowLayoutPanel1.Location = new Point(43, 37);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(356, 281);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Bisque;
            panel1.Controls.Add(LoadGame_Btn);
            panel1.Controls.Add(canUpdate_Btn);
            panel1.Controls.Add(GameName_Lb);
            panel1.Controls.Add(Detail_Lb);
            panel1.Controls.Add(Version_Lb);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(475, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 337);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 10);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 10;
            label4.Text = "啟動器版本 :";
            // 
            // Version_Lb
            // 
            Version_Lb.AutoSize = true;
            Version_Lb.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Version_Lb.Location = new Point(111, 10);
            Version_Lb.Name = "Version_Lb";
            Version_Lb.Size = new Size(19, 20);
            Version_Lb.TabIndex = 11;
            Version_Lb.Text = "X";
            // 
            // Detail_Lb
            // 
            Detail_Lb.AutoSize = true;
            Detail_Lb.Location = new Point(12, 81);
            Detail_Lb.Name = "Detail_Lb";
            Detail_Lb.Size = new Size(53, 20);
            Detail_Lb.TabIndex = 12;
            Detail_Lb.Text = "Detail";


            SystemInformation.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
        }
        #region 測試區

        private void TEST_FakeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gameDT[Test_Gamename.Text] is GameData gt) //搜尋遊戲名程
                {
                    if (!gt.NeedUpdates)//是否需要更新
                        return;
                    MessageBox.Show($"偵測到一筆新的新版本，是否進行更新 \n\r遊戲名稱:{gt.getName} \n\r當前版本:{gt.getVersion} \n\r最新版本:9.9.9 ", "更新提示", MessageBoxButtons.YesNoCancel);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("目前沒有可更新的遊戲");
            }
        }

        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e) //TODO : 移至功能集
        {

            try
            {
                //遍俐 ----- V
                GameData gameData = new GameData("1.0.0", Test_Gamename.Text, "....."); //登入成功後拉本機DT (假設本機有DT)
                gameDT.Add(gameData.getName, gameData);

                //檢查是否需要更新(測試)
                _tiF.UpdateCheck(gameData, Test_NeedUpdate.Checked);
                //檢查是否需要更新(正式)
                //_tiF.UpdateCheck(gameData);

                //顯示在UI上
                // 創建按鈕
                Panel pln = new Panel();
                System.Windows.Forms.Button button = new System.Windows.Forms.Button();
                pln.Size = new System.Drawing.Size(330, 75);
                button.Size = new System.Drawing.Size(330, 75);
                button.Text = gameData.getName;
                pln.Controls.Add(button);
                flowLayoutPanel1.Controls.Add(pln);

                button.Click += (sender, e) =>
                {
                    Detail_Lb.Text = gameData.getDescribe;
                    GameName_Lb.Text = gameData.getName;
                    Version_Lb.Text = gameData.getVersion;

                    LoadGame_Btn.Visible = true;
                    canUpdate_Btn.Visible = true;
                    canUpdate_Btn.Enabled = gameData.NeedUpdates;

                };
            }
            catch (Exception)
            {
                //資料重複或異常
            }
        }

        #endregion
    }
}