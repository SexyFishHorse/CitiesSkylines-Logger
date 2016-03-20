namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using System.Linq;
    using ColossalFramework.Plugins;

    public class Logger : ILogger
    {
        private readonly OutputLog outputLog;

        /// <summary>
        /// Creates a new instance of the logger.
        /// Note that multiple loggers with the same mod folder name and filename may cause errors during concurrent writes.
        /// </summary>
        /// <param name="modFolderName">The name of the folder for the mod in %LocalAppData%\Colossal Order\Cities_Skylines\Mods. I.e. "my-mod"</param>
        /// <param name="fileName">The name of the log file in the modFolderName folder. I.e. "my-output-log.xml"</param>
        public Logger(string modFolderName, string fileName)
        {
            outputLog = new OutputLog(modFolderName, fileName);
        }

        /// <summary>
        /// Indicates if messages should be sent to the games built in debug panel (Errors will always be displayed)
        /// </summary>
        public bool LogToOutputPanel { get; set; }

        /// <summary>
        /// Indicates if messages should be stored in a file
        /// </summary>
        public bool LogToFile { get; set; }

        public void Log(string message)
        {
            LogFormat(message);
        }

        public void LogFormat(string message, params object[] arg0)
        {
            AddRaw(PluginManager.MessageType.Message, message, arg0);
        }

        public void Error(string message)
        {
            ErrorFormat(message);
        }

        public void ErrorFormat(string message, params object[] arg0)
        {
            AddRaw(PluginManager.MessageType.Error, message);
        }

        public void Warn(string message)
        {
            WarnFormat(message);
        }

        public void WarnFormat(string message, params object[] arg0)
        {
            AddRaw(PluginManager.MessageType.Warning, message);
        }

        private void AddRaw(PluginManager.MessageType messageType, string message, params object[] arg0)
        {
            if (arg0.Any())
            {
                message = string.Format(message, arg0);
            }

            if (LogToOutputPanel || messageType == PluginManager.MessageType.Error)
            {
                DebugOutputPanel.AddMessage(messageType, string.Format("[Chirpy in a Cage][{0}]: {1}", DateTime.Now.ToString("HH:mm:ss"), message));
            }

            if (LogToFile)
            {
                outputLog.Write(message);
            }
        }
    }
}
