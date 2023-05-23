using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
    internal class TIFFF
    {
        private string FilePath;
        private string versionFile;
        private string gameZip;
        private string launcherExe;

        public Version localVersion;
        //TODO:Fix later

        TIFFFF tIFFFF;

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

        public TIFFF(MainForm mainForm)
        {
            this.mainForm = mainForm;

            //tIFFFF = new TIFFFF(mainForm); //測試

            Init();
        }
        /// <summary>
        /// 初始呼叫
        /// </summary>
        public void Init()
        {
            FilePath = "C:\\Users\\Administrator\\Desktop\\我的資料";
            versionFile = FilePath + "\\Version.txt";
            gameZip = Path.Combine(FilePath, "TestLauncher.zip");
            launcherExe = Path.Combine(FilePath, "TestLauncher", "Launcher.exe");

            CheckForUpdates();

            StartMain();
        }

        /// <summary>
        /// 檢查確認
        /// </summary>
        private void CheckForUpdates()
        {
            if (File.Exists(versionFile))
            {
                localVersion = new Version(File.ReadAllText(versionFile));

                mainForm.Text = "Launcher   "+"v " + localVersion.ToString();
                mainForm.LVersionlabel.Text = "v " + localVersion.ToString();

                try
                {
                    WebClient webClient = new WebClient();

                    Version onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1H0xULRZoEHp3ZwgLp_wj3lgp5TV48LIk"));
                    // Version onlineVersion = new Version(webClient.DownloadString("Version.txt"));

                    if (onlineVersion.IsDifferentThan(localVersion)) //版本檢查
                    {
                        InstallGameFiles(true, onlineVersion);
                    }
                    else
                    {
                        Status = LauncherStatus.ready;
                    }
                }
                catch (Exception ex)
                {
                    Status = LauncherStatus.failed;
                    MessageBox.Show($"Error checking for game updates: {ex}");
                }
            }
            else
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
                    _onlineVersion = new Version(webClient.DownloadString("https://drive.google.com/uc?export=download&id=1H0xULRZoEHp3ZwgLp_wj3lgp5TV48LIk"));
                }

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);
                //webClient.DownloadFileAsync(new Uri("File"), savepath);
                webClient.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1EYDo2mBAVZ3rb-D5Zlo2GQEU-GcHFv5a&confirm=t&uuid=3b7a9917-3de9-4eb3-8619-7284fc226449&at=AKKF8vzjp7NC8bA6L8QMTsaLBcSc:1684811181278"), gameZip, _onlineVersion);

            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error installing game files: {ex}");
            }
        }
        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(gameZip, FilePath + "\\TestLauncher", true); //解壓
                File.Delete(gameZip);

                File.WriteAllText(versionFile, onlineVersion);

                mainForm.Text = "Launcher   " + "v " + onlineVersion;
                mainForm.LVersionlabel.Text = "v " + onlineVersion;

                Status = LauncherStatus.ready;
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.failed;
                MessageBox.Show($"Error finishing download: {ex}");
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

                //mainForm.Close();
            }
            else if (Status == LauncherStatus.failed)
            {
                CheckForUpdates();
            }
        }




    }

    struct Version
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
