using Moq;
using NUnit.Framework;
using SocialNetworking.Domain.Commands;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Tests.Commands
{
    [TestFixture]
    public class ReadCommandTests
    {
        [Test]
        public void Process_Username_ReadsData()
        {
            //Arrange
            var commandText = "unknown";
            var postsRepository = new Mock<IPostsRepository>();
            postsRepository.Setup(d => d.Read(commandText));

            var postCommand = new ReadCommand(commandText);

            //Act
            postCommand.Process(postsRepository.Object);

            //Assert
            postsRepository.Verify(d => d.Read(commandText), Times.Once());
        }
    }
}
