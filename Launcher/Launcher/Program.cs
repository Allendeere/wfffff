namespace Launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
            //TODO:�ݪ`�J
            //TODO:Add NLog
        }
    }
}