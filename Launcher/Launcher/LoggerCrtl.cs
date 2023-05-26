using Launcher.NewFolder;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Launcher
{
    public partial class LoggerCrtl : Form
    {

        UIControl uic;

        public LoggerCrtl(UIControl uIControl)
        {
            uic = uIControl;
            InitializeComponent();
        }

        public enum Levels
        {
            info,
            warning,
            error,
            command,
            user,
            help
        }



        public void Sand(Levels levels, string message)
        {
            switch (levels)
            {
                case Levels.info:
                    message = "【 Info 】" + message;
                    break;
                case Levels.warning:
                    message = "【 warning 】" + message;
                    break;
                case Levels.error:
                    message = "【 error 】" + message;
                    break;
                case Levels.command:
                    message = "▶ command ◀" + message;
                    break;
                case Levels.user:
                    message = " 🐵 : " + message;
                    break;
                case Levels.help:
                    message = " " + message;
                    break;
            }

            Console_showbox.Text += $"\n\r{message} \n\r";

            //main
            uic.mainForm.Console_showbox_main.Text += $"\n\r{message} \n\r";
        }

        public void CommandsInput(string methodName)
        {
            try
            {
                methodName = methodName.Substring(1);

                Type mainType = typeof(LoggerCrtl);

                MethodInfo methodInfo = mainType.GetMethod(methodName);

                if (methodInfo != null)
                {
                    // 呼叫該方法
                    methodInfo.Invoke(this, null);

                }
                else
                {
                    Sand(Levels.warning, "找不到指定的方法：" + methodName);
                }

            }
            catch (Exception ex)
            {
                Sand(Levels.error, ex.Message);
            }
        }
        void Console_Inputbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && Console_Inputbox.Text.Length>0)
            {

                if (Console_Inputbox.Text[0] == '/') //輸入\Test
                    CommandsInput(Console_Inputbox.Text);

                else if (Console_Inputbox.Text[0] == '!') //輸入 !download path!get
                {
                    var Tests = Console_Inputbox.Text.Split('!');
                    if (Tests[1] == "download path")
                    {
                        if (Tests[2] == "get") 
                        {

                        }
                        else if (Tests[2] == "set") 
                        {
                            uic.updateRelated.Setfilepaht(Tests[2]);
                        }
                        Sand(Levels.command, uic.updateRelated.Getfilepaht());
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
                                uic.updateRelated.SetVersionurl(Tests[4]);
                            }
                            Sand(Levels.command, uic.updateRelated.GetVersionurl());
                        }
                        else if (Tests[2] == "zip")  //!download url!zip!get
                        {
                            if (Tests[3] == "get")
                            {

                            }
                            else if (Tests[3] == "set")
                            {
                                uic.updateRelated.Setzipurl(Tests[4]);
                            }
                            Sand(Levels.command, uic.updateRelated.Getzipurl());
                        }
                    }
                }
                else
                {
                    Sand(Levels.user, Console_Inputbox.Text);
                }

                Console_Inputbox.Text = null;
            }
        }





        #region Commands

        public void help()
        {
            Sand(Levels.command, "");
            Sand(Levels.help, "管理身分 :     /admin     /unadmin");
            Sand(Levels.help, "測試     :         /addgame");
            Sand(Levels.help, "TextBox  :     /clear");
            Sand(Levels.help, "下載相關 :     !download path!     !download url!");

        }
        public void admin()
        {
            Sand(Levels.command, " 啟動管理員模式 ! ");

            uic.judgment.isAdmin = true;
        }
        public void unadmin()
        {
            Sand(Levels.command, " 關閉管理員模式 ! ");

            uic.judgment.isAdmin = false;
        }
        public void clear()
        {
            Console_showbox.Text = null;

            uic.mainForm.Console_showbox_main.Text= null;

            Sand(Levels.command, " 🧹 🧹 🧹 ");
        }
        public void addgame()
        {

            Random random = new Random();

            var GameName = "TestLauncher";

            var GameVersion = $"v {random.Next(0, 9)}.{random.Next(0, 9)}.{random.Next(0, 9)}";

            var Detail = "-----\n\r- -- -- \n\r--\n\r-- - ---- -- -\n\r----- 。";

            uic.GameInfo.Add(GameName, new GameData(GameVersion, GameName, Detail));

            Sand(Levels.command, $" 添加遊戲 {GameName} !");

        }
        #endregion
    }
}
