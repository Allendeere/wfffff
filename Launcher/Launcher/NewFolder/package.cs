using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Launcher.NewFolder
{
    //結構
    public class package
    {
    }

    public class LoginResult//登入
    {
        public bool IsVerified { get; set; }
        public string Message { get; set; }
    }

    class GameData //網路載下的包
    {
        string Version;

        string Name;

        string Describe;

        bool NeedUpdate = false;


        public GameData(string version = "", string name = "", string describe = "")
        {
            Version = version;
            Name = name;
            Describe = describe;
        }

        public string getVersion { get { return Version; } }
        public string getName { get { return Name; } }
        public string getDescribe { get { return Describe; } }
        public bool NeedUpdates { get { return NeedUpdate; } set { NeedUpdate = value;  } }


    }
}
