using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Launcher.NewFolder
{
    //結構
    public class package { }

    class SystemInformationPage //頁面二
    {
        static SystemInformationPage systemInformationPage;

        static readonly object _lock = new object();
        public TabPage SystemInformation { get; set; }
        public Panel panel2 { get; set; }
        public FlowLayoutPanel flowLayoutPanel1 { get; set; }
        public Panel panel1 { get; set; }
        public Label labellauncher { get; set; }
        public Label GameName_Lb { get; set; }
        public Label Detail_Lb { get; set; }
        public Button LoadGame_Btn { get; set; }
        public Panel SystemInformationpanel1 { get; set; }

        public Label labellauncherv { get; set; }

        SystemInformationPage() { }

        public static SystemInformationPage Create()
        {
            if (systemInformationPage == null)
            {
                lock (_lock)
                {
                    systemInformationPage = new SystemInformationPage();
                }
            }
            return systemInformationPage;
        }

    }

    public class LoginResult//登入
    {
        public bool IsVerified { get; set; }
        public bool IsAdmin { get; set; }
        public string Message { get; set; }
    }

    class GameData //網路載下的包
    {
        string Version;

        string Name;

        string Describe;

        bool NeedUpdate = false;


        public GameData(string version = "", string name = "", string? describe = " :DD ")
        {
            Version = version;
            Name = name;
            Describe = describe;
        }

        public string getVersion { get { return Version; } }
        public string getName { get { return Name; } }
        public string getDescribe { get { return Describe; } }
        public bool NeedUpdates { get { return NeedUpdate; } set { NeedUpdate = value; } }

    }
}
