namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using System.Linq;
    using ColossalFramework.Plugins;

    public class Logger : ILogger
    {
        private readonly OutputLog outputLog;
        private readonly string modFolderName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Note that multiple loggers with the same mod folder name and filename may cause errors during concurrent writes.
        /// </summary>
        /// <param name="modFolderName">The name of the folder for the mod in %LocalAppData%\Colossal Order\Cities_Skylines\Mods. I.e. "my-mod"</param>
        /// <param name="fileName">The name of the log file in the modFolderName folder. I.e. "my-output-log.xml"</param>
        /// <param name="clearLogFile">Indicates if the log file should be cleared when a new logger instance is created</param>
        public Logger(string modFolderName, string fileName, bool clearLogFile)
        {
            this.modFolderName = modFolderName;
            outputLog = new OutputLog(modFolderName, fileName);

            if (clearLogFile)
            {
                outputLog.ClearLog();
                Log("Log file cleared");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether messages should be sent to the games built in debug panel or not (Errors will always be displayed)
        /// </summary>
        public bool LogToOutputPanel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether messages should be stored in a file or not
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
            AddRaw(PluginManager.MessageType.Error, message, arg0);
        }

        public void Warn(string message)
        {
            WarnFormat(message);
        }

        public void WarnFormat(string message, params object[] arg0)
        {
            AddRaw(PluginManager.MessageType.Warning, message, arg0);
        }

        public void LogException(Exception ex)
        {
            ErrorFormat("Type: {0}", ex.GetType().Name);
            ErrorFormat("Message: {0}", ex.Message);
            ErrorFormat("StackTrace: {0}", ex.StackTrace);
        }

        private void AddRaw(PluginManager.MessageType messageType, string message, params object[] arg0)
        {
            if (arg0.Any())
            {
                message = string.Format(message, arg0);
            }

            message = string.Format("[{0}][{1}]: {2}", modFolderName, DateTime.Now.ToString("HH:mm:ss"), message);

            if (LogToOutputPanel || messageType == PluginManager.MessageType.Error)
            {
                DebugOutputPanel.AddMessage(messageType, message);
            }

            if (LogToFile)
            {
                outputLog.Write(message);
            }
        }
    }
}
