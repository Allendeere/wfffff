using Launcher.NewFolder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {           

            ApplicationConfiguration.Initialize();


            var host = CreatHostBuilder().Build();
            serviceProvider = host.Services;
            serviceProvider.GetRequiredService<MainForm>();

            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            UIControl uictrl = new UIControl(mainForm);

            Application.Run(mainForm);

            //TODO:Add NLog

            CreateLogger();

            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info("Launcher Start");

        }
        public static IServiceProvider serviceProvider { get; private set; } //¹w¯d

        private static void CreateLogger()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/logs/${shortdate}.log",
                Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} [${uppercase:${level}}] ${message}",
            };
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);
            LogManager.Configuration = config;
        }

        static IHostBuilder CreatHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddTransient<IServerSerice, ServerSerice>();
                services.AddTransient<MainForm>();
            });
        }
    }
}