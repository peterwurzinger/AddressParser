using Xunit;

namespace AddressParsing.Tests
{
    public class AddressParserTests
    {
        [Theory]
        [InlineData("Teststra�e 5")]
        [InlineData("Teststra�e 5-10")]
        [InlineData("Teststra�e 5-10A")]
        [InlineData("Teststra�e 5A-10")]
        [InlineData("Teststra�e 5A-10A")]
        [InlineData("Teststra�e 5-10/2")]
        [InlineData("Teststra�e 5-10/2/5")]
        [InlineData("Teststra�e 5-10/1/2/5")]
        [InlineData("Teststra�e 5-10/Block 1 /2/5")]
        [InlineData("Teststra�e 5-10/A/1")]
        [InlineData("Dr. Karl von Test - Stra�e 5-10/Block1/A/1")]
        [InlineData("Dr. Karl von Test - Stra�e 5 - 10 / Block 1 / Stiege 2 / 1")]
        [InlineData("4. Stra�e 5 - 10 /  1 / 2 / 1")]

        //From http://www.postadressglobal.com/de-de/country/oesterreich/formatierung-und-strukturierung-oesterreichischer-adressen/
        [InlineData("Wiener Hauptstra�e 10/A/4/15")]
        public void Test(string address)
        {
            AddressParser.Parse(address);
        }
    }
}
