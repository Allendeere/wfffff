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
            Login = new Button();
            SeriaPanel = new Panel();
            SerialNumber = new TextBox();
            label6 = new Label();
            Forgotpassword = new Label();
            TrainingPW_TB = new TextBox();
            TrainingAccount_TB = new TextBox();
            label3 = new Label();
            Logout = new Button();
            label2 = new Label();
            label1 = new Label();
            SystemInformation = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            Detail_Lb = new Label();
            Version_Lb = new Label();
            label4 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            GameName_Lb = new Label();
            tabControl1.SuspendLayout();
            Loginsystem.SuspendLayout();
            SeriaPanel.SuspendLayout();
            SystemInformation.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Loginsystem);
            tabControl1.Controls.Add(SystemInformation);
            tabControl1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
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
            Loginsystem.Controls.Add(Forgotpassword);
            Loginsystem.Controls.Add(TrainingPW_TB);
            Loginsystem.Controls.Add(TrainingAccount_TB);
            Loginsystem.Controls.Add(label3);
            Loginsystem.Controls.Add(Logout);
            Loginsystem.Controls.Add(label2);
            Loginsystem.Controls.Add(label1);
            Loginsystem.Location = new Point(4, 44);
            Loginsystem.Name = "Loginsystem";
            Loginsystem.Padding = new Padding(3);
            Loginsystem.Size = new Size(768, 340);
            Loginsystem.TabIndex = 0;
            Loginsystem.Text = "登入系統";
            // 
            // Login
            // 
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
            // Forgotpassword
            // 
            Forgotpassword.AutoSize = true;
            Forgotpassword.Cursor = Cursors.Hand;
            Forgotpassword.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Forgotpassword.Location = new Point(497, 153);
            Forgotpassword.Name = "Forgotpassword";
            Forgotpassword.Size = new Size(73, 20);
            Forgotpassword.TabIndex = 8;
            Forgotpassword.Text = "忘記密碼";
            Forgotpassword.Click += Forgotpassword_Click;
            // 
            // TrainingPW_TB
            // 
            TrainingPW_TB.Location = new Point(331, 150);
            TrainingPW_TB.Name = "TrainingPW_TB";
            TrainingPW_TB.Size = new Size(147, 28);
            TrainingPW_TB.TabIndex = 7;
            // 
            // TrainingAccount_TB
            // 
            TrainingAccount_TB.Location = new Point(331, 119);
            TrainingAccount_TB.Name = "TrainingAccount_TB";
            TrainingAccount_TB.Size = new Size(147, 28);
            TrainingAccount_TB.TabIndex = 6;
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
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(230, 153);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 5;
            label2.Text = "訓練密碼 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(230, 127);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 4;
            label1.Text = "訓練帳號 :";
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
            panel1.Controls.Add(GameName_Lb);
            panel1.Controls.Add(Detail_Lb);
            panel1.Controls.Add(Version_Lb);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(475, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 337);
            panel1.TabIndex = 0;
            // 
            // Detail_Lb
            // 
            Detail_Lb.AutoSize = true;
            Detail_Lb.Location = new Point(12, 81);
            Detail_Lb.Name = "Detail_Lb";
            Detail_Lb.Size = new Size(53, 20);
            Detail_Lb.TabIndex = 12;
            Detail_Lb.Text = "Detail";
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
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(436, 337);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(503, 12);
            button1.Name = "button1";
            button1.Size = new Size(109, 23);
            button1.TabIndex = 12;
            button1.Text = "生成FK遊戲";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 431);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "兵推系統訓練軟體";
            tabControl1.ResumeLayout(false);
            Loginsystem.ResumeLayout(false);
            Loginsystem.PerformLayout();
            SeriaPanel.ResumeLayout(false);
            SeriaPanel.PerformLayout();
            SystemInformation.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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
        private Button Login;
        private Label label1;
        private TabPage SystemInformation;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Label Version_Lb;
        private Label label4;
        private Panel SeriaPanel;
        private TextBox SerialNumber;
        private Label label6;
        private Button button1;
        private Label Detail_Lb;
        private Label GameName_Lb;
    }
}