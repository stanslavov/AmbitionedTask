namespace AmbitionedTask
{
    public static class Constants
    {
        public const string ErrorMessage = "Please enter a valid mathematical expression.";

        public const string ErrorMessageMinLength = "Expression must be at least 2 characters long.";

        public const string NotAllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`~!@#$%^&_[];':\",<>?";

        public const string Regex1 = @"\+|\-|\*|\/";

        public const string Regex2 = @"^\d+(?:\.\d+)?";

        public const string Regex3 = @"^\s*(?<value>{0})\s*";

        public const string Parentheses1 = "(";

        public const string Parentheses2 = ")";

        public const char Parentheses3 = '(';

        public const char Parentheses4 = ')';

        public const string valueString = "value";

        public const string n2String = "N2";

        public const string dotString = ".";
    }
}
