namespace Launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
            //TODO:«Ýª`¤J
            //TODO:Add NLog
        }
    }
}