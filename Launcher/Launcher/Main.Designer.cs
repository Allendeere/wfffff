namespace Launcher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Loginsystem = new TabPage();
            User_panel = new Panel();
            Login = new Button();
            SeriaPanel = new Panel();
            SerialNumber = new TextBox();
            label6 = new Label();
            label3 = new Label();
            Logout = new Button();
            Login_panel = new Panel();
            TrainingPW_TB = new TextBox();
            label1 = new Label();
            Forgotpassword = new Label();
            label2 = new Label();
            TrainingAccount_TB = new TextBox();
            TEST_spawnGobj = new Button();
            TEST_FakeUpdate = new Button();
            Test_NeedUpdate = new CheckBox();
            Test_Gamename = new TextBox();
            Test_LauncherVCheck = new Button();
            Test_v = new TextBox();
            tabControl1.SuspendLayout();
            Loginsystem.SuspendLayout();
            SeriaPanel.SuspendLayout();
            Login_panel.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Loginsystem);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.HotTrack = true;
            tabControl1.ItemSize = new Size(100, 40);
            tabControl1.Location = new Point(12, 30);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 388);
            tabControl1.TabIndex = 11;
            // 
            // Loginsystem
            // 
            Loginsystem.BackColor = Color.LightGray;
            Loginsystem.BackgroundImageLayout = ImageLayout.Stretch;
            Loginsystem.Controls.Add(Login);
            Loginsystem.Controls.Add(SeriaPanel);
            Loginsystem.Controls.Add(label3);
            Loginsystem.Controls.Add(Logout);
            Loginsystem.Controls.Add(Login_panel);
            Loginsystem.Controls.Add(User_panel);
            Loginsystem.Location = new Point(4, 44);
            Loginsystem.Name = "Loginsystem";
            Loginsystem.Padding = new Padding(3);
            Loginsystem.Size = new Size(768, 340);
            Loginsystem.TabIndex = 0;
            Loginsystem.Text = "登入系統";
            // 
            // User_panel
            // 
            User_panel.BackColor = Color.OliveDrab;
            User_panel.Location = new Point(39, 46);
            User_panel.Name = "User_panel";
            User_panel.Size = new Size(691, 271);
            User_panel.TabIndex = 14;
            User_panel.Visible = false;
            // 
            // Login
            // 
            Login.Enabled = false;
            Login.Location = new Point(364, 279);
            Login.Name = "Login";
            Login.Size = new Size(88, 38);
            Login.TabIndex = 3;
            Login.Text = "驗證";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // SeriaPanel
            // 
            SeriaPanel.Controls.Add(SerialNumber);
            SeriaPanel.Controls.Add(label6);
            SeriaPanel.Location = new Point(4, 3);
            SeriaPanel.Name = "SeriaPanel";
            SeriaPanel.Size = new Size(759, 266);
            SeriaPanel.TabIndex = 12;
            // 
            // SerialNumber
            // 
            SerialNumber.Location = new Point(368, 146);
            SerialNumber.Name = "SerialNumber";
            SerialNumber.Size = new Size(147, 28);
            SerialNumber.TabIndex = 14;
            SerialNumber.TextChanged += SerialNumber_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(267, 154);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 13;
            label6.Text = "組織序號 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(608, 7);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 9;
            label3.Text = "允和科技";
            // 
            // Logout
            // 
            Logout.Enabled = false;
            Logout.Location = new Point(687, 3);
            Logout.Name = "Logout";
            Logout.Size = new Size(75, 30);
            Logout.TabIndex = 10;
            Logout.Text = "登出";
            Logout.UseVisualStyleBackColor = true;
            Logout.Click += Logout_Click;
            // 
            // Login_panel
            // 
            Login_panel.BackColor = Color.IndianRed;
            Login_panel.Controls.Add(TrainingPW_TB);
            Login_panel.Controls.Add(label1);
            Login_panel.Controls.Add(Forgotpassword);
            Login_panel.Controls.Add(label2);
            Login_panel.Controls.Add(TrainingAccount_TB);
            Login_panel.Location = new Point(219, 85);
            Login_panel.Name = "Login_panel";
            Login_panel.Size = new Size(370, 124);
            Login_panel.TabIndex = 13;
            // 
            // TrainingPW_TB
            // 
            TrainingPW_TB.Location = new Point(114, 61);
            TrainingPW_TB.Name = "TrainingPW_TB";
            TrainingPW_TB.Size = new Size(147, 28);
            TrainingPW_TB.TabIndex = 7;
            TrainingPW_TB.TextChanged += TrainingPW_TB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 4;
            label1.Text = "訓練帳號 :";
            // 
            // Forgotpassword
            // 
            Forgotpassword.AutoSize = true;
            Forgotpassword.Cursor = Cursors.Hand;
            Forgotpassword.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Forgotpassword.Location = new Point(280, 64);
            Forgotpassword.Name = "Forgotpassword";
            Forgotpassword.Size = new Size(73, 20);
            Forgotpassword.TabIndex = 8;
            Forgotpassword.Text = "忘記密碼";
            Forgotpassword.Click += Forgotpassword_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 64);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 5;
            label2.Text = "訓練密碼 :";
            // 
            // TrainingAccount_TB
            // 
            TrainingAccount_TB.Location = new Point(114, 30);
            TrainingAccount_TB.Name = "TrainingAccount_TB";
            TrainingAccount_TB.Size = new Size(147, 28);
            TrainingAccount_TB.TabIndex = 6;
            TrainingAccount_TB.TextChanged += TrainingAccount_TB_TextChanged;
            // 
            // TEST_spawnGobj
            // 
            TEST_spawnGobj.Location = new Point(512, 1);
            TEST_spawnGobj.Name = "TEST_spawnGobj";
            TEST_spawnGobj.Size = new Size(109, 23);
            TEST_spawnGobj.TabIndex = 12;
            TEST_spawnGobj.Text = "生成FK遊戲";
            TEST_spawnGobj.UseVisualStyleBackColor = true;
            TEST_spawnGobj.Click += TEST_spawnGobj_Click;
            // 
            // TEST_FakeUpdate
            // 
            TEST_FakeUpdate.Location = new Point(637, 1);
            TEST_FakeUpdate.Name = "TEST_FakeUpdate";
            TEST_FakeUpdate.Size = new Size(109, 23);
            TEST_FakeUpdate.TabIndex = 13;
            TEST_FakeUpdate.Text = "假更新警報";
            TEST_FakeUpdate.UseVisualStyleBackColor = true;
            TEST_FakeUpdate.Click += TEST_FakeUpdate_Click;
            // 
            // Test_NeedUpdate
            // 
            Test_NeedUpdate.AutoSize = true;
            Test_NeedUpdate.Location = new Point(470, 30);
            Test_NeedUpdate.Name = "Test_NeedUpdate";
            Test_NeedUpdate.Size = new Size(86, 19);
            Test_NeedUpdate.TabIndex = 14;
            Test_NeedUpdate.Text = "預設要更新";
            Test_NeedUpdate.UseVisualStyleBackColor = true;
            // 
            // Test_Gamename
            // 
            Test_Gamename.Location = new Point(562, 26);
            Test_Gamename.Name = "Test_Gamename";
            Test_Gamename.Size = new Size(59, 23);
            Test_Gamename.TabIndex = 16;
            Test_Gamename.Text = "兵推";
            // 
            // Test_LauncherVCheck
            // 
            Test_LauncherVCheck.BackColor = Color.DarkOrange;
            Test_LauncherVCheck.Location = new Point(218, 1);
            Test_LauncherVCheck.Name = "Test_LauncherVCheck";
            Test_LauncherVCheck.Size = new Size(109, 23);
            Test_LauncherVCheck.TabIndex = 17;
            Test_LauncherVCheck.Text = "啟動器更新";
            Test_LauncherVCheck.UseVisualStyleBackColor = false;
            Test_LauncherVCheck.Click += Test_LauncherVCheck_Click;
            // 
            // Test_v
            // 
            Test_v.Location = new Point(268, 26);
            Test_v.Name = "Test_v";
            Test_v.Size = new Size(59, 23);
            Test_v.TabIndex = 18;
            Test_v.Text = "v9.9.9";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 431);
            Controls.Add(Test_v);
            Controls.Add(Test_LauncherVCheck);
            Controls.Add(Test_Gamename);
            Controls.Add(Test_NeedUpdate);
            Controls.Add(TEST_FakeUpdate);
            Controls.Add(TEST_spawnGobj);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "兵推系統訓練軟體";
            tabControl1.ResumeLayout(false);
            Loginsystem.ResumeLayout(false);
            Loginsystem.PerformLayout();
            SeriaPanel.ResumeLayout(false);
            SeriaPanel.PerformLayout();
            Login_panel.ResumeLayout(false);
            Login_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Loginsystem;
        private Label Forgotpassword;
        private TextBox TrainingPW_TB;
        private TextBox TrainingAccount_TB;
        private Label label3;
        private Button Logout;
        private Label label2;
        private Label label1;
        private Panel SeriaPanel;
        private Label label6;
        private Button TEST_spawnGobj;
        private Button TEST_FakeUpdate;
        private CheckBox Test_NeedUpdate;
        private TextBox Test_Gamename;
        private TextBox SerialNumber;
        public Button Login;
        private Button Test_LauncherVCheck;
        private TextBox Test_v;
        private Panel Login_panel;
        private Panel User_panel;
    }
}