using Launcher.NewFolder;


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
            uictrl.Login();
        }
        #region UI 

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            mypath_tb.Text = Properties.Settings.Default.localFilePath;

            AutoUpdate_btn.Checked = Properties.Settings.Default.AutoUpdate;
        }

        private void SerialNumber_TextChanged(object sender, EventArgs e)
        {
            authentication_btn.Enabled = (SerialNumber.Text.Length > 1);
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

        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e)
        {
            uictrl.SpawnSoftware($"v7.7.7", "GameTest", "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。");
        }


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
            uictrl.FindPath();

        }

        private void mypath_tb_TextChanged(object sender, EventArgs e)
        {
            uictrl.CheckPath();
        }

        private void authentication_btn_Click(object sender, EventArgs e)
        {
            uictrl.Verify();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            uictrl.LoggerCrtl.Show();
        }

        private void AutoUpdate_btn_CheckedChanged(object sender, EventArgs e)
        {
            uictrl.AutoUpdateSetting();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            uictrl.Update();
        }
    }
}