using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.NewFolder
{
    public class TIFF
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

        #region 登入與驗證(判斷)
        /// <summary>
        /// 驗證 >> 身分認證
        /// </summary>
        /// <param name="verify"></param>
        /// <returns></returns>
        public bool VerifyIdentity(string verify)
        {
            
            return !string.IsNullOrEmpty(verify);
        }

        /// <summary>
        /// 登入 >> 帳號認證
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public LoginResult LoginVerification(string username, string password)
        {
            LoginResult result = new LoginResult();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))//空白檢查(暫時)
            {
                result.IsVerified = false;
                result.Message = "Login verification failed.";
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
