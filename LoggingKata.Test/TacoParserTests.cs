using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        private readonly TacoParser _tacoParser;
        public TacoParserTests()
        {
            _tacoParser = new TacoParser();
        }
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("-85.23,33.01,Taco Bell Birmingham")]
        public void ShouldParse1(string str)
        {
            var result = _tacoParser.Parse(str);

            Assert.Equal("Taco Bell Birmingham", result.Name);
            var longitude = result.Location.Longitude;
            var latitude = result.Location.Latitude;
            Assert.Equal(-85.23, longitude);
            Assert.Equal(33.01, latitude);
        }

        [Theory]
        [InlineData("1,2,Taco Bell Birmingham")]
        public void ShouldParse2(string str)
        {
            var result = _tacoParser.Parse(str);

            Assert.Equal("Taco Bell Birmingham", result.Name);
            var longitude = result.Location.Longitude;
            var latitude = result.Location.Latitude;
            Assert.Equal(1, longitude);
            Assert.Equal(2, latitude);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("1,2")]
        [InlineData(",,")]
        [InlineData(",,,")]
        [InlineData("A,B")]
        [InlineData("A,B,C")]
        public void ShouldFailParse(string str)
        {
            var result = _tacoParser.Parse(str);
            Assert.Equal(null,result);
            // TODO: Complete Should Fail Parse
        }
    }
}
