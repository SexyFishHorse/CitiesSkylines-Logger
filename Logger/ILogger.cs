namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;

    public interface ILogger
    {
        bool LogToOutputPanel { get; set; }

        bool LogToFile { get; set; }

        void Log(string message);

        void LogFormat(string message, params object[] arg0);

        void Error(string message);

        void ErrorFormat(string message, params object[] arg0);

        void Warn(string message);

        void WarnFormat(string message, params object[] arg0);

        void LogException(Exception ex);
    }
}
