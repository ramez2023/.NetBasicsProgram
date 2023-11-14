/*

Task 02 :
Open NumberParser class under Task2 project and implement Parse method to convert a string value to integer. 
It is NOT allowed to use int.Parse(), int.TryParse() or any other built-in conversion methods. 
Error handling should be implemented. All unit tests should pass successfully. 

 */

using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException("Input cannot be null.");

            stringValue = stringValue.Trim();
            if (stringValue.Length == 0)
                throw new FormatException("Input cannot be empty.");

            if (stringValue.Equals(int.MinValue.ToString()))
                return int.MinValue;

            int result = 0;
            int sign = 1;
            int startIndex = 0;

            if (stringValue[0] == '-')
            {
                sign = -1;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                if (char.IsDigit(stringValue[i]))
                {
                    try
                    {
                        checked
                        {
                            int digit = stringValue[i] - '0';
                            result = result * 10 + digit;
                        }
                    }
                    catch (OverflowException)
                    {
                        throw new OverflowException("The input value is too large to be represented as an integer.");
                    }
                }
                else
                {
                    throw new FormatException($"Invalid character in the input: '{stringValue[i]}'.");
                }
            }

            return result * sign;
        }
    }
}