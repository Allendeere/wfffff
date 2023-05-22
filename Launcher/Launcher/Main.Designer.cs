﻿namespace Launcher
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
            User_panel = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            Logout = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            Login = new Button();
            SeriaPanel = new Panel();
            SerialNumber = new TextBox();
            label5 = new Label();
            label6 = new Label();
            Login_panel = new Panel();
            TrainingAccount_TB = new TextBox();
            label8 = new Label();
            TrainingPW_TB = new TextBox();
            label7 = new Label();
            label1 = new Label();
            Forgotpassword = new Label();
            label2 = new Label();
            pictureBox_background = new PictureBox();
            pictureBox2 = new PictureBox();
            optionspanel = new Panel();
            LVersionlabel = new Label();
            Title_LB = new Label();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            LoginP = new Panel();
            button1 = new Button();
            user_btn = new Button();
            software_btn = new Button();
            TEST_spawnGobj = new Button();
            TEST_FakeUpdate = new Button();
            Test_NeedUpdate = new CheckBox();
            Test_Gamename = new TextBox();
            tabControl1.SuspendLayout();
            Loginsystem.SuspendLayout();
            User_panel.SuspendLayout();
            panel3.SuspendLayout();
            SeriaPanel.SuspendLayout();
            Login_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_background).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            optionspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            LoginP.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(Loginsystem);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.HotTrack = true;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Location = new Point(189, -10);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(616, 450);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 11;
            // 
            // Loginsystem
            // 
            Loginsystem.BackColor = SystemColors.Control;
            Loginsystem.BackgroundImageLayout = ImageLayout.Stretch;
            Loginsystem.Controls.Add(User_panel);
            Loginsystem.Controls.Add(Login);
            Loginsystem.Controls.Add(SeriaPanel);
            Loginsystem.Controls.Add(Login_panel);
            Loginsystem.Controls.Add(pictureBox_background);
            Loginsystem.Controls.Add(pictureBox2);
            Loginsystem.Location = new Point(4, 5);
            Loginsystem.Name = "Loginsystem";
            Loginsystem.Padding = new Padding(3);
            Loginsystem.Size = new Size(608, 441);
            Loginsystem.TabIndex = 0;
            Loginsystem.Text = "登入系統";
            // 
            // User_panel
            // 
            User_panel.BackColor = SystemColors.Control;
            User_panel.BackgroundImage = (Image)resources.GetObject("User_panel.BackgroundImage");
            User_panel.BackgroundImageLayout = ImageLayout.Stretch;
            User_panel.Controls.Add(panel3);
            User_panel.Controls.Add(panel2);
            User_panel.Controls.Add(panel1);
            User_panel.Location = new Point(-4, 2);
            User_panel.Name = "User_panel";
            User_panel.Size = new Size(627, 500);
            User_panel.TabIndex = 14;
            User_panel.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(44, 44, 54);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(Logout);
            panel3.Location = new Point(0, 21);
            panel3.Name = "panel3";
            panel3.Size = new Size(585, 71);
            panel3.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(514, 45);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 9;
            label3.Text = "允和科技";
            // 
            // Logout
            // 
            Logout.BackColor = Color.FromArgb(36, 36, 45);
            Logout.Enabled = false;
            Logout.FlatStyle = FlatStyle.Flat;
            Logout.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Logout.ForeColor = SystemColors.ButtonFace;
            Logout.Location = new Point(514, 14);
            Logout.Name = "Logout";
            Logout.Size = new Size(55, 30);
            Logout.TabIndex = 10;
            Logout.Text = "登出";
            Logout.UseVisualStyleBackColor = false;
            Logout.Click += Logout_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(44, 44, 54);
            panel2.Location = new Point(-43, 109);
            panel2.Name = "panel2";
            panel2.Size = new Size(434, 296);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 44, 54);
            panel1.Location = new Point(408, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(177, 296);
            panel1.TabIndex = 11;
            // 
            // Login
            // 
            Login.BackColor = Color.WhiteSmoke;
            Login.BackgroundImage = (Image)resources.GetObject("Login.BackgroundImage");
            Login.BackgroundImageLayout = ImageLayout.Stretch;
            Login.Enabled = false;
            Login.FlatStyle = FlatStyle.Flat;
            Login.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Login.ForeColor = Color.Orange;
            Login.Location = new Point(283, 323);
            Login.Name = "Login";
            Login.Size = new Size(125, 50);
            Login.TabIndex = 3;
            Login.Text = "驗證";
            Login.UseVisualStyleBackColor = false;
            Login.Click += Login_Click;
            // 
            // SeriaPanel
            // 
            SeriaPanel.BackColor = Color.Transparent;
            SeriaPanel.Controls.Add(SerialNumber);
            SeriaPanel.Controls.Add(label5);
            SeriaPanel.Controls.Add(label6);
            SeriaPanel.Location = new Point(30, 120);
            SeriaPanel.Name = "SeriaPanel";
            SeriaPanel.Size = new Size(238, 35);
            SeriaPanel.TabIndex = 12;
            // 
            // SerialNumber
            // 
            SerialNumber.BackColor = Color.FromArgb(247, 247, 244);
            SerialNumber.BorderStyle = BorderStyle.None;
            SerialNumber.Location = new Point(84, 4);
            SerialNumber.Name = "SerialNumber";
            SerialNumber.Size = new Size(147, 21);
            SerialNumber.TabIndex = 15;
            SerialNumber.TextChanged += SerialNumber_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Goldenrod;
            label5.Location = new Point(82, 9);
            label5.Name = "label5";
            label5.Size = new Size(149, 20);
            label5.TabIndex = 14;
            label5.Text = "____________________";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(0, 7);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 13;
            label6.Text = "組織序號 :";
            // 
            // Login_panel
            // 
            Login_panel.BackColor = Color.Transparent;
            Login_panel.Controls.Add(TrainingAccount_TB);
            Login_panel.Controls.Add(label8);
            Login_panel.Controls.Add(TrainingPW_TB);
            Login_panel.Controls.Add(label7);
            Login_panel.Controls.Add(label1);
            Login_panel.Controls.Add(Forgotpassword);
            Login_panel.Controls.Add(label2);
            Login_panel.Location = new Point(30, 100);
            Login_panel.Name = "Login_panel";
            Login_panel.Size = new Size(238, 104);
            Login_panel.TabIndex = 13;
            Login_panel.Visible = false;
            // 
            // TrainingAccount_TB
            // 
            TrainingAccount_TB.BackColor = Color.FromArgb(247, 247, 244);
            TrainingAccount_TB.BorderStyle = BorderStyle.None;
            TrainingAccount_TB.Location = new Point(84, 11);
            TrainingAccount_TB.Name = "TrainingAccount_TB";
            TrainingAccount_TB.Size = new Size(147, 21);
            TrainingAccount_TB.TabIndex = 6;
            TrainingAccount_TB.TextChanged += TrainingAccount_TB_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Goldenrod;
            label8.Location = new Point(82, 16);
            label8.Name = "label8";
            label8.Size = new Size(149, 20);
            label8.TabIndex = 16;
            label8.Text = "____________________";
            // 
            // TrainingPW_TB
            // 
            TrainingPW_TB.BackColor = Color.FromArgb(247, 247, 244);
            TrainingPW_TB.BorderStyle = BorderStyle.None;
            TrainingPW_TB.Location = new Point(84, 41);
            TrainingPW_TB.Name = "TrainingPW_TB";
            TrainingPW_TB.Size = new Size(147, 21);
            TrainingPW_TB.TabIndex = 7;
            TrainingPW_TB.TextChanged += TrainingPW_TB_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Goldenrod;
            label7.Location = new Point(82, 46);
            label7.Name = "label7";
            label7.Size = new Size(149, 20);
            label7.TabIndex = 15;
            label7.Text = "____________________";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 14);
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
            Forgotpassword.Location = new Point(158, 75);
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
            label2.Location = new Point(0, 42);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 5;
            label2.Text = "訓練密碼 :";
            // 
            // pictureBox_background
            // 
            pictureBox_background.BackColor = SystemColors.Control;
            pictureBox_background.Image = (Image)resources.GetObject("pictureBox_background.Image");
            pictureBox_background.Location = new Point(178, 94);
            pictureBox_background.Name = "pictureBox_background";
            pictureBox_background.Size = new Size(322, 289);
            pictureBox_background.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_background.TabIndex = 23;
            pictureBox_background.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-48, 27);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(395, 399);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // optionspanel
            // 
            optionspanel.BackColor = Color.FromArgb(36, 36, 45);
            optionspanel.Controls.Add(LVersionlabel);
            optionspanel.Controls.Add(Title_LB);
            optionspanel.Controls.Add(pictureBox4);
            optionspanel.Controls.Add(pictureBox3);
            optionspanel.Controls.Add(LoginP);
            optionspanel.Controls.Add(pictureBox1);
            optionspanel.Location = new Point(0, 0);
            optionspanel.Name = "optionspanel";
            optionspanel.Size = new Size(276, 452);
            optionspanel.TabIndex = 19;
            // 
            // LVersionlabel
            // 
            LVersionlabel.AutoSize = true;
            LVersionlabel.Font = new Font("Microsoft YaHei UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            LVersionlabel.ForeColor = SystemColors.ButtonFace;
            LVersionlabel.Location = new Point(223, 403);
            LVersionlabel.Name = "LVersionlabel";
            LVersionlabel.Size = new Size(40, 16);
            LVersionlabel.TabIndex = 3;
            LVersionlabel.Text = "v 0.0.0";
            // 
            // Title_LB
            // 
            Title_LB.AutoSize = true;
            Title_LB.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Title_LB.ForeColor = SystemColors.ButtonHighlight;
            Title_LB.Location = new Point(48, 19);
            Title_LB.Name = "Title_LB";
            Title_LB.Size = new Size(180, 26);
            Title_LB.TabIndex = 22;
            Title_LB.Text = "兵推系統訓練軟體";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(7, 48);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(176, 33);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(27, 370);
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
            pictureBox1.Location = new Point(146, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(132, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // LoginP
            // 
            LoginP.Controls.Add(button1);
            LoginP.Controls.Add(user_btn);
            LoginP.Controls.Add(software_btn);
            LoginP.Location = new Point(3, 3);
            LoginP.Name = "LoginP";
            LoginP.Size = new Size(214, 361);
            LoginP.TabIndex = 24;
            LoginP.Visible = false;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(36, 36, 45);
            button1.Location = new Point(20, 173);
            button1.Name = "button1";
            button1.Size = new Size(162, 40);
            button1.TabIndex = 23;
            button1.UseVisualStyleBackColor = true;
            // 
            // user_btn
            // 
            user_btn.BackgroundImage = (Image)resources.GetObject("user_btn.BackgroundImage");
            user_btn.BackgroundImageLayout = ImageLayout.Zoom;
            user_btn.FlatStyle = FlatStyle.Flat;
            user_btn.ForeColor = Color.FromArgb(36, 36, 45);
            user_btn.Location = new Point(20, 87);
            user_btn.Name = "user_btn";
            user_btn.Size = new Size(162, 40);
            user_btn.TabIndex = 19;
            user_btn.UseVisualStyleBackColor = true;
            user_btn.Click += user_btn_Click;
            // 
            // software_btn
            // 
            software_btn.BackgroundImage = (Image)resources.GetObject("software_btn.BackgroundImage");
            software_btn.BackgroundImageLayout = ImageLayout.Zoom;
            software_btn.FlatStyle = FlatStyle.Flat;
            software_btn.ForeColor = Color.FromArgb(36, 36, 45);
            software_btn.Location = new Point(20, 130);
            software_btn.Name = "software_btn";
            software_btn.Size = new Size(162, 40);
            software_btn.TabIndex = 20;
            software_btn.UseVisualStyleBackColor = true;
            software_btn.Click += software_btn_Click;
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
            Test_NeedUpdate.Location = new Point(501, 22);
            Test_NeedUpdate.Name = "Test_NeedUpdate";
            Test_NeedUpdate.Size = new Size(86, 19);
            Test_NeedUpdate.TabIndex = 14;
            Test_NeedUpdate.Text = "預設要更新";
            Test_NeedUpdate.UseVisualStyleBackColor = true;
            // 
            // Test_Gamename
            // 
            Test_Gamename.Location = new Point(578, 16);
            Test_Gamename.Name = "Test_Gamename";
            Test_Gamename.Size = new Size(59, 23);
            Test_Gamename.TabIndex = 16;
            Test_Gamename.Text = "兵推軟體";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
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
            User_panel.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            SeriaPanel.ResumeLayout(false);
            SeriaPanel.PerformLayout();
            Login_panel.ResumeLayout(false);
            Login_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_background).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            optionspanel.ResumeLayout(false);
            optionspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            LoginP.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabPage Loginsystem;
        private Label Forgotpassword;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button TEST_spawnGobj;
        private Button TEST_FakeUpdate;
        private CheckBox Test_NeedUpdate;
        private TextBox Test_Gamename;
        public Button Login;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button user_btn;
        private PictureBox pictureBox4;
        private Label label5;
        private Label label8;
        private Label label7;
        private Button button1;
        private Button software_btn;
        private Panel panel2;
        private Panel panel1;
        private Panel panel3;
        public Panel SeriaPanel;
        public Panel Login_panel;
        public PictureBox pictureBox_background;
        public TextBox TrainingPW_TB;
        public TextBox TrainingAccount_TB;
        public TextBox SerialNumber;
        public TabControl tabControl1;
        public Panel User_panel;
        public Button Logout;
        public Panel optionspanel;
        public PictureBox pictureBox3;
        public Label LVersionlabel;
        public Label Title_LB;
        public Panel LoginP;
    }
}