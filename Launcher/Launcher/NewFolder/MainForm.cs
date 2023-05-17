using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.NewFolder
{
    internal class MainForm : Form
    {
        public void a()//通過驗證
        {
            // 创建文本框控件
            TextBox textBox = new TextBox();

            // 设置文本框的属性
            textBox.Location = new System.Drawing.Point(200, 200);

            // 将文本框添加到窗体上
            Controls.Add(textBox);
        }
    }
}