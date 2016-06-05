namespace SexyFishHorse.CitiesSkylines.Logger
{
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

        public ILogger GetLogger(string loggerName)
        {
            if (loggers.ContainsKey(loggerName))
            {
                return loggers[loggerName];
            }

            var logger = new Logger(loggerName);

            loggers.Add(loggerName, logger);

            return logger;
        }
    }
}
