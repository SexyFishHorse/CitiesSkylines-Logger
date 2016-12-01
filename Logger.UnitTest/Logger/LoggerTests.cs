namespace SexyFishHorse.CitiesSkylines.Logger.UnitTest.Logger
{
    using System;
    using System.Linq;
    using ColossalFramework.Plugins;
    using Ploeh.AutoFixture;
    using Xunit;
    using Xunit.Should;
    using Logger = CitiesSkylines.Logger.Logger;

    public class LoggerTests
    {
        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Error(fixture.CreateAnonymous<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageWithTypeError()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Error(fixture.CreateAnonymous<string>());

            output.LogMessages.Single().Key.ShouldBe(PluginManager.MessageType.Error);
        }

        [Fact]
        public void Error_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.CreateAnonymous<string>();
            instance.Error(message);

            output.LogMessages.Single().Value.ShouldContain(message);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Info(fixture.CreateAnonymous<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageWithTypeMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Info(fixture.CreateAnonymous<string>());

            output.LogMessages.Single().Key.ShouldBe(PluginManager.MessageType.Message);
        }

        [Fact]
        public void Info_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.CreateAnonymous<string>();
            instance.Info(message);

            output.LogMessages.Single().Value.ShouldContain(message);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageOnce()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Warn(fixture.CreateAnonymous<string>());

            output.LogMessageCount.ShouldBe(1);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageWithTypeWarning()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.Warn(fixture.CreateAnonymous<string>());

            output.LogMessages.Single().Key.ShouldBe(PluginManager.MessageType.Warning);
        }

        [Fact]
        public void Warn_CalledOnce_ShouldCallLogMessageWithMessage()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            var message = fixture.CreateAnonymous<string>();
            instance.Warn(message);

            output.LogMessages.Single().Value.ShouldContain(message);
        }

        [Fact]
        public void LogException_CalledOnce_ShouldCallLogMessageTwice()
        {
            var fixture = new Fixture();

            var output = new LogOutputStub();

            var instance = new Logger(output);

            instance.LogException(fixture.CreateAnonymous<Exception>());

            output.LogExceptionsCount.ShouldBe(1);
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