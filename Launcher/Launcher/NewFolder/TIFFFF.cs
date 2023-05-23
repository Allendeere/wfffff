using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Launcher.NewFolder
{
    public class launcher_min_version_receive
    {
        public bool success;
        public string code;
        public bool need_update;
        public string min_version { get; set; }
        public string path { get; set; }
    }
    public class download_info
    {
        public string url;
        public string savepath;
        public string login = null;
        public string password = null;
    }
    public class launcher_min_version_request
    {
        public string launcher_version;
    }
    class Downloader
    {
        private List<download_info> download_Infos = new List<download_info>();
        public static Dictionary<download_info, List<Action<string, string>>> DownloadCompletedActionHandlers = new Dictionary<download_info, List<Action<string, string>>>();

        public void AddDownloadList(download_info download_Info)
        {
            download_Infos.Add(download_Info);
        }

        public void RegisterDownloadCompleted(download_info RespondCode, Action<string, string> callback)
        {
            List<Action<string, string>> _HandlerList;
            if (!DownloadCompletedActionHandlers.TryGetValue(RespondCode, out _HandlerList))
            {
                _HandlerList = new List<Action<string, string>>();
                DownloadCompletedActionHandlers.Add(RespondCode, _HandlerList);
            }

            if (!_HandlerList.Contains(callback))
            {
                _HandlerList.Add(callback);
            }
        }

        public void DownloadFile(Action<download_info> OnDownloadDone = null, Action<double> OnProgressValue = null)
        {
            if (download_Infos.Any())
            {
                WebClient client = new WebClient();
                var download_Info = download_Infos[0];

                if (!string.IsNullOrEmpty(download_Info.login) && !string.IsNullOrEmpty(download_Info.password))
                {
                    client.Credentials = new NetworkCredential(download_Info.login, download_Info.password);
                }
                client.DownloadFileAsync(new Uri(download_Info.url), download_Info.savepath);
            }
        }

        public AsyncCompletedEventHandler DownloadFileCompleted(download_info download_Info, Action<double> OnProgressValue = null)
        {
            Action<object, AsyncCompletedEventArgs> action = (sender, e) =>
            {
                var _url = download_Info.url;
                var path = Path.GetDirectoryName(download_Info.savepath);
                if (e.Error != null)
                {
                    return;
                }
                download_Infos.Remove(download_Info);
                DownloadFile();
                OnProgressValue?.Invoke(1.0f);
                TriggerCallback(download_Info, download_Info.savepath, path);
            };
            return new AsyncCompletedEventHandler(action);
        }
        private void TriggerCallback(download_info download_Info, string f, string p)
        {
            var _Callbacks = GetCallbacks(download_Info);
            if (_Callbacks != null)
            {
                foreach (var _Callback in _Callbacks)
                    _Callback.Invoke(f, p);
            }
        }
        private List<Action<string, string>> GetCallbacks(download_info msgType)
        {
            List<Action<string, string>> _HandlerList;

            if (!DownloadCompletedActionHandlers.TryGetValue(msgType, out _HandlerList))
                return null;

            return _HandlerList;
        }



    }


    internal class TIFFFF
    {

        public enum Server { aws, local, dev, other };

        public static Server server = Server.aws;

        string launcherExe;

        public static Action<string> Forbidden;

        //暫存資料夾
        public static string HoldingPath = "C:\\VAR Live\\Holding\\";

        public MainForm mainForm;

        private string FilePath = "C:\\Users\\Administrator\\Desktop\\我的資料";

        bool Updating;
        public TIFFFF(MainForm mainForm)
        {
            this.mainForm = mainForm;

            Init();
        }
        public void Init()
        {
            launcherExe = Path.Combine(FilePath, "TestLauncher", "Launcher.exe");

            Argssetting();//帶入參數的相關設定

            CheckLauncherMinVersion(); ///Launcher版本更新檢查
        }



        /// <summary>
        /// 設定 server type 跟 holding 路徑
        /// </summary>
        /// <param name="args"></param>
        private static void Argssetting()
        {
            string server_type = "aws";


            switch (server_type.ToLower())
            {
                case "local":
                    server = Server.local;
                    HoldingPath = "C:\\VAR Live\\Holding_dev\\";
                    break;
                case "aws":
                    server = Server.aws;
                    HoldingPath = "C:\\VAR Live\\Holding\\";
                    break;
                case "dev":
                    server = Server.dev;
                    HoldingPath = "C:\\VAR Live\\Holding_dev\\";
                    break;
                default:
                    server = Server.other;
                    HoldingPath = "C:\\VAR Live\\Holding\\";
                    break;
            }
        }











        #region 版本檢查

        public void CheckLauncherMinVersion()//版本檢查入口
        {
            //Launcher更新檢查
            if (LauncherMinVersion())
            {
                while (Updating) { Thread.Sleep(1000); }

                Updating = false;

                ProcessStartInfo startInfo = new ProcessStartInfo(launcherExe);

                startInfo.WorkingDirectory = Path.Combine(FilePath, "TestLauncher");

                startInfo.UseShellExecute = true;

                Process.Start(startInfo);

                mainForm.Close();
            }
        }

        /// <summary>
        /// 檢查launcher最低版本後順便更新
        /// </summary>
        bool LauncherMinVersion()
        {
            string directory = @"C:\\VAR";
            //string launcher_path = @"C:\Program Files (x86)\VAR Box Launcher\VAR Box Launcher.exe";
            Directory.CreateDirectory(directory);
            launcher_min_version_request launcher_Update_Request = new launcher_min_version_request() { launcher_version = GetVersion().ToString() };
            launcher_min_version_receive recevie = Send<launcher_min_version_receive>("https://pd-opms.varlivebox.com/pyapi/api/v1/launcher_min_version", launcher_Update_Request);
            if (recevie.success)
            {

                Updating = recevie.need_update;
                if (!recevie.need_update) { }

                string fileName = Path.GetFileName(recevie.path);
                Downloader LauncherDownloader = new Downloader();
                download_info download_Info = new download_info()
                {
                    url = recevie.path,
                    savepath = Path.Combine(directory, "LauncherInstaller.msi")
                };
                if (File.Exists(download_Info.savepath))
                {
                    File.Delete(download_Info.savepath);
                }
                CopyBat(@"Bat\update.bat", Path.Combine(directory, "update.bat"));

                LauncherDownloader.AddDownloadList(download_Info);
                LauncherDownloader.RegisterDownloadCompleted(download_Info, (string s, string p) => InstallLauncher());
                LauncherDownloader.RegisterDownloadCompleted(download_Info, (string s, string p) => Updating = false);

                LauncherDownloader.DownloadFile(null);
            }
            return recevie.need_update;
        }

        /// <summary>
        /// 自動安裝 Launcher
        /// </summary>
        private void InstallLauncher()
        {
            string directory = @"C:\VAR";
            ProcessStartInfo Info2 = new ProcessStartInfo();
            Info2.FileName = "update.bat";
            Info2.WorkingDirectory = directory;
            Info2.Verb = "runas";
            Process.Start(Info2);
            Updating = false;
        }


        /// <summary>
        /// 複製批次檔
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="TagetPath"></param>
        private static void CopyBat(string FilePath, string TagetPath)
        {
            if (!File.Exists(FilePath))
            {
                //Logger.Warning("Bat doesn't exists");
                return;
            }

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string exe = "\"C:\\Program Files\\VAR Box Launcher\\VAR Box Launcher.exe\"";
                for (int i = 1; i < args.Length; i++)
                {
                    exe += " " + args[i];
                }

                string bat = File.ReadAllText(FilePath);
                bat = bat.Replace("\"C:\\Program Files\\VAR Box Launcher\\VAR Box Launcher.exe\"", exe);

                File.WriteAllText(TagetPath, bat);
            }
            else
            {
                File.Copy(FilePath, TagetPath, true);
            }
        }

        /// <summary>
        /// Launcher版號
        /// </summary>
        /// <returns></returns>
        public static System.Version GetVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }

        public static string Send(string url, string jsonstring, string method = "POST", Action<string, string, string> TimeOutAction = null)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //創建請求 

                request.AllowAutoRedirect = true;
                //request.AllowReadStreamBuffering = true;
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.MaximumResponseHeadersLength = 1024;
                request.ContentType = "application/json";
                if (method.ToUpper() == "GET" || method.ToUpper() == "DELETE")
                {

                }
                else
                {
                    Stream postStream = request.GetRequestStream();
                    byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonstring);
                    postStream.Write(jsonbyte, 0, jsonbyte.Length);
                    postStream.Close();
                }
                //發送請求並獲取相應迴應數據
                HttpWebResponse res;
                try
                {
                    res = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                    if (string.IsNullOrEmpty(jsonstring))
                    {
                        //Logger.Error("http error :" + url + "\r\n" + ex.Message);
                    }
                    else
                    {
                        // Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
                    }
                    if (TimeOutAction != null) TimeOutAction.Invoke(url, jsonstring, method);
                    return null;
                }
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd(); //獲得響應字符串  
                if (res.StatusCode == HttpStatusCode.Forbidden)
                {
                    try
                    {
                        if (Forbidden != null) Forbidden.Invoke(content);
                    }
                    catch
                    {

                    }
                }

                res.Close();
                return content;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(jsonstring))
                {
                    //Logger.Error("http error :" + url + "\r\n" + ex.Message);
                }
                else
                {
                    //Logger.Error("http error :" + url + "\r\n" + jsonstring + "\r\n" + ex.Message);
                }

                if (ex is WebException && TimeOutAction != null)
                {
                    TimeOutAction.Invoke(url, jsonstring, method);
                }
                return "";
            }
        }
        public static T Send<T>(string url, object obj, string method = "POST", Action<string, string, string> TimeOutAction = null) where T : new()
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string message = Send(url, json, method, TimeOutAction);
            if (IsValidJson<T>(message))
            {
                T _obj = JsonConvert.DeserializeObject<T>(message);
                return _obj;
            }
            return new T();
        }
        public static bool IsValidJson<T>(string strInput)
        {
            if (string.IsNullOrEmpty(strInput))
                return false;
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(strInput);
                return true;
            }
            catch (Exception e) // not valid
            {
                //if (server == Server.dev)
                return false;
            }
        } 
        #endregion
    }
}

