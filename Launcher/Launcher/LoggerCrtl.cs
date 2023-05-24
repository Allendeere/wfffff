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

namespace Launcher
{
    public partial class LoggerCrtl : Form
    {


        public LoggerCrtl()
        {
            InitializeComponent();
        }

        public enum Levels
        {
            info,
            warning,
            error,
            command
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
            }

            Console_showbox.Text += $"\n\r{message} \n\r";
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

                    Sand(Levels.command, "執行：" + methodName);

                }
                else
                {
                    Sand(Levels.warning, "找不到指定的方法：" + methodName);
                }

            }
            catch (Exception ex)
            {
                Sand(Levels.error, ex.ToString());
            }
        }
        void Console_Inputbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && Console_Inputbox.Text.Length>0)
            {

                if (Console_Inputbox.Text[0] == '\\') //輸入\Test
                    CommandsInput(Console_Inputbox.Text);
                else
                {
                    Sand(Levels.info, Console_Inputbox.Text);
                }

                Console_Inputbox.Text = null;
            }
        }






        public void Test()
        {
            Sand(Levels.command, " Test !!! ");
        }
    }
}
