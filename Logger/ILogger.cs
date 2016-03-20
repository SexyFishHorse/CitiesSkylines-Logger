namespace SexyFishHorse.CitiesSkylines.Logger
{
    public interface ILogger
    {
        void Log(string message);

        void LogFormat(string message, params object[] arg0);

        void Error(string message);

        void ErrorFormat(string message, params object[] arg0);

        void Warn(string message);

        void WarnFormat(string message, params object[] arg0);
    }
}
