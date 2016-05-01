namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using System.IO;

    internal class OutputLog
    {
        public OutputLog(string modFolderName, string logFileName)
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

        private static string GenerateContainingFolderPath(string modFolderName)
        {
            var path = Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), "Colossal Order");
            path = Path.Combine(path, "Cities_Skylines");
            path = Path.Combine(path, "Addons");
            path = Path.Combine(path, "Mods");
            path = Path.Combine(path, modFolderName);

            return path;
        }

        private static string GenerateFileLocationPath(string modFolderName, string logFileName)
        {
            var path = GenerateContainingFolderPath(modFolderName);
            path = Path.Combine(path, logFileName);

            return path;
        }
    }
}
