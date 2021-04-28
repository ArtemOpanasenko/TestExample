using System;
using System.Text.RegularExpressions;

namespace Task02
{
    public static class Expect
    {
        public static void IndexIsNotMatch(ref string argumentValue)
        {
            string IsbnPattern = @"^\d{13}$|^\d{3}-\d{1}-\d{2}-\d{6}-\d{1}$";

            if (!(Regex.IsMatch(argumentValue, IsbnPattern) || Regex.IsMatch(argumentValue, IsbnPattern)))
            {
                throw new ArgumentException("Invalid key format!");
            }
            else
            {
                argumentValue = argumentValue.Replace("-", "");
            }
        }

        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName = "")
        {
            if (!string.IsNullOrEmpty(argumentValue))
            {
                return;
            }

            if (string.IsNullOrEmpty(argumentName))
            {
                throw new ArgumentNullException();
            }

            throw new ArgumentNullException(argumentName);
        }
    }
}
