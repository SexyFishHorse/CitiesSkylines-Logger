namespace SexyFishHorse.CitiesSkylines.Logger
{
    using System;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public interface ILogger
    {
        bool LogToOutputPanel { get; set; }

        bool LogToFile { get; set; }

        void Log(string message);

        void Log(object obj);

        [StringFormatMethod("message")]
        void LogFormat(string message, params object[] args);

        void Error(string message);

        [StringFormatMethod("message")]
        void ErrorFormat(string message, params object[] args);

        void Warn(string message);

        [StringFormatMethod("message")]
        void WarnFormat(string message, params object[] args);

        void LogException(Exception ex);
    }
}
