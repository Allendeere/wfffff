﻿using System.Diagnostics;


namespace Launcher.NewFolder
{
    public class FrontEndJudgment
    {

        public bool isAdmin;//TODO 到時候改成直接接包裡的東西，這個就能刪了

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

            //Maffin(); //等

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))//空白檢查(暫時)
            {
                result.IsVerified = false;
                result.Message = "Login verification failed.";
            }
            else
            {
                result.IsVerified = true;
                result.Message = "Login success!";

                if (isAdmin) //傳回來的東西
                {
                    result.IsAdmin = isAdmin;
                }
            }
            return result;
        }

        static async Task Maffin()
        {
            // 建立 HttpClient 實例
            HttpClient client = new HttpClient();

            // 發送 HTTP 請求並等待回應
            HttpResponseMessage response = await client.GetAsync("https://api.example.com/data");

            // 檢查回應狀態碼
            if (response.IsSuccessStatusCode)
            {
                // 讀取回應內容
                string content = await response.Content.ReadAsStringAsync();

                // 在此處理回應內容或進行其他操作
                Console.WriteLine("HTTP 請求成功");
                Console.WriteLine("回應內容: " + content);
            }
            else
            {
                Console.WriteLine("HTTP 請求失敗");
            }

            // 繼續執行其他程式碼
            Console.WriteLine("繼續執行其他操作");
        }

        #endregion
    }

    
}