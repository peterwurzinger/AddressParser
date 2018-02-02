using System;
using System.Text.RegularExpressions;

namespace AddressParsing
{
    public static class AddressParser
    {
        private static readonly Regex StrasseHausnummer = new Regex(@"^([\D]*(?:[\d]*\.)*[\D]+\D)(\d+\s?[a-z]?)(?:\s?-\s?(\d+\s?[a-z]?))?(.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex StiegeTuer = new Regex(@"(?:[/\s\\]{1})([a-zäöüß\d\s]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static ResultAddress Parse(string inputString)
        {
            var address = new ResultAddress();

            var strasseHausnummerMatch = StrasseHausnummer.Match(inputString);

            if (!strasseHausnummerMatch.Success)
                throw new FormatException("Address is in an invalid format!");

            address.Strasse = strasseHausnummerMatch.Groups[1].Value.Trim();
            address.HausnummerVon = strasseHausnummerMatch.Groups[2].Value.Trim();

            if (!string.IsNullOrWhiteSpace(strasseHausnummerMatch.Groups[3].Value))
                address.HausnummerBis = strasseHausnummerMatch.Groups[3].Value.Trim();

            var stiegeTuerMatches = StiegeTuer.Matches(strasseHausnummerMatch.Groups[4].Value);
            switch (stiegeTuerMatches.Count)
            {
                case 1:
                    address.Tuer = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    break;
                case 2:
                    address.Stiege = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    address.Tuer = stiegeTuerMatches[1].Groups[1].Value.Trim();
                    break;
                case 3:
                    address.Block = stiegeTuerMatches[0].Groups[1].Value.Trim();
                    address.Stiege = stiegeTuerMatches[1].Groups[1].Value.Trim();
                    address.Tuer = stiegeTuerMatches[2].Groups[1].Value.Trim();
                    break;
                case 0:
                    break;
                default: throw new FormatException("Address is in an invalid format!");
            }

            return address;
        }
    }
}
