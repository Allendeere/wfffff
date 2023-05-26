using Launcher.NewFolder;


namespace Launcher
{
    public partial class MainForm : Form
    {

        public readonly IServerSerice _serverSerice;  //Server方面，到時候把UpdateRelated移過去

        public UIControl uictrl; //功能集

        public Action LoadGame; //遊戲啟動按鈕的東西

        public MainForm()
        {
            InitializeComponent();
        }

        private void Forgotpassword_Click(object sender, EventArgs e)//忘記密碼
        {
            uictrl.ForgetPW();//跳出忘記密碼視窗
        }

        private void Login_Click(object sender, EventArgs e)
        {
            uictrl.Login();//登入
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
            authentication_btn.Enabled = (SerialNumber.Text.Length > 1);//檢查驗證字串
        }

        private void TrainingPW_TB_TextChanged(object sender, EventArgs e)
        {
            Login.Enabled = (TrainingAccount_TB.Text.Length > 1 && TrainingPW_TB.Text.Length > 1);//檢查登入字串
        }

        private void TrainingAccount_TB_TextChanged(object sender, EventArgs e)
        {
            Login.Enabled = (TrainingAccount_TB.Text.Length > 1 && TrainingPW_TB.Text.Length > 1);//檢查登入字串
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            uictrl.Logout();//登出
        }
        #endregion

        //測試用 : 生成遊戲物件
        private void TEST_spawnGobj_Click(object sender, EventArgs e)
        {

            Random random = new Random();

            var GameName = "FakeGame - " + random.Next(0, 99999);

            var GameVersion = $"v {random.Next(0, 9)}.{random.Next(0, 9)}.{random.Next(0, 9)}";

            var Detail = "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。";

            uictrl.GameInfo.Add(GameName, new GameData(GameVersion, GameName, Detail));

            uictrl.SpawnSoftware(GameName);

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
            uictrl.FindPath();//選擇路徑
        }

        private void mypath_tb_TextChanged(object sender, EventArgs e)
        {
            uictrl.CheckPath();//當路徑改變時檢查路徑的正確性
        }

        private void authentication_btn_Click(object sender, EventArgs e)
        {
            uictrl.Verify();//驗證
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            uictrl.LoggerCrtl.Show();//叫出放Logger的地方
        }

        private void AutoUpdate_btn_CheckedChanged(object sender, EventArgs e)
        {
            uictrl.AutoUpdateSetting();//自動更新
        }

        private void Update_btn_Click(object sender, EventArgs e)//當檢測到需要更新時會跳出的按鈕
        {
            uictrl.Update();//手動更新
        }

        private void LoadGame_Btn_Click(object sender, EventArgs e)//遊戲啟動按鈕
        {
            LoadGame();
        }


        bool isOpenLogger;
        private void loggerbtn_Click(object sender, EventArgs e)
        {
            isOpenLogger = !isOpenLogger;

            tabControl1.SelectedIndex = (isOpenLogger) ? 2 : 0;

        }

        private void Console_txtbox_main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && Console_txtbox_main.Text.Length > 0)
            {

                if (Console_txtbox_main.Text[0] == '/') //輸入\Test
                    uictrl.LoggerCrtl.CommandsInput(Console_txtbox_main.Text);

                else if (Console_txtbox_main.Text[0] == '!') //輸入 !download path!get
                {
                    var Tests = Console_txtbox_main.Text.Split('!');
                    if (Tests[1] == "download path")
                    {
                        if (Tests[2] == "get")
                        {

                        }
                        else if (Tests[2] == "set")
                        {
                            uictrl.updateRelated.Setfilepaht(Tests[2]);
                        }
                        uictrl.LoggerCrtl.Sand(LoggerCrtl.Levels.command, uictrl.updateRelated.Getfilepaht());
                    }
                    if (Tests[1] == "download url")
                    {
                        if (Tests[2] == "version")
                        {
                            if (Tests[3] == "get")
                            {

                            }
                            else if (Tests[3] == "set")
                            {
                                uictrl.updateRelated.SetVersionurl(Tests[4]);
                            }
                            uictrl.LoggerCrtl.Sand(LoggerCrtl.Levels.command, uictrl.updateRelated.GetVersionurl());
                        }
                        else if (Tests[2] == "zip")  //!download url!zip!get
                        {
                            if (Tests[3] == "get")
                            {

                            }
                            else if (Tests[3] == "set")
                            {
                                uictrl.updateRelated.Setzipurl(Tests[4]);
                            }
                            uictrl.LoggerCrtl.Sand(LoggerCrtl.Levels.command, uictrl.updateRelated.Getzipurl());
                        }
                    }
                }
                else
                {
                    uictrl.LoggerCrtl.Sand(LoggerCrtl.Levels.user, Console_txtbox_main.Text);
                }

                Console_txtbox_main.Text = null;
            }
        }
    }
}