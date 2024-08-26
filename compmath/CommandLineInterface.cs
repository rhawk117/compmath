using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath
{
    class CommandLineInterface
    {
        private Converter _converter;
        private VerboseConversions _verboseConverter;

        public CommandLineInterface(Converter converter, VerboseConversions verboseConverter)
        {
            _converter = converter;
            _verboseConverter = verboseConverter;
        }

        public void RunInteractive()
        {
            Prompts.Header();
            Prompts.Welcome("Welcome to CompMath!");
            Prompts.Welcome("Type 'help' for usage information or 'exit' to quit.");

            string input = "";
            while (input.ToLower() != "exit")
            {
                input = AnsiConsole.Ask<string>("[bold blue]>[/]");

                ProcessCommands(input.Split(' '));
            }

            Prompts.InfoMessage("Thank you for using CompMath!");
        }

        public void ProcessCommands(string[] args)
        {
            if (args.Length == 0) return;

            bool verbose = Array.IndexOf(args, "-v") >= 0
                           || Array.IndexOf(args, "--verbose") >= 0;

            args = Array.FindAll(args, arg =>
                   arg != "-v" && arg != "--verbose");

            switch (args[0].ToLower())
            {

                case "decimal2binary":
                case "binary2decimal":
                case "hex2binary":
                case "binary2hex":
                case "decimal2hex":
                case "hex2decimal":
                    handleCommand(args, verbose);
                    break;

                case "help":
                    DisplayHelp();
                    break;

                default:
                    Prompts.ErrorMessage("Unknown command. Type 'help' for example usage and additional information.");
                    break;
            }
        }

        private void handleCommand(string[] args, bool verbose)
        {
            if (args.Length != 2)
            {
                Prompts.ErrorMessage(string.Format("Invalid Command, cannot parse input. Use '{0} <number>'", args[0]));
            }
            else
            {
                PerformConversion(args[0], args[1], verbose);
            }
        }

        private void DisplayHelp()
        {
            var table = new Table();
            table.AddColumn("[bold]Commands[/]");
            table.AddColumn("[bold]Description[/]");

            table.AddRow("help", "Display this help message");
            table.AddRow("decimal2binary <number>", "Converts a decimal number to binary");
            table.AddRow("binary2decimal <number>", "Converts a binary number to decimal");
            table.AddRow("hex2binary <number>", "Converts a hexadecimal number to binary");
            table.AddRow("binary2hex <number>", "Converts a binary number to hexadecimal");
            table.AddRow("decimal2hex <number>", "Converts a decimal number to hexadecimal");
            table.AddRow("hex2decimal <number>", "Convert a hexadecimal number to decimal");

            AnsiConsole.Write(table);

            Prompts.InfoMessage("Options:");
            Prompts.InfoMessage("  -v, --verbose  provides a walk through each of the steps in the conversion process");
        }

        private void PerformConversion(string command, string input, bool verbose)
        {
            try
            {
                string result;
                if (verbose)
                {
                    result = PerformVerboseConversion(command, input);
                }
                else
                {
                    result = StandardConversion(command, input);
                    Prompts.ConvertedOutput(result);
                }
            }
            catch (FormatException)
            {
                Prompts.ErrorMessage("Invalid input format. Please check your input and try again.");
            }
            catch (OverflowException)
            {
                Prompts.ErrorMessage("Input is too large. Please enter a smaller number.");
            }
            catch (ArgumentException ex)
            {
                Prompts.ErrorMessage(ex.Message);
            }
        }

        private string PerformVerboseConversion(string command, string input)
        {
            switch (command.ToLower())
            {
                case "decimal2binary":
                    return _verboseConverter.DecimalToBinary(int.Parse(input));

                case "binary2decimal":
                    return _verboseConverter.BinaryToDecimal(input);

                case "hex2binary":
                    return _verboseConverter.HexToBinary(input);

                case "binary2hex":
                    return _verboseConverter.BinaryToHex(input);

                case "decimal2hex":
                    return _verboseConverter.DecimalToHex(int.Parse(input));

                case "hex2decimal":
                    return _verboseConverter.HexToDecimal(input);

                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        private string StandardConversion(string command, string input)
        {
            switch (command.ToLower())
            {
                case "decimal2binary":
                    return _converter.DecimalToBinary(int.Parse(input));

                case "binary2decimal":
                    return _converter.BinaryToDecimal(input).ToString();

                case "hex2binary":
                    return _converter.HexToBinary(input);

                case "binary2hex":
                    return _converter.BinaryToHex(input);

                case "decimal2hex":
                    return _converter.DecimalToHex(int.Parse(input));

                case "hex2decimal":
                    return _converter.HexToDecimal(input).ToString();

                default:
                    throw new ArgumentException("Invalid command");
            }
        }
    }
}
