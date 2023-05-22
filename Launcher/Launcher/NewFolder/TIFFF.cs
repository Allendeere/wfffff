using Launcher.NewFolder2;
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

        //TODO:Fix later


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
            Init();
        }
        /// <summary>
        /// 初始呼叫
        /// </summary>
        public void Init()
        {
            //TODO:Fix later
            FilePath = "C:\\LauncherTest";
            versionFile = FilePath + "\\Version.txt";
            gameZip = Path.Combine(FilePath, "Build.zip");
            //gameExe = Path.Combine(rootPath, "Build", "VAR Box Launcher.exe");
            launcherExe = Path.Combine("C:\\Users\\Administrator\\Documents\\GitHub\\wfffff\\Launcher\\Launcher\\bin\\Debug\\net6.0-windows\\Launcher.exe");

            //string exe = "\"C:\\Program Files\\VAR Box Launcher\\VAR Box Launcher.exe\"";

            //savepath = Path.Combine("C:\\VAR", "LauncherInstaller.msi");

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
                Version localVersion = new Version(File.ReadAllText(versionFile));
                mainForm.Text = localVersion.ToString();

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
                webClient.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1ZelkvL0uObNdndCJW7XVuhVmrVD0Jhgz"), gameZip, _onlineVersion);

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
                ZipFile.ExtractToDirectory(gameZip, FilePath, true);
                File.Delete(gameZip);

                File.WriteAllText(versionFile, onlineVersion);

                mainForm.Text = onlineVersion;
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
                startInfo.WorkingDirectory = Path.Combine("C:\\Users\\Administrator\\Documents\\GitHub\\wfffff\\Launcher\\Launcher\\bin\\Debug", "net6.0-windows");
                //startInfo.WorkingDirectory = Path.Combine(FilePath, "Build");
                Process.Start(startInfo); //TODO: 目前是測試檔案，要替還成Launcher Path !!

                mainForm.Close();
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
