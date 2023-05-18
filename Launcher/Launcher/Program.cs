using Launcher.NewFolder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
            //TODO:Add NLog

        }
        public static IServiceProvider serviceProvider { get; private set; }

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