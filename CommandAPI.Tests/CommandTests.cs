namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            //Arrange
            testCommand = new Command
            {
                HowTo = "Do something awesome",
                Platform = "xUnit",
                CommandLine = "dotnet test"
            };
        }

        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Act
            testCommand.HowTo = "Execute Unit Tests";

            //Assert
            Assert.Equal("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {
            //Act
            testCommand.Platform = "Platform";

            //Assert
            Assert.Equal("Platform", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            //Act
            testCommand.CommandLine = "Command Line";

            //Assert
            Assert.Equal("Command Line", testCommand.CommandLine);
        }
    }
}
