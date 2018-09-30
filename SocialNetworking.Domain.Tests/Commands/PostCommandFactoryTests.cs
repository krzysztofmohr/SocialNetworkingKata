using NUnit.Framework;
using SocialNetworking.Domain.Commands;
using SocialNetworking.Domain.Commands.Factories;

namespace SocialNetworking.Domain.Tests.Commands
{
    [TestFixture]
    public class PostCommandFactoryTests
    {
        private PostCommandFactory _postCommandFactory;        

        [SetUp]
        public void Setup()
        {
            _postCommandFactory = new PostCommandFactory();
        }

        [Test]
        public void GenerateCommand_NotMatchingCommandText_ReturnsNoCommand()
        {
            //Arrange
            var commandText = "unknown";

            //Act
            var result = _postCommandFactory.GenerateCommand(commandText);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GenerateCommand_MatchingCommandText_ReturnsPostCommand()
        {
            //Arrange
            var commandText = "unknown -> hello";

            //Act
            var result = _postCommandFactory.GenerateCommand(commandText);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PostCommand>(result);
        }

    }

}
