using System.Diagnostics;


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
        #region 範本

        public void SetActivePanel(object objects, bool? isActive = null, bool? isVisible = null)
        {
            if (objects is Control obj)
            {
                if (isActive != null) obj.Enabled = (bool)isActive;
                if (isVisible != null) obj.Visible = (bool)isVisible;
            }
        }
        public void SetText(object objects, string? title = null, Color? color = null, bool? isActive = null, bool? isVisible = null, Font? font = null)
        {
            if (objects is Control obj)
            {
                if (isActive != null) obj.Enabled = (bool)isActive;
                if (isVisible != null) obj.Visible = (bool)isVisible;
                if (title != null) obj.Text = title;
                if (color != null) obj.ForeColor = (Color)color;
                if (font != null) obj.Font = (Font)font;
            }
        } 
        #endregion


        public void ChecklocalGame(string gamename) //到時候會在遊戲下載時新建一個_gamename的資料夾
        {
            var gamepath = $"{ UpdateRelated.FilePath}\\{gamename}\\{gamename}.exe  ";

            if (File.Exists(gamepath))
                Process.Start(gamepath);

            else
            {
                MessageBox.Show(gamepath + "路徑或執行檔不存在");
            }
        }
        /// <summary>
        /// 路徑檢查
        /// </summary>
        public bool Pathcheck(TextBox path)
        {
            if (MessageBox.Show("你所設定的路徑不存在 \n\r" + path.Text + "\n\r 是否還原預設路徑", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                path.Text = Properties.Settings.Default.localFilePath;

                return false;
            }
            else
            {
                return true;
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
