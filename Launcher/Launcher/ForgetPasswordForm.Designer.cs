namespace Launcher
{
    partial class ForgetPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            emailInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(139, 15);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "忘記密碼";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 48);
            label2.Name = "label2";
            label2.Size = new Size(233, 20);
            label2.TabIndex = 1;
            label2.Text = "請輸入申請信箱並進行密碼找回";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(128, 146);
            button1.Name = "button1";
            button1.Size = new Size(95, 29);
            button1.TabIndex = 2;
            button1.Text = "寄出申請";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // emailInput
            // 
            emailInput.Location = new Point(53, 98);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(245, 23);
            emailInput.TabIndex = 3;
            emailInput.TextChanged += textBox1_TextChanged;
            // 
            // ForgetPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 187);
            Controls.Add(emailInput);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ForgetPasswordForm";
            Text = "ForgetPasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox emailInput;
    }
}