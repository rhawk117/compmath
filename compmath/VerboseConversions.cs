using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath
{
    public class VerboseConversions
    {
        public string DecimalToBinary(int decimalNumber)
        {
            List<int> remainders = new List<int>();
            int quotient = decimalNumber;

            Prompts.VerboseMessage(string.Format("Converting {0} to binary:", decimalNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");
            Console.ReadKey();

            while (quotient > 0)
            {
                int remainder = quotient % 2;
                remainders.Add(remainder);
                Prompts.VerboseMessage(string.Format("{0} ÷ 2 = {1} remainder {2}",
                quotient, quotient / 2, remainder));

                quotient /= 2;
                Console.ReadKey();
            }

            remainders.Reverse();
            string result = string.Join("", remainders);
            Prompts.ConvertedOutput(string.Format("Conversion Complete: The binary representation is: {0}", result));
            return result;
        }

        public string BinaryToDecimal(string binaryNumber)
        {
            Prompts.VerboseMessage(string.Format("Converting {0} to decimal:", binaryNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");
            Console.ReadKey();

            int result = 0;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                int digit = binaryNumber[binaryNumber.Length - 1 - i] - '0';
                int value = digit * (int)Math.Pow(2, i);
                result += value;
                Prompts.VerboseMessage(string.Format("Digit {0} at position {1} contributes {2}", digit, i, value));
                Console.ReadLine();
            }

            Prompts.ConvertedOutput(string.Format("Conversion Complete: The decimal representation is: {0}", result));
            return result.ToString();
        }

        public string HexToBinary(string hexNumber)
        {
            Prompts.VerboseMessage(string.Format("Converting {0} to binary:", hexNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");
            Console.ReadKey();

            string result = "";
            foreach (char c in hexNumber.ToUpper())
            {
                string binary = Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                result += binary;
                Prompts.VerboseMessage(string.Format("Hex digit {0} converts to binary {1}", c, binary));
                Console.ReadKey();
            }

            Prompts.VerboseMessage(string.Format("Conversion Complete: The binary representation is: {0}", result));
            return result;
        }

        public string BinaryToHex(string binaryNumber)
        {
            Prompts.VerboseMessage(string.Format("Converting {0} to hexadecimal:", binaryNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");

            Console.ReadKey();

            while (binaryNumber.Length % 4 != 0)
            {
                binaryNumber = "0" + binaryNumber;
            }

            string result = "";
            for (int i = 0; i < binaryNumber.Length; i += 4)
            {
                string group = binaryNumber.Substring(i, 4);
                int value = Convert.ToInt32(group, 2);
                string hex = Convert.ToString(value, 16).ToUpper();
                result += hex;
                Prompts.VerboseMessage(string.Format("Binary group {0} converts to hex {1}", group, hex));
                Console.ReadKey();
            }

            Prompts.ConvertedOutput(string.Format("Conversion Complete: The hexadecimal representation is: {0}", result));
            return result;
        }

        public string DecimalToHex(int decimalNumber)
        {
            List<string> remainders = new List<string>();
            int quotient = decimalNumber;

            Prompts.VerboseMessage(string.Format("Converting {0} to hexadecimal:", decimalNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");

            Console.ReadKey();

            while (quotient > 0)
            {
                int remainder = quotient % 16;
                string hexDigit = remainder < 10 ? remainder.ToString() : ((char)(remainder - 10 + 'A')).ToString();
                remainders.Add(hexDigit);
                int divResult = quotient / 16;

                Prompts.VerboseMessage(string.Format(
                    "{0} ÷ 16 = {1} remainder {2} (hex: {3})", quotient, divResult, remainder, hexDigit)
                );

                quotient /= 16;
                Console.ReadKey();
            }

            remainders.Reverse();
            string result = string.Join("", remainders);
            Prompts.ConvertedOutput(string.Format(
                "Conversion Complete: The hexadecimal representation is: {0}", result));
            return result;
        }

        public string HexToDecimal(string hexNumber)
        {
            Prompts.VerboseMessage(string.Format("Converting {0} to decimal:", hexNumber));
            Prompts.VerboseMessage("Press Enter to continue through each step.");
            Console.ReadKey();

            int result = 0;
            for (int i = 0; i < hexNumber.Length; i++)
            {
                int digitValue = Convert.ToInt32(hexNumber[hexNumber.Length - 1 - i].ToString(), 16);
                int value = digitValue * (int)Math.Pow(16, i);
                result += value;
                int hexDig = hexNumber[hexNumber.Length - 1 - i];
                AnsiConsole.MarkupLine(string.Format(
                    "Hex digit {0} at position {1} contributes {2}", hexDig, i, value));
                Console.ReadKey();
            }
            Prompts.ConvertedOutput(string.Format(
                "Conversion Complete: The decimal representation is: {0}", result));
            return result.ToString();
        }
    }
}


