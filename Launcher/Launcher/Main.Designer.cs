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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            Loginsystem = new TabPage();
            SeriaPanel = new Panel();
            SerialNumber = new TextBox();
            label6 = new Label();
            Login_panel = new Panel();
            TrainingPW_TB = new TextBox();
            label1 = new Label();
            Forgotpassword = new Label();
            label2 = new Label();
            TrainingAccount_TB = new TextBox();
            Login = new Button();
            User_panel = new Panel();
            AccountManagement = new Button();
            Logout = new Button();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            TEST_spawnGobj = new Button();
            TEST_FakeUpdate = new Button();
            Test_NeedUpdate = new CheckBox();
            Test_Gamename = new TextBox();
            Test_LauncherVCheck = new Button();
            Test_v = new TextBox();
            optionspanel = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            LVersionlabel = new Label();
            tabControl1.SuspendLayout();
            Loginsystem.SuspendLayout();
            SeriaPanel.SuspendLayout();
            Login_panel.SuspendLayout();
            User_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            optionspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Loginsystem);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.HotTrack = true;
            tabControl1.ItemSize = new Size(100, 40);
            tabControl1.Location = new Point(189, 1);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(616, 437);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 11;
            // 
            // Loginsystem
            // 
            Loginsystem.BackColor = Color.LightGray;
            Loginsystem.BackgroundImageLayout = ImageLayout.Stretch;
            Loginsystem.Controls.Add(SeriaPanel);
            Loginsystem.Controls.Add(Login_panel);
            Loginsystem.Controls.Add(Login);
            Loginsystem.Controls.Add(User_panel);
            Loginsystem.Controls.Add(pictureBox2);
            Loginsystem.Location = new Point(4, 44);
            Loginsystem.Name = "Loginsystem";
            Loginsystem.Padding = new Padding(3);
            Loginsystem.Size = new Size(608, 389);
            Loginsystem.TabIndex = 0;
            Loginsystem.Text = "登入系統";
            // 
            // SeriaPanel
            // 
            SeriaPanel.Controls.Add(SerialNumber);
            SeriaPanel.Controls.Add(label6);
            SeriaPanel.Location = new Point(205, 47);
            SeriaPanel.Name = "SeriaPanel";
            SeriaPanel.Size = new Size(292, 56);
            SeriaPanel.TabIndex = 12;
            // 
            // SerialNumber
            // 
            SerialNumber.Location = new Point(113, 5);
            SerialNumber.Name = "SerialNumber";
            SerialNumber.Size = new Size(147, 28);
            SerialNumber.TabIndex = 14;
            SerialNumber.TextChanged += SerialNumber_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 13);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 13;
            label6.Text = "組織序號 :";
            // 
            // Login_panel
            // 
            Login_panel.BackColor = Color.IndianRed;
            Login_panel.Controls.Add(TrainingPW_TB);
            Login_panel.Controls.Add(label1);
            Login_panel.Controls.Add(Forgotpassword);
            Login_panel.Controls.Add(label2);
            Login_panel.Controls.Add(TrainingAccount_TB);
            Login_panel.Location = new Point(178, 97);
            Login_panel.Name = "Login_panel";
            Login_panel.Size = new Size(339, 70);
            Login_panel.TabIndex = 13;
            Login_panel.Visible = false;
            // 
            // TrainingPW_TB
            // 
            TrainingPW_TB.Location = new Point(104, 37);
            TrainingPW_TB.Name = "TrainingPW_TB";
            TrainingPW_TB.Size = new Size(147, 28);
            TrainingPW_TB.TabIndex = 7;
            TrainingPW_TB.TextChanged += TrainingPW_TB_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 14);
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
            Forgotpassword.Location = new Point(270, 40);
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
            label2.Location = new Point(3, 40);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 5;
            label2.Text = "訓練密碼 :";
            // 
            // TrainingAccount_TB
            // 
            TrainingAccount_TB.Location = new Point(104, 6);
            TrainingAccount_TB.Name = "TrainingAccount_TB";
            TrainingAccount_TB.Size = new Size(147, 28);
            TrainingAccount_TB.TabIndex = 6;
            TrainingAccount_TB.TextChanged += TrainingAccount_TB_TextChanged;
            // 
            // Login
            // 
            Login.Enabled = false;
            Login.Location = new Point(350, 302);
            Login.Name = "Login";
            Login.Size = new Size(88, 38);
            Login.TabIndex = 3;
            Login.Text = "驗證";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // User_panel
            // 
            User_panel.BackColor = Color.OliveDrab;
            User_panel.Controls.Add(AccountManagement);
            User_panel.Controls.Add(Logout);
            User_panel.Controls.Add(label3);
            User_panel.Location = new Point(435, 6);
            User_panel.Name = "User_panel";
            User_panel.Size = new Size(170, 349);
            User_panel.TabIndex = 14;
            User_panel.Visible = false;
            // 
            // AccountManagement
            // 
            AccountManagement.BackColor = Color.Orange;
            AccountManagement.ForeColor = Color.Black;
            AccountManagement.Location = new Point(25, 143);
            AccountManagement.Name = "AccountManagement";
            AccountManagement.Size = new Size(86, 80);
            AccountManagement.TabIndex = 0;
            AccountManagement.Text = "帳號管理";
            AccountManagement.UseVisualStyleBackColor = false;
            AccountManagement.Click += AccountManagement_Click;
            // 
            // Logout
            // 
            Logout.Enabled = false;
            Logout.Location = new Point(92, 3);
            Logout.Name = "Logout";
            Logout.Size = new Size(75, 30);
            Logout.TabIndex = 10;
            Logout.Text = "登出";
            Logout.UseVisualStyleBackColor = true;
            Logout.Click += Logout_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(13, 7);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 9;
            label3.Text = "允和科技";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-34, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(400, 400);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
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
            Test_NeedUpdate.Location = new Point(352, 14);
            Test_NeedUpdate.Name = "Test_NeedUpdate";
            Test_NeedUpdate.Size = new Size(86, 19);
            Test_NeedUpdate.TabIndex = 14;
            Test_NeedUpdate.Text = "預設要更新";
            Test_NeedUpdate.UseVisualStyleBackColor = true;
            // 
            // Test_Gamename
            // 
            Test_Gamename.Location = new Point(444, 10);
            Test_Gamename.Name = "Test_Gamename";
            Test_Gamename.Size = new Size(59, 23);
            Test_Gamename.TabIndex = 16;
            Test_Gamename.Text = "兵推";
            // 
            // Test_LauncherVCheck
            // 
            Test_LauncherVCheck.BackColor = Color.DarkOrange;
            Test_LauncherVCheck.Location = new Point(79, 60);
            Test_LauncherVCheck.Name = "Test_LauncherVCheck";
            Test_LauncherVCheck.Size = new Size(109, 23);
            Test_LauncherVCheck.TabIndex = 17;
            Test_LauncherVCheck.Text = "啟動器更新";
            Test_LauncherVCheck.UseVisualStyleBackColor = false;
            Test_LauncherVCheck.Click += Test_LauncherVCheck_Click;
            // 
            // Test_v
            // 
            Test_v.Location = new Point(194, 50);
            Test_v.Name = "Test_v";
            Test_v.Size = new Size(59, 23);
            Test_v.TabIndex = 18;
            Test_v.Text = "v9.9.9";
            // 
            // optionspanel
            // 
            optionspanel.BackColor = Color.FromArgb(36, 36, 45);
            optionspanel.Controls.Add(Test_v);
            optionspanel.Controls.Add(pictureBox3);
            optionspanel.Controls.Add(Test_LauncherVCheck);
            optionspanel.Controls.Add(pictureBox1);
            optionspanel.Controls.Add(LVersionlabel);
            optionspanel.Location = new Point(-42, -48);
            optionspanel.Name = "optionspanel";
            optionspanel.Size = new Size(335, 518);
            optionspanel.TabIndex = 19;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(90, 420);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(183, 60);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(193, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // LVersionlabel
            // 
            LVersionlabel.AutoSize = true;
            LVersionlabel.Font = new Font("Microsoft YaHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            LVersionlabel.ForeColor = SystemColors.ButtonFace;
            LVersionlabel.Location = new Point(286, 453);
            LVersionlabel.Name = "LVersionlabel";
            LVersionlabel.Size = new Size(40, 16);
            LVersionlabel.TabIndex = 3;
            LVersionlabel.Text = "v 0.0.0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 431);
            Controls.Add(Test_Gamename);
            Controls.Add(Test_NeedUpdate);
            Controls.Add(TEST_FakeUpdate);
            Controls.Add(TEST_spawnGobj);
            Controls.Add(optionspanel);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "兵推系統訓練軟體";
            tabControl1.ResumeLayout(false);
            Loginsystem.ResumeLayout(false);
            SeriaPanel.ResumeLayout(false);
            SeriaPanel.PerformLayout();
            Login_panel.ResumeLayout(false);
            Login_panel.PerformLayout();
            User_panel.ResumeLayout(false);
            User_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            optionspanel.ResumeLayout(false);
            optionspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button AccountManagement;
        private Panel optionspanel;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        private Label LVersionlabel;
        private PictureBox pictureBox2;
    }
}