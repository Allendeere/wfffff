using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Launcher.NewFolder//TODO:待改介面
{
    public class TIF
    {
       public MainForm mainForm;

        public TIF(MainForm mainForm)
        {
            this.mainForm = mainForm;
            OnlyOneProcess();
        }


        #region 登入器相關
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

        #endregion

        #region UpdateChecks
        public void UpdateCheck(object obj)//範本
        {
            if (obj is GameData gt)
            {
                //如果不需要 ...
                return;

                //如果需要更新 ...
                gt.NeedUpdates = true;
            }
        }

        public void UpdateCheck(object obj, bool b)//測試專用
        {
            if (obj is GameData gt)
            {

                //如果不需要 ...
                if (!b) return;

                //如果需要更新 ...
                gt.NeedUpdates = true;

                MessageBox.Show($"偵測到一筆新的新版本，是否進行更新 \n\r遊戲名稱:{gt.getName} \n\r當前版本:{gt.getVersion} \n\r最新版本:9.9.9 ", "更新提示", MessageBoxButtons.YesNoCancel);

            }

        }

        #endregion

        #region 登入與驗證
        /// <summary>
        /// 身分認證
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public bool VerifyIdentity(string verify) => !string.IsNullOrEmpty(verify);

        /// <summary>
        /// 帳號認證
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginResult LoginVerification(string username, string password)
        {
            LoginResult result = new LoginResult();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))//空白檢查
            {
                result.IsVerified = false;
                result.Message = "Login verification failed.";

                MessageBox.Show(result.Message);
            }
            else
            {
                result.IsVerified = true;
                result.Message = "Login success!";
            }

            return result;
        } 
        #endregion
    }
}
