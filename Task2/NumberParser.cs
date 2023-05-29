using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            // Check if the string is null
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            stringValue = stringValue.Trim();

            // Check if the string is empty
            if (stringValue == "")
            {
                throw new FormatException("Input string cannot be empty");
            }

            int result = 0;
            int startIndex = 0;
            bool isNegative = false;

            // Check if the string starts with a negative sign
            if (stringValue[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                if (stringValue[i] < '0' || stringValue[i] > '9')
                {
                    throw new FormatException("Input string contains non-numeric characters");
                }

                int digit = stringValue[i] - '0';

                if (i == stringValue.Length - 1)
                {
                    checked
                    {
                        if (isNegative)
                        {
                            result = -result * 10 - digit;
                        }
                        else
                        {
                            result = result * 10 + digit;
                        }
                    }
                }
                else
                {
                    result = result * 10 + digit;
                }

                if (isNegative && -result == int.MinValue)
                {
                    return int.MinValue;
                }
                else if (!isNegative && result == int.MaxValue)
                {
                    return int.MaxValue;
                }
            }

            return result;
        }
    }
}