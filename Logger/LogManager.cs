namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class LogManager
    {
        private static LogManager instance;

        private readonly IDictionary<string, ILogger> loggers;

        public LogManager()
        {
            loggers = new Dictionary<string, ILogger>();
        }

        public static LogManager Instance
        {
            get
            {
                return instance ?? (instance = new LogManager());
            }
        }

        public string ModFolderName { get; set; }

        public ILogger GetLogger()
        {
            return GetLogger(null);
        }

        public ILogger GetLogger(string loggerName)
        {
            if (string.IsNullOrEmpty(ModFolderName))
            {
                throw new InvalidOperationException("Mod folder name not set");
            }

            if (loggers.ContainsKey(loggerName))
            {
                return loggers[loggerName];
            }

            var loggerFilename = GetLoggerFilename(loggerName);

            var logger = new Logger(ModFolderName, loggerFilename, true);

            loggers.Add(loggerName, logger);

            return logger;
        }

        private static string GetLoggerFilename(string loggerName)
        {
            return string.Format("{0}.log", loggerName);
        }
    }
}
