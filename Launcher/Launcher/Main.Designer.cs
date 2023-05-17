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
            Forgotpassword = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            Logout = new Button();
            label2 = new Label();
            Login = new Button();
            label1 = new Label();
            SystemInformation = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            tabControl1.SuspendLayout();
            Loginsystem.SuspendLayout();
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
            Loginsystem.BackColor = Color.White;
            Loginsystem.BackgroundImageLayout = ImageLayout.Stretch;
            Loginsystem.Controls.Add(Forgotpassword);
            Loginsystem.Controls.Add(textBox2);
            Loginsystem.Controls.Add(textBox1);
            Loginsystem.Controls.Add(label3);
            Loginsystem.Controls.Add(Logout);
            Loginsystem.Controls.Add(label2);
            Loginsystem.Controls.Add(Login);
            Loginsystem.Controls.Add(label1);
            Loginsystem.Location = new Point(4, 44);
            Loginsystem.Name = "Loginsystem";
            Loginsystem.Padding = new Padding(3);
            Loginsystem.Size = new Size(768, 340);
            Loginsystem.TabIndex = 0;
            Loginsystem.Text = "登入系統";
            // 
            // Forgotpassword
            // 
            Forgotpassword.AutoSize = true;
            Forgotpassword.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Forgotpassword.Location = new Point(507, 157);
            Forgotpassword.Name = "Forgotpassword";
            Forgotpassword.Size = new Size(73, 20);
            Forgotpassword.TabIndex = 8;
            Forgotpassword.Text = "忘記密碼";
            Forgotpassword.Click += Forgotpassword_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(331, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(147, 28);
            textBox2.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(331, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(147, 28);
            textBox1.TabIndex = 6;
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
            // Login
            // 
            Login.Location = new Point(364, 279);
            Login.Name = "Login";
            Login.Size = new Size(88, 38);
            Login.TabIndex = 3;
            Login.Text = "登入";
            Login.UseVisualStyleBackColor = true;
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
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(475, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 337);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(111, 10);
            label5.Name = "label5";
            label5.Size = new Size(19, 20);
            label5.TabIndex = 11;
            label5.Text = "X";
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 431);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "兵推系統訓練軟體";
            tabControl1.ResumeLayout(false);
            Loginsystem.ResumeLayout(false);
            Loginsystem.PerformLayout();
            SystemInformation.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Loginsystem;
        private Label Forgotpassword;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Button Logout;
        private Label label2;
        private Button Login;
        private Label label1;
        private TabPage SystemInformation;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Label label5;
        private Label label4;
    }
}