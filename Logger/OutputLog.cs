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

        public string LogFileName { get; private set; }

        public void ClearLog()
        {
            File.Delete(FileLocation);
        }

        public void Log(string message)
        {
            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format("[{0}][Message]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
                file.WriteLine(message);
            }
        }

        public void LogFormat(string message, params object[] arg0)
        {

            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format(message, arg0);
                message = string.Format("[{0}][Message]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
                file.WriteLine(message);
            }
        }

        public void Error(string message)
        {
            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format("[{0}][ERROR]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
                file.WriteLine(message);
            }
        }

        public void ErrorFormat(string message, params object[] arg0)
        {

            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format(message, arg0);
                message = string.Format("[{0}][ERROR]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
                file.WriteLine(message);
            }
        }

        public void Warn(string message)
        {
            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format("[{0}][Warning]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
                file.WriteLine(message);
            }
        }

        public void WarnFormat(string message, params object[] arg0)
        {

            using (var file = File.AppendText(FileLocation))
            {
                message = string.Format(message, arg0);
                message = string.Format("[{0}][Warning]: {1}", DateTime.Now.ToString("HH:mm:ss"), message);
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
