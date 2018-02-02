using System.Text;

namespace AddressParsing
{
    public class ResultAddress
    {
        public string Strasse { get; set; }
        public string HausnummerVon { get; set; }
        public string HausnummerBis { get; set; }
        public string Block { get; set; }
        public string Stiege { get; set; }
        public string Tuer { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder(Strasse);
            builder.Append($" {HausnummerVon}");
            if (!string.IsNullOrEmpty(HausnummerBis))
                builder.Append($"-{HausnummerBis}");
            if (!string.IsNullOrEmpty(Block))
                builder.Append($"/{Block}");
            if (!string.IsNullOrEmpty(Stiege))
                builder.Append($"/{Stiege}");
            if (!string.IsNullOrEmpty(Tuer))
                builder.Append($"/{Tuer}");
            return builder.ToString();
        }
    }
}