namespace SexyFishHorse.CitiesSkylines.Logger
{
    public interface ILogger
    {
        void Log(string message);

        void Log(string message, params object[] arg0);

        void Error(string message);

        void Error(string message, params object[] arg0);

        void Warn(string message);

        void Warn(string message, params object[] arg0);
    }
}
