using System.Collections.Generic;
using System.Text;

namespace AddressParsing
{
    public readonly struct ResultAddress
    {
        public string Strasse { get; }
        public string HausnummerVon { get; }
        public string? HausnummerBis { get; }
        public string? Block { get; }
        public string? Stiege { get; }
        public string? Tuer { get; }

        public ResultAddress(string strasse, string hausnummerVon, string? hausnummerBis = null)
        {
            Strasse = strasse;
            HausnummerVon = hausnummerVon;
            HausnummerBis = hausnummerBis;
            Block = Stiege = Tuer = null;
        }

        public ResultAddress(string strasse, string hausnummerVon, string? hausnummerBis, string? block, string? stiege, string? tuer)
        {
            Strasse = strasse;
            HausnummerVon = hausnummerVon;
            HausnummerBis = hausnummerBis;
            Block = block;
            Stiege = stiege;
            Tuer = tuer;
        }

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

        public static bool operator ==(ResultAddress left, ResultAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResultAddress left, ResultAddress right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            int hashCode = -2047240748;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Strasse);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HausnummerVon);
            hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(HausnummerBis);
            hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(Block);
            hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(Stiege);
            hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(Tuer);
            return hashCode;
        }

        public override bool Equals(object? obj)
        {
            return obj is ResultAddress address &&
                   Strasse == address.Strasse &&
                   HausnummerVon == address.HausnummerVon &&
                   HausnummerBis == address.HausnummerBis &&
                   Block == address.Block &&
                   Stiege == address.Stiege &&
                   Tuer == address.Tuer;
        }
    }
}