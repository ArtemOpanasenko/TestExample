using System;

namespace Task01
{
    public static class Expect
    {
        public static void IndexOutOfRange(int argumentValue, int maxValue, string argumentName = "")
        {
            if (argumentValue < 0 || argumentValue >= maxValue)
            {
                throw new IndexOutOfRangeException(argumentName);
            }
        }

        public static void PositiveArgument(int argumentValue, string argumentName = "")
        {
            if (argumentValue <= 0)
            {
                throw new ArgumentException($"Number of {argumentName} cannot be <= 0");
            }
        }
    }
}