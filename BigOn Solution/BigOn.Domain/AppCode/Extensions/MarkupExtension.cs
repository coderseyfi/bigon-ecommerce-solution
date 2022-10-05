using System.Text.RegularExpressions;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string ToPlainText(this string text)
        {
            text = Regex.Replace(text, "<[^>]*>", "");
            return text;
        }

        public static string ToPlainText(this string text, int len)
        {
            if (!string.IsNullOrWhiteSpace(text) && text.Length > len)
            {
                text = text.Substring(0, len);
            }
            return text;
        }
    }
}
