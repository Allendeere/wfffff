using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;

namespace Launcher.NewFolder
{
    enum LauncherStatus
    {
        ready,
        failed,
        downloadingGame,
        downloadingUpdate
    }


    /// <summary>
    /// 測試專用:P
    /// </summary>
    public class UpdateRelated
    {
        private static string FilePath;

        private string versionFile;

        private string gameZip;

        private string launcherExe;

        private static string launcherVersionURL;//Version.txt

        private static string launcherZIPURL;


        public Version localVersion;


        #region Console用

        public Func<string> Getfilepaht = () => FilePath;
        public void Setfilepaht(string s) => FilePath = s;

        public Func<string> GetVersionurl = () => launcherVersionURL;
        public void SetVersionurl(string s) => launcherVersionURL = s;

        public Func<string> Getzipurl = () => launcherZIPURL;
        public void Setzipurl(string s) => launcherZIPURL = s;
        #endregion
        //TIFFFF tIFFFF;

        MainForm mainForm;

        private LauncherStatus _status;
        internal LauncherStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case LauncherStatus.ready:
                        break;
                    case LauncherStatus.failed:
                        break;
                    case LauncherStatus.downloadingGame:
                        break;
                    case LauncherStatus.downloadingUpdate:
                        break;
                    default:
                        break;
                }
            }
        }

        public UpdateRelated(MainForm mainForm)
        {
            this.mainForm = mainForm;

            Init();
        }
        /// <summary>
        /// 初始
        /// </summary>
        public void Init()
        {
            FilePath = Properties.Settings.Default.localFilePath;
            versionFile = FilePath + "\\Version.txt";
            gameZip = Path.Combine(FilePath, "TestLauncher.zip");
            launcherExe = Path.Combine(FilePath, "TestLauncher", "Launcher.exe");

            launcherVersionURL = "https://drive.google.com/uc?export=download&id=1H0xULRZoEHp3ZwgLp_wj3lgp5TV48LIk";
            launcherZIPURL = "https://drive.google.com/uc?export=download&id=1yLxCNfGclJ_andbU5Wbbxeqzud3HM6UF";


            if (Directory.Exists(FilePath))
            {
                try
                {
                    //檔案檢查
                    if (!Directory.Exists(FilePath + "\\backup"))
                    {
                        Directory.CreateDirectory(FilePath + "\\backup");
                    }
                    if (!File.Exists(versionFile))
                    {
                        System.IO.File.WriteAllText(versionFile, "1.1.1");
                    }
                    if (!Directory.Exists(FilePath + "\\TestLauncher"))
                    {
                        Directory.CreateDirectory(FilePath + "\\TestLauncher");
                    }

                }
                catch (Exception)
                {

                }
            }

            CheckForUpdates(true);

            if (Properties.Settings.Default.AutoUpdate)
                StartMain();
        }

        /// <summary>
        /// 版本檢查
        /// </summary>
        public void CheckForUpdates(bool isAutoTrigger)
        {
            if (File.Exists(versionFile))
            {
                localVersion = new Version(File.ReadAllText(versionFile));

                mainForm.Text = "Launcher   " + "v " + localVersion.ToString();
                mainForm.LVersionlabel.Text = "v " + localVersion.ToString();

                try
                {
                    WebClient webClient = new WebClient();


                    Version onlineVersion = new Version(webClient.DownloadString(launcherVersionURL));//Version.txt

                    if (onlineVersion.IsDifferentThan(localVersion)) //版本不同
                    {
                        if (isAutoTrigger && !Properties.Settings.Default.AutoUpdate)
                        {
                            mainForm.uictrl.SetActivePanel(mainForm.Update_btn, true, true);
                        }
                        else
                        {
                            InstallGameFiles(true, onlineVersion);
                        }

                    }
                    else
                    {
                        Status = LauncherStatus.ready;
                    }
                }
                catch (Exception ex)
                {
                    Status = LauncherStatus.failed;
                    MessageBox.Show($"檢查遊戲更新時出錯: {ex.Message}");
                }
            }
            else //versionFile不存在
            {
                InstallGameFiles(false, Version.zero);
            }
        }
        /// <summary>
        /// 下載
        /// </summary>
        /// <param name="_isUpdate"></param>
        /// <param name="_onlineVersion"></param>
        private void InstallGameFiles(bool _isUpdate, Version _onlineVersion)
        {
            try
            {
                WebClient webClient = new WebClient();
                if (_isUpdate)
                {
                    Status = LauncherStatus.downloadingUpdate;
                }
                else
                {
                    Status = LauncherStatus.downloadingGame;
                    _onlineVersion = new Version(webClient.DownloadString(launcherVersionURL));
                }

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);

                //webClient.DownloadFileAsync(new Uri("File"), savepath);
                webClient.DownloadFileAsync(new Uri(launcherZIPURL), gameZip, _onlineVersion);

            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"安裝遊戲時出錯: {ex.Message}");
            }
        }
        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                //比對前後版本差異

                if (File.Exists(Path.Combine(FilePath + "\\backup", "TestLauncher.zip")))
                {
                    if (CompareZipFiles(Path.Combine(FilePath + "\\backup", "TestLauncher.zip"), gameZip)) //檔案如果一樣
                    {
                        if (File.Exists(gameZip)) File.Delete(gameZip);

                        MessageBox.Show("更新失敗，新舊檔案並無變化");

                        return;
                    }
                }

                File.Copy(gameZip, Path.Combine(FilePath + "\\backup", "TestLauncher.zip"), true);//新檔案複寫至backup

                //沒問題則解壓縮取代
                string onlineVersion = ((Version)e.UserState).ToString();

                ZipFile.ExtractToDirectory(gameZip, FilePath + "\\TestLauncher", true); //解壓

                File.Delete(gameZip);

                File.WriteAllText(versionFile, onlineVersion);

                mainForm.Text = "Launcher   " + "v " + onlineVersion;

                mainForm.LVersionlabel.Text = "v " + onlineVersion;

                Status = LauncherStatus.ready;

                if (MessageBox.Show("是否自動重新開啟", "更新完成", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    StartMain();
                }

            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;

                MessageBox.Show($"下載完成時出錯 : {ex.Message}");
            }
        }
        private void StartMain()
        {

            if (File.Exists(launcherExe) && Status == LauncherStatus.ready)
            {
                //執行遊戲
                ProcessStartInfo startInfo = new ProcessStartInfo(launcherExe);

                startInfo.WorkingDirectory = Path.Combine(FilePath, "TestLauncher");

                startInfo.UseShellExecute = true;

                Process.Start(startInfo); //TODO: 目前是測試檔案，要替還成Launcher Path !!

                mainForm.Close();
            }
            else if (Status == LauncherStatus.failed)
            {
                CheckForUpdates(false);
            }
        }



        #region 比對檔案內容
        public static bool CompareZipFiles(string zipFilePath1, string zipFilePath2)
        {
            // 解壓縮第一個壓縮檔案
            var tempDir1 = ExtractZipFile(zipFilePath1);

            // 解壓縮第二個壓縮檔案
            var tempDir2 = ExtractZipFile(zipFilePath2);

            // 比對兩個解壓縮後的資料夾結構
            var areFoldersEqual = CompareFolders(tempDir1, tempDir2);

            // 刪除臨時資料夾
            Directory.Delete(tempDir1, true);
            Directory.Delete(tempDir2, true);

            return areFoldersEqual;
        }

        private static string ExtractZipFile(string zipFilePath)
        {
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            ZipFile.ExtractToDirectory(zipFilePath, tempDir);

            return tempDir;
        }

        private static bool CompareFolders(string folderPath1, string folderPath2)
        {
            var files1 = Directory.GetFiles(folderPath1);
            var files2 = Directory.GetFiles(folderPath2);

            if (files1.Length != files2.Length)
            {
                return false;
            }

            // 比對每個檔案的大小和雜湊值
            for (int i = 0; i < files1.Length; i++)
            {
                var file1 = files1[i];
                var file2 = files2[i];

                var fileSize1 = new FileInfo(file1).Length;
                var fileSize2 = new FileInfo(file2).Length;

                if (fileSize1 != fileSize2)
                {
                    return false;
                }

                var hash1 = GetFileHash(file1);
                var hash2 = GetFileHash(file2);

                if (hash1 != hash2)
                {
                    return false;
                }
            }

            return true;
        }

        private static string GetFileHash(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hashAlgorithm = SHA1.Create();
                var hashBytes = hashAlgorithm.ComputeHash(stream);
                return Convert.ToBase64String(hashBytes);
            }
        }
        #endregion

    }

    public struct Version
    {
        internal static Version zero = new Version(0, 0, 0);

        private short major;
        private short minor;
        private short subMinor;

        internal Version(short _major, short _minor, short _subMinor)
        {
            major = _major;
            minor = _minor;
            subMinor = _subMinor;
        }
        internal Version(string _version)
        {
            string[] versionStrings = _version.Split('.');
            if (versionStrings.Length != 3)
            {
                major = 0;
                minor = 0;
                subMinor = 0;
                return;
            }

            major = short.Parse(versionStrings[0]);
            minor = short.Parse(versionStrings[1]);
            subMinor = short.Parse(versionStrings[2]);
        }

        internal bool IsDifferentThan(Version _otherVersion)
        {
            if (major != _otherVersion.major)
            {
                return true;
            }
            else
            {
                if (minor != _otherVersion.minor)
                {
                    return true;
                }
                else
                {
                    if (subMinor != _otherVersion.subMinor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{subMinor}";
        }
    }

}
