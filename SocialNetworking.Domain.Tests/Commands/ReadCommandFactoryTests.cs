using NUnit.Framework;
using SocialNetworking.Domain.Commands;
using SocialNetworking.Domain.Commands.Factories;

namespace SocialNetworking.Domain.Tests.Commands
{
    [TestFixture]
    public class ReadCommandFactoryTests
    {
        private ReadCommandFactory _readCommandFactory;

        [SetUp]
        public void Setup()
        {
            _readCommandFactory = new ReadCommandFactory();
        }

        [Test]
        public void GenerateCommand_NotMatchingCommandText_ReturnsNoCommand()
        {
            //Arrange
            var commandText = "unknown -> command";

            //Act
            var result = _readCommandFactory.GenerateCommand(commandText);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GenerateCommand_MatchingCommandText_ReturnsReadCommand()
        {
            //Arrange
            var commandText = "unknown";

            //Act
            var result = _readCommandFactory.GenerateCommand(commandText);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ReadCommand>(result);
        }
    }
}
