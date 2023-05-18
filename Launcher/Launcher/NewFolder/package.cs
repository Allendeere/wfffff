using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Launcher.NewFolder
{
    public class package
    {
    }

     class GameData //網路載下的包
    {
        string Version;

        string Name;

        string Describe;

        public GameData(string version = "", string name = "", string describe = "")
        {
            Version = version;
            Name = name;
            Describe = describe;
        }

        public string getVersion { get { return Version; } }
        public string getName { get { return Name; } }
        public string getDescribe { get { return Describe; } }


    }
}
