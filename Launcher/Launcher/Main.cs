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
        public TIF _tiF;

        //當登入成功時存入生成遊戲物件的方法
        Action setup;
        Action logout;
        Action<string> Functions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Forgotpassword_Click(object sender, EventArgs e)
        {
            _tiF.ForgetPW();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            switch (Login.Text)
            {
                case "登入":
                    _tiF.Login();
                    break;
                case "驗證":
                    _tiF.Verify();
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
            _tiF.Logout();
        }
        #endregion


        #region 測試區

        private void TEST_FakeUpdate_Click(object sender, EventArgs e)
        {
            foreach (object key in _tiF.gameDT.Values)
            {
                try
                {
                    if (key is GameData gt) //搜尋遊戲名程
                    {
                        if (gt.NeedUpdates)//是否需要更新
                            MessageBox.Show($"偵測到一筆新的新版本，是否進行更新 \n\r遊戲名稱:{gt.getName} \n\r當前版本:{gt.getVersion} \n\r最新版本:9.9.9 ", "更新提示", MessageBoxButtons.YesNoCancel);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("目前沒有可更新的遊戲");
                }
            }
        }

        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e) //TODO : 移至功能集
        {
            _tiF.SpawnSoftware();
        }
        #endregion

        private void user_btn_Click(object sender, EventArgs e)
        {
            _tiF.PageSwitch("user"); //換頁
        }

        private void software_btn_Click(object sender, EventArgs e)
        {
            _tiF.PageSwitch("software"); //換頁
        }
    }
}