using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SocialNetworking.Domain.Commands;
using SocialNetworking.Domain.Commands.Factories;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Tests.Commands
{
    [TestFixture]
    public class CommandParserTests
    {
        private CommandParser _commandParser;

        private Mock<ICommandFactory> _commandFactoryMock;
        private Mock<IPostsRepository> _postRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _commandFactoryMock = new Mock<ICommandFactory>();            
            _postRepositoryMock = new Mock<IPostsRepository>();            

            _commandParser = new CommandParser(new[] {_commandFactoryMock.Object }, _postRepositoryMock.Object);
        }

        [Test]
        public void Parse_ReadCommandText_ReadsWallData()
        {
            //Arrange
            var user = It.IsAny<string>();
            var commandText = user;

            _commandFactoryMock.Setup(d => d.GenerateCommand(user)).Returns(new ReadCommand(user));
            _postRepositoryMock.Setup(d => d.Read(user)).Returns(new WallData{User=user, Posts = new List<Post>{new Post{Text = It.IsAny<string>(), Timestamp = It.IsAny<DateTime>() } }});

            //Act
            var result = _commandParser.Parse(commandText);
            
            //Assert            
            Assert.IsNotEmpty(result.Posts);            
        }

        [Test]
        public void Parse_PostCommandText_PostsCommand()
        {
            //Arrange
            var user = It.IsAny<string>();
            var message = It.IsAny<string>();
            var commandText = $"{user} -> {message}";

            _commandFactoryMock.Setup(d => d.GenerateCommand(commandText)).Returns(new PostCommand(user, message));
            _postRepositoryMock.Setup(d => d.Post(It.IsAny<IWallData>()));

            //Act
            _commandParser.Parse(commandText);

            //Assert            
            _postRepositoryMock.Verify(d=>d.Post(It.IsAny<IWallData>()), Times.Once);
        }
    }
}
