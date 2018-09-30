using Moq;
using NUnit.Framework;
using SocialNetworking.Domain.Commands;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Tests.Commands
{
    [TestFixture]
    public class PostCommandTests
    {                
        [Test]
        public void Process_UsernameAndMessage_PostsData()
        {
            //Arrange
            var commandText = "unknown -> command";
            var postsRepository = new Mock<IPostsRepository>();
            postsRepository.Setup(d => d.Post(It.IsAny<IWallData>()));

            var postCommand = new PostCommand(It.IsAny<string>(), commandText);

            //Act
            postCommand.Process(postsRepository.Object);

            //Assert
            postsRepository.Verify(d=>d.Post(It.IsAny<IWallData>()), Times.Once());
        }
    }
}
