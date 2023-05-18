using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (new Regex("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$").IsMatch(emailInput.Text))
            {
                emailInput.BackColor = Color.White;
                button1.Enabled = true;
            }
            else
            {
                emailInput.BackColor = Color.Red;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO:忘記密碼，寄出email
            this.Close();
        }
    }
}
