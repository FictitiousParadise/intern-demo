
using System.IO;
using System.Linq;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace TheOneCatBa.Utils
{
    public class DataHelper
    {
        public static string ToCurrency(double? value)
        {
            if (!value.HasValue)
                return "";
            if (value.Value % 1 == 0)
                return ToCurrencyRound0(value);

            var info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            return string.Format(info, "{0:c2}", value).Replace("$", "");
        }

        public static string ToCurrencyRound0(double? value)
        {
            if (!value.HasValue)
                return "";
            var info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            return string.Format(info, "{0:c0}", value).Replace("$", "");
        }

        public static double TryParseDouble(string value, double defaultValue = 0)
        {
            double result;
            if (!double.TryParse(value, out result))
            {
                result = defaultValue;
            }

            return result;
        }

        public static int TryParseInt(string value, int defaultValue = 0)
        {
            int result;
            if (!int.TryParse(value, out result))
            {
                result = defaultValue;
            }

            return result;
        }
        public static bool IsEmail(string value)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(value);
            return match.Success;
        }

       public static string StringToMD5(string s)
        {
            using (MD5 md5 = MD5.Create())
            {
                return System.BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(s)))
                            .Replace("-", "");
            }
        }

        public static string CreateSlug(string text)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string slug = text.Normalize(NormalizationForm.FormD).Trim().ToLower();

            slug = regex.Replace(slug, String.Empty)
              .Replace('\u0111', 'd').Replace('\u0110', 'D')
              .Replace(",", "-").Replace(".", "-").Replace("!", "")
              .Replace("(", "").Replace(")", "").Replace(";", "-")
              .Replace("/", "-").Replace("%", "ptram").Replace("&", "va")
              .Replace("?", "").Replace('"', '-').Replace(' ', '-');

            return slug;

        }

    }
}
