using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SocialNetworking.Domain.Commands.Interfaces;
using SocialNetworking.Domain.Display.Interfaces;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Services;

namespace SocialNetworking.Domain.Tests
{
    [TestFixture]
    public class SocialNetworkServiceTests
    {
        private SocialNetworkService _socialNetworkService;

        private Mock<ICommandParser> _commandParserMock;
        private Mock<IDisplayResultService> _displayResultServiceMock;

        [SetUp]
        public void Setup()
        {
            _commandParserMock = new Mock<ICommandParser>();
            _displayResultServiceMock = new Mock<IDisplayResultService>();

            _socialNetworkService = new SocialNetworkService(_commandParserMock.Object, _displayResultServiceMock.Object);
        }

        [Test]
        public void EnterCommand_ReadCommand_ReturnsAndDisplaysData()
        {
            //Arrange
            var user = "Anna";
            var message = "Hello";

            var wallData = new WallData
            {
                User = user,
                Posts = new List<Post> {new Post {Text = message, Timestamp = It.IsAny<DateTime>()}}
            };

            var commandText = $"{user}";
            _commandParserMock.Setup(d => d.Parse(commandText)).Returns(wallData);
            _displayResultServiceMock.Setup(d => d.Show(wallData));

            //Act
            _socialNetworkService.EnterCommand(commandText);
            
            //Assert            
            _displayResultServiceMock.Verify(d=>d.Show(wallData), Times.Once);
        }

        [Test]
        public void EnterCommand_PostCommand()
        {
            //Arrange
            var user = "Anna";
            var message = "Hello";

            var commandText = $"{user} -> {message}";
            _commandParserMock.Setup(d => d.Parse(commandText));
            _displayResultServiceMock.Setup(d => d.Show(It.IsAny<IWallData>()));

            //Act
            _socialNetworkService.EnterCommand(commandText);

            //Assert            
            _displayResultServiceMock.Verify(d => d.Show(It.IsAny<IWallData>()), Times.Never);
        }
    }
}
