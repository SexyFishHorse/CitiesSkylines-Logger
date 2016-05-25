namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using System.IO;

    internal class LogFile
    {
        public LogFile(string modFolderName, string logFileName)
        {
            FileLocation = GenerateFileLocationPath(modFolderName, logFileName);
        }

        public string FileLocation { get; private set; }

        public void ClearLog()
        {
            File.Delete(FileLocation);
        }

        public void Write(string message)
        {
            using (var file = File.AppendText(FileLocation))
            {
                file.WriteLine(message);
            }
        }

        private static string GenerateFileLocationPath(string modFolderName, string logFileName)
        {
            var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var path = Path.Combine(localAppData, "Colossal Order");
            path = Path.Combine(path, "Cities_Skylines");
            path = Path.Combine(path, "Addons");
            path = Path.Combine(path, "Mods");
            path = Path.Combine(path, modFolderName);
            path = Path.Combine(path, logFileName);

            return path;
        }
    }
}
