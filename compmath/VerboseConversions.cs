using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath
{
    class VerboseConversions
    {
        public string DecimalToBinary(int decimalNumber)
        {
            List<int> remainders = new List<int>();
            int quotient = decimalNumber;

            AnsiConsole.MarkupLine($"[bold]Converting {decimalNumber} to binary:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

            while (quotient > 0)
            {
                int remainder = quotient % 2;
                remainders.Add(remainder);
                AnsiConsole.MarkupLine($"{quotient} ÷ 2 = {quotient / 2} remainder {remainder}");
                quotient /= 2;
                Console.ReadLine();
            }

            remainders.Reverse();
            string result = string.Join("", remainders);
            AnsiConsole.MarkupLine($"[green]The binary representation is: {result}[/]");
            return result;
        }

        public string BinaryToDecimal(string binaryNumber)
        {
            AnsiConsole.MarkupLine($"[bold]Converting {binaryNumber} to decimal:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

            int result = 0;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                int digit = binaryNumber[binaryNumber.Length - 1 - i] - '0';
                int value = digit * (int)Math.Pow(2, i);
                result += value;
                AnsiConsole.MarkupLine($"Digit {digit} at position {i} contributes {value}");
                Console.ReadLine();
            }

            AnsiConsole.MarkupLine($"[green]The decimal representation is: {result}[/]");
            return result.ToString();
        }

        public string HexToBinary(string hexNumber)
        {
            AnsiConsole.MarkupLine($"[bold]Converting {hexNumber} to binary:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

            string result = "";
            foreach (char c in hexNumber.ToUpper())
            {
                string binary = Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                result += binary;
                AnsiConsole.MarkupLine($"Hex digit {c} converts to binary {binary}");
                Console.ReadLine();
            }

            AnsiConsole.MarkupLine($"[green]The binary representation is: {result}[/]");
            return result;
        }

        public string BinaryToHex(string binaryNumber)
        {
            AnsiConsole.MarkupLine($"[bold]Converting {binaryNumber} to hexadecimal:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

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
                AnsiConsole.MarkupLine($"Binary group {group} converts to hex {hex}");
                Console.ReadLine();
            }

            AnsiConsole.MarkupLine($"[green]The hexadecimal representation is: {result}[/]");
            return result;
        }

        public string DecimalToHex(int decimalNumber)
        {
            List<string> remainders = new List<string>();
            int quotient = decimalNumber;

            AnsiConsole.MarkupLine($"[bold]Converting {decimalNumber} to hexadecimal:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

            while (quotient > 0)
            {
                int remainder = quotient % 16;
                string hexDigit = remainder < 10 ? remainder.ToString() : ((char)(remainder - 10 + 'A')).ToString();
                remainders.Add(hexDigit);
                AnsiConsole.MarkupLine($"{quotient} ÷ 16 = {quotient / 16} remainder {remainder} (hex: {hexDigit})");
                quotient /= 16;
                Console.ReadLine();
            }

            remainders.Reverse();
            string result = string.Join("", remainders);
            AnsiConsole.MarkupLine($"[green]The hexadecimal representation is: {result}[/]");
            return result;
        }

        public string HexToDecimal(string hexNumber)
        {
            AnsiConsole.MarkupLine($"[bold]Converting {hexNumber} to decimal:[/]");
            AnsiConsole.MarkupLine("[gray]Press Enter to continue through each step.[/]");
            Console.ReadLine();

            int result = 0;
            for (int i = 0; i < hexNumber.Length; i++)
            {
                int digitValue = Convert.ToInt32(hexNumber[hexNumber.Length - 1 - i].ToString(), 16);
                int value = digitValue * (int)Math.Pow(16, i);
                result += value;
                AnsiConsole.MarkupLine($"Hex digit {hexNumber[hexNumber.Length - 1 - i]} at position {i} contributes {value}");
                Console.ReadLine();
            }

            AnsiConsole.MarkupLine($"[green]The decimal representation is: {result}[/]");
            return result.ToString();
        }
    }
}


