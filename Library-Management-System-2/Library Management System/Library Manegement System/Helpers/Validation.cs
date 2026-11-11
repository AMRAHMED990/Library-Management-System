using System.Globalization;
using System.Text.RegularExpressions;

namespace Library_Manegement_System
{
    public static class Validation
    {
        public static bool IsName(string text)
        {
            return Regex.IsMatch(text.Trim(), @"^[\p{L} .'-]{3,100}$");
        }

        public static bool IsEmail(string text)
        {
            return Regex.IsMatch(text.Trim(), @"^[^@\s]+@[^@\s]+\.[A-Za-z]{2,}$");
        }

        public static bool IsPhone(string text)
        {
            return Regex.IsMatch(text.Trim(), @"^01[0125][0-9]{8}$");
        }

        public static bool IsIsbn(string text)
        {
            return Regex.IsMatch(CleanIsbn(text), @"^([0-9]{9}[0-9X]|[0-9]{13})$");
        }

        public static string CleanIsbn(string text)
        {
            return text.Replace("-", "").Replace(" ", "").Trim().ToUpper();
        }

        public static bool IsAmount(string text, out decimal amount)
        {
            return decimal.TryParse(text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out amount)
                && amount > 0 && amount <= 10000;
        }
    }
}
