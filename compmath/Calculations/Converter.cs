using System;

namespace compmath
{
    public class Converter
    {
        public string DecimalToBinary(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 2);
        }

        public int BinaryToDecimal(string binaryNumber)
        {
            ValidateBinary(binaryNumber);
            return Convert.ToInt32(binaryNumber, 2);
        }

        public string HexToBinary(string hexNumber)
        {
            ValidateHex(hexNumber);
            return Convert.ToString(Convert.ToInt32(hexNumber, 16), 2);
        }

        public string BinaryToHex(string binaryNumber)
        {
            ValidateBinary(binaryNumber);
            return Convert.ToString(Convert.ToInt32(binaryNumber, 2), 16).ToUpper();
        }

        public string DecimalToHex(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 16).ToUpper();
        }

        public int HexToDecimal(string hexNumber)
        {
            ValidateHex(hexNumber);
            return Convert.ToInt32(hexNumber, 16);
        }

        private void ValidateBinary(string binaryNumber)
        {
            if (string.IsNullOrEmpty(binaryNumber))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(binaryNumber, "^[01]+$"))
            {
                throw new ArgumentException("Invalid binary number. Use only 0s and 1s.");
            }
        }

        private void ValidateHex(string hexNumber)
        {
            if (string.IsNullOrEmpty(hexNumber))
            {
                throw new ArgumentException("Input cannot be empty.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(hexNumber, "^[0-9A-Fa-f]+$"))
            {
                throw new ArgumentException("Invalid hexadecimal number. Use only 0-9 and A-F.");
            }
        }
    }
}

