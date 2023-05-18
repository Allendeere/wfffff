using Launcher.NewFolder;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Launcher
{
    public partial class MainForm : Form
    {
        //Server方面
        public readonly IServerSerice _serverSerice;
        //功能
        public TIF _tiF = new TIF();

        public MainForm()
        {
            _tiF.OnlyOneProcess();
            InitializeComponent();
        }

        private void Forgotpassword_Click(object sender, EventArgs e)
        {
            string emailInput = Microsoft.VisualBasic.Interaction.InputBox("输入申請信箱並找回密碼", "忘記密碼", "");

            MessageBox.Show(new Regex("^[\\w\\.-]+@[\\w\\.-]+\\.\\w+$").IsMatch(emailInput) ? "字符串符合电子邮件格式" : "X");
        }

        private void Login_Click(object sender, EventArgs e)
        {

            //UI CTRL : 驗證

            if (SerialNumber.Text != "")
            {
                Login.Text = "登入";
                SeriaPanel.Visible = false;
            }

            //登入完成
            if (TrainingAccount_TB.Text != "" && TrainingPW_TB.Text != "")
            {
                tabControl1.SelectedIndex = 1;
            }

        }

        //測試用 : 生成遊戲物件
        private void button1_Click(object sender, EventArgs e)
        {
            GameData gameData = new GameData("1.0.0", "兵", ".....");

            //顯示在UI上

            // 創建按鈕
            Panel pln = new Panel();
            Button button = new Button();
            pln.Size = new System.Drawing.Size(330, 75);
            button.Size = new System.Drawing.Size(330, 75);
            button.Text = gameData.getName;
            pln.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(pln);

            button.Click += (sender, e) =>
            {
                MessageBox.Show("按下了按鈕！");
                Detail_Lb.Text = gameData.getDescribe;
                GameName_Lb.Text = gameData.getName;
                Version_Lb.Text = gameData.getVersion;
            };

        }
    }
}