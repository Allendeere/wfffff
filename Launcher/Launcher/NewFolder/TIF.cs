using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.NewFolder//TODO:待改介面
{
    internal class TIF
    {
        //Launcher 是否正在更新中
        static bool Updating = false;

        /// <summary>
        /// Launcher數量檢查
        /// </summary>
        public void OnlyOneProcess()
        {
            Process current = Process.GetCurrentProcess();

            foreach (var process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    process.Kill();
                    continue;
                }
            }
        }

        /// <summary>
        /// 自動安裝 Launcher
        /// </summary>
        private static void InstallLauncher()
        {
            string directory = @"C:\VAR";
            ProcessStartInfo Info2 = new ProcessStartInfo();
            Info2.FileName = "update.bat";
            Info2.WorkingDirectory = directory;
            Info2.Verb = "runas";
            Process.Start(Info2);
            Updating = false;
        }

    }
}
