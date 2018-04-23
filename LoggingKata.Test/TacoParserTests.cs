using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        private readonly TacoParser _tacoParser;

        // Constructor
        public TacoParserTests()
        {
            _tacoParser = new TacoParser();
        }
        [Theory]
        [InlineData("84.677017, 34.073638,\"Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("84.677017, 34.073638")]
        public void ShouldDoSomething(string str)
        {
            var result = _tacoParser.Parse(str);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("-180.00,-90.00,Taco Bell Birmingham")]
        [InlineData("180.00,90.00,Taco Bell Birmingham")]
        [InlineData("180.00,90.00")]
        [InlineData("-180.00,-90.00")]
        public void ShouldParse(string str)
        {
            var result = _tacoParser.Parse(str);
            Assert.True(result.Name.Equals("Taco Bell Birmingham") || result.Name.Equals("null"));
            var longitude = result.Location.Longitude;
            var latitude = result.Location.Latitude;
            Assert.InRange(longitude, -180, 180);
            Assert.InRange(latitude, -90, 90);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1")]
        [InlineData(",,")]
        [InlineData(",,,")]
        [InlineData(",,,,")]
        [InlineData("A,B")]
        [InlineData("A,B,C")]
        [InlineData("-180.01,-90.01,C")]
        [InlineData("180.01,90.01,C")]
        public void ShouldFailParse(string str)
        {
            var result = _tacoParser.Parse(str);
            Assert.Null(result);
        }
    }
}
