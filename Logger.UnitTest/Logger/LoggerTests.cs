namespace SexyFishHorse.CitiesSkylines.Logger.UnitTest.Logger
{
    using System;
    using System.Linq;
    using ColossalFramework.Plugins;
    using Ploeh.AutoFixture;
    using Xunit;
    using XunitShouldExtension;
    using Logger = CitiesSkylines.Logger.Logger;

    public class LoggerTests
    {
        private PluginManager.MessageType messageType;

        private Exception exception;

        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Error(fixture.Create<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageWithTypeError()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Error(fixture.Create<string>());

            output.LogMessages.Single().Item1.ShouldBe(PluginManager.MessageType.Error);
        }

        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.Create<string>();
            instance.Error(message);

            output.LogMessages.Single().Item2.ShouldContain(message);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Info(fixture.Create<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageWithTypeMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Info(fixture.Create<string>());

            output.LogMessages.Single().Item1.ShouldBe(PluginManager.MessageType.Message);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.Create<string>();
            instance.Info(message);

            output.LogMessages.Single().Item2.ShouldContain(message);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Warn(fixture.Create<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageWithTypeWarning()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Warn(fixture.Create<string>());

            output.LogMessages.Single().Item1.ShouldBe(PluginManager.MessageType.Warning);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.Create<string>();
            instance.Warn(message);

            output.LogMessages.Single().Item2.ShouldContain(message);
        }

        [Fact]
        public void LogException_CalledOnce_ShouldCallLogMessageTwice()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.LogException(fixture.Create<Exception>(), fixture.Create<PluginManager.MessageType>());

            output.LogMessageCount.ShouldBe(2);
        }

        [Fact]
        public void LogException_CalledOnce_ShouldCallLogMessageWithSpecifiedMessageType()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            messageType = fixture.Create<PluginManager.MessageType>();
            instance.LogException(fixture.Create<Exception>(), messageType);

            output.LogMessages.Count(x => x.Item1 == messageType).ShouldBe(2);
        }

        [Fact]
        public void LogException_CalledOnce_ShouldCallLogMessageWithExceptionType()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            exception = fixture.Create<Exception>();
            instance.LogException(exception, fixture.Create<PluginManager.MessageType>());

            output.LogMessages.First().Item2.ShouldContain(exception.GetType().Name);
        }

        [Fact]
        public void LogException_CalledOnce_ShouldCallLogMessageWithExceptionMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            exception = fixture.Create<Exception>();
            instance.LogException(exception, fixture.Create<PluginManager.MessageType>());

            output.LogMessages.First().Item2.ShouldContain(exception.Message);
        }

        [Fact]
        public void Dispose_CalledOnce_ShouldCallDisposeOnOutputOnce()
        {
            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Dispose();

            output.DisposeCount.ShouldBe(1);
        }
    }
}