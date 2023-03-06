using System.Text.RegularExpressions;

namespace AmbitionedTask.Models
{
    public class DummyLexer
    {
        public static Number Parse(string s, out int length)
        {
            var value = Parse(s, Constants.Regex2, out length);
            return value == null ? null : Number.Create(value);
        }

        public static string ParseExact(string s, string target, out int length)
        {
            return Parse(s, Regex.Escape(target), out length);
        }

        public static string Parse(string s, string target, out int length)
        {
            var regex = new Regex(string.Format(Constants.Regex3, target));
            var result = regex.Match(s);
            if (!result.Success)
            {
                length = 0;
                return null;
            }
            length = result.Length;
            return result.Groups[Constants.valueString].Value;
        }
    }
}
