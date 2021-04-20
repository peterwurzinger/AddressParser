using System;
using System.Text.RegularExpressions;

namespace AddressParsing
{
    public static class AddressParser
    {
        private const string InvalidFormatMessage = "Address is in an invalid format!";

        private static readonly Regex StrasseHausnummer = new(@"^([\D]*(?:[\d]*\.)*[\D]+\D)(\d+\s?[a-z]?)(?:\s?-\s?(\d+\s?[a-z]?))?(.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex StiegeTuer = new(@"(?:[/\s\\]{1})([a-zäöüß\d\s]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static ResultAddress Parse(string inputString)
        {
            var strasseHausnummerMatch = StrasseHausnummer.Match(inputString);

            if (!strasseHausnummerMatch.Success)
                throw new FormatException(InvalidFormatMessage);

            var strasse = strasseHausnummerMatch.Groups[1].Value.Trim();
            var hausnummerVon = strasseHausnummerMatch.Groups[2].Value.Trim();

            string? hausnummerBis = null;
            if (!string.IsNullOrWhiteSpace(strasseHausnummerMatch.Groups[3].Value))
                hausnummerBis = strasseHausnummerMatch.Groups[3].Value.Trim();

            var stiegeTuerMatches = StiegeTuer.Matches(strasseHausnummerMatch.Groups[4].Value);

            ResultAddress intermediateAddress = new(strasse, hausnummerVon, hausnummerBis);
            if (stiegeTuerMatches.Count == 0)
                return intermediateAddress;

            return ParseExtendedAddress(intermediateAddress, stiegeTuerMatches);
        }

        private static ResultAddress ParseExtendedAddress(ResultAddress intermediateAddress, MatchCollection stiegeTuerMatches)
        {
            string? tuer;
            string? stiege = null;
            string? block = null;

            switch (stiegeTuerMatches.Count)
            {
                case 1:
                    tuer = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    break;
                case 2:
                    stiege = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    tuer = stiegeTuerMatches[1].Groups[1].Value.Trim();
                    break;
                case 3:
                    block = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    stiege = stiegeTuerMatches[1].Groups[1].Value.Trim();
                    tuer = stiegeTuerMatches[2].Groups[1].Value.Trim();
                    break;
                default: throw new FormatException(InvalidFormatMessage);
            }

            return new(intermediateAddress.Strasse, intermediateAddress.HausnummerVon, intermediateAddress.HausnummerBis, block, stiege, tuer);
        }
    }
}
