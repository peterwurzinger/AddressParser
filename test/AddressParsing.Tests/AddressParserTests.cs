using Xunit;

namespace AddressParsing.Tests
{
    public class AddressParserTests
    {
        [Theory]
        [InlineData("Teststraße 5")]
        [InlineData("Teststraße 5-10")]
        [InlineData("Teststraße 5-10A")]
        [InlineData("Teststraße 5A-10")]
        [InlineData("Teststraße 5A-10A")]
        [InlineData("Teststraße 5-10/2")]
        [InlineData("Teststraße 5-10/2/5")]
        [InlineData("Teststraße 5-10/1/2/5")]
        [InlineData("Teststraße 5-10/Block 1 /2/5")]
        [InlineData("Teststraße 5-10/A/1")]
        [InlineData("Dr. Karl von Test - Straße 5-10/Block1/A/1")]
        [InlineData("Dr. Karl von Test - Straße 5 - 10 / Block 1 / Stiege 2 / 1")]
        [InlineData("4. Straße 5 - 10 /  1 / 2 / 1")]

        //From http://www.postadressglobal.com/de-de/country/oesterreich/formatierung-und-strukturierung-oesterreichischer-adressen/
        [InlineData("Wiener Hauptstraße 10/A/4/15")]
        public void Test(string address)
        {
            AddressParser.Parse(address);
        }
    }
}
