using FlexiSourceTestApp.Common.Request;
using FlexiSourceTestApp.Test.Services.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FlexiSourceTestApp.Test.Services
{
    public class TextServiceTest
    {
        public TextServiceTest() { }

        [Theory]
        [InlineData("Test Test Test", "Test", 3)]
        [InlineData("1 0 1 0 1 1 1 0", "1", 5)]
        [InlineData("0 1 11 1 1 00 0", "0", 4)]
        [InlineData("1111111 11 22 99 00", "11", 4)]
        public void StringSearch_ReturnsListInt(string text, string subText, int expectedMatchCount)
        {
            var service = ServiceGenerator.GetTextService();
            var request = new StringMatchRequest { Text = text, SubText = subText };
            var result = service.StringSearch(request);
            Assert.NotNull(result);
            Assert.NotEmpty(result.MatchFirstIndexes);
            Assert.Equal(result.MatchFirstIndexes.Count, expectedMatchCount);
        }

        [Fact]
        public void StringSearch_ReturnsEmptyListInt()
        {
            var service = ServiceGenerator.GetTextService();
            var request = new StringMatchRequest { Text = "T", SubText = "N" };
            var result = service.StringSearch(request);
            Assert.NotNull(result);
            Assert.Empty(result.MatchFirstIndexes);
        }

        [Theory]
        [InlineData("T", "TT")]
        [InlineData("T", "")]
        [InlineData("", "T")]
        public void StringSearch_ThrowsArgumentException(string text, string subText)
        {
            var request = new StringMatchRequest { Text = text, SubText = subText };
            var service = ServiceGenerator.GetTextService();
             Assert.Throws<ArgumentNullException>(() => service.StringSearch(request));
        }
    }
}
