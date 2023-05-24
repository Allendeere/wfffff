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
using System.Drawing;

namespace Launcher
{
    public partial class MainForm : Form
    {
        //Server方面
        public readonly IServerSerice _serverSerice;
        //功能集
        public UIControl uictrl;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Forgotpassword_Click(object sender, EventArgs e)
        {
            uictrl.ForgetPW();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            switch (Login.Text)
            {
                case "登入":
                    uictrl.Login();
                    break;
                case "驗證":
                    uictrl.Verify();
                    break;
                case "執行訓練":
                    break;
            }
        }
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
            uictrl.Logout();
        }
        #endregion


        #region 測試區


        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            uictrl.SpawnSoftware("Test" + random.Next(1, 1000));
        }
        #endregion

        private void user_btn_Click(object sender, EventArgs e)
        {
            uictrl.PageSwitch(0); //換頁
        }

        private void software_btn_Click(object sender, EventArgs e)
        {
            uictrl.PageSwitch(1); //換頁
        }

        private void mypath_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "選擇資料夾";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mypath_tb.Text = Path.GetDirectoryName(openFileDialog.FileName);
                }
            }
        }

        private void mypath_tb_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(mypath_tb.Text))
            {
                Console.WriteLine("路徑有效");
                mypath_tb.ForeColor = Color.BurlyWood;
            }
            else
            {
                Console.WriteLine("路徑無效");
                mypath_tb.ForeColor = Color.IndianRed;

            }
        }
    }
}