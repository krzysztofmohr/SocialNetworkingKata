using System;
using NUnit.Framework;
using SocialNetworking.Domain.Display;

namespace SocialNetworking.Domain.Tests.Display
{
    [TestFixture]   
    public class PostTimeFormatterTests
    {
        private PostTimeFormatter _postTimeFormatter;

        [SetUp]
        public void Setup()
        {
            _postTimeFormatter = new PostTimeFormatter();
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void FormatPostTime_LessThanAMinute_ReturnsFormattedSecondsText(int seconds)
        {
            //Arrange
            var now = DateTime.Now;
            var postTimespan = now.AddSeconds(-seconds);
            var response = $"{seconds} seconds ago";

            //Act
            var result = _postTimeFormatter.FormatPostTime(postTimespan);

            //Assert
            Assert.AreEqual(result, response);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void FormatPostTime_LessThanAnHour_ReturnsFormattedMinutesText(int minutes)
        {
            //Arrange
            var now = DateTime.Now;
            var postTimespan = now.AddMinutes(-minutes);
            var response = $"{minutes} minutes ago";

            //Act
            var result = _postTimeFormatter.FormatPostTime(postTimespan);

            //Assert
            Assert.AreEqual(result, response);
        }
    }
}
