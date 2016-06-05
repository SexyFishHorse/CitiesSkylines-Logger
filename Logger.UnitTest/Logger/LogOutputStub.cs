namespace SexyFishHorse.CitiesSkylines.Logger.UnitTest.Logger
{
    using System;
    using System.Collections.Generic;
    using ColossalFramework.Plugins;
    using Models;

    public class LogOutputStub : LogOutputBase
    {
        public LogOutputStub()
        {
            DisposeCount = 0;
            LogMessages = new List<Tuple<PluginManager.MessageType, string>>();
        }

        public int DisposeCount { get; private set; }

        public int LogMessageCount
        {
            get
            {
                return LogMessages.Count;
            }
        }

        public IList<Tuple<PluginManager.MessageType, string>> LogMessages { get; private set; }

        public override void Dispose()
        {
            DisposeCount++;
        }

        protected override void LogMessage(PluginManager.MessageType messageType, string message)
        {
            LogMessages.Add(new Tuple<PluginManager.MessageType, string>(messageType, message));
        }
    }
}
