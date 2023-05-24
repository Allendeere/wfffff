namespace Launcher
{
    partial class LoggerCrtl
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
            Console_showbox = new TextBox();
            Console_Inputbox = new TextBox();
            SuspendLayout();
            // 
            // Console_showbox
            // 
            Console_showbox.BackColor = SystemColors.WindowText;
            Console_showbox.ForeColor = SystemColors.Info;
            Console_showbox.Location = new Point(12, 12);
            Console_showbox.Multiline = true;
            Console_showbox.Name = "Console_showbox";
            Console_showbox.ReadOnly = true;
            Console_showbox.Size = new Size(776, 394);
            Console_showbox.TabIndex = 0;
            // 
            // Console_Inputbox
            // 
            Console_Inputbox.BackColor = SystemColors.WindowText;
            Console_Inputbox.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Console_Inputbox.ForeColor = SystemColors.Info;
            Console_Inputbox.Location = new Point(12, 412);
            Console_Inputbox.Name = "Console_Inputbox";
            Console_Inputbox.Size = new Size(776, 32);
            Console_Inputbox.TabIndex = 1;
            Console_Inputbox.KeyPress += Console_Inputbox_KeyPress;
            // 
            // LoggerCrtl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(Console_Inputbox);
            Controls.Add(Console_showbox);
            Name = "LoggerCrtl";
            Text = "LoggerCrtl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Console_showbox;
        private TextBox Console_Inputbox;
    }
}