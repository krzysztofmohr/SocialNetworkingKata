using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SocialNetworking.Domain.Display;
using SocialNetworking.Domain.Display.Interfaces;
using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Tests.Display
{
    [TestFixture]
    public class ConsoleDisplayResultServiceTests
    {
        private ConsoleDisplayResultService _consoleDisplayResultService;

        private Mock<IPostTimeFormatter> _postTimeFormatterMock;
        private Mock<IConsole> _consoleMock;

        [SetUp]
        public void Setup()
        {
            _postTimeFormatterMock = new Mock<IPostTimeFormatter>();
            _consoleMock = new Mock<IConsole>();

            _consoleDisplayResultService =
                new ConsoleDisplayResultService(_postTimeFormatterMock.Object, _consoleMock.Object);
        }

        [Test]
        public void Show_WallData_PrintsAndFormatsResponseForEveryPost()
        {
            //Arrange
            var user = "user1";
            var posts = new List<Post>() {new Post {Text = "postText", Timestamp = It.IsAny<DateTime>()}};
            _postTimeFormatterMock.Setup(d => d.FormatPostTime(It.IsAny<DateTime>()));
            _consoleMock.Setup(d => d.PrintLine(It.IsAny<string>()));


            //Act
            _consoleDisplayResultService.Show(new WallData {User = user, Posts = posts});

            //Assert            
            _postTimeFormatterMock.Verify(d=>d.FormatPostTime(It.IsAny<DateTime>()), Times.Once);
            _consoleMock.Verify(d=>d.PrintLine(It.IsAny<string>()), Times.Once);
        }
    }
}
