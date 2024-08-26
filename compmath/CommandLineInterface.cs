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
            AnsiConsole.Write(
                new FigletText("CompMath").Color(Color.Blue).LeftJustified());

            AnsiConsole.MarkupLine("[bold blue]Welcome to CompMath![/]");
            AnsiConsole.MarkupLine("Type [green]'help'[/] for usage information or [red]'exit'[/] to quit.");

            while (true)
            {
                string input = AnsiConsole.Ask<string>("[blue]>[/]");

                if (input.ToLower() == "exit")
                {
                    break;
                }

                ProcessCommand(input.Split(' '));
            }

            AnsiConsole.MarkupLine("[bold]Thank you for using CompMath![/]");
        }

        public void ProcessCommand(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            bool verbose = Array.IndexOf(args, "-v") >= 0 || Array.IndexOf(args, "--verbose") >= 0;
            args = Array.FindAll(args, arg => arg != "-v" && arg != "--verbose");

            switch (args[0].ToLower())
            {
                case "help":
                    DisplayHelp();
                    break;
                case "decimal2binary":
                case "binary2decimal":
                case "hex2binary":
                case "binary2hex":
                case "decimal2hex":
                case "hex2decimal":
                    if (args.Length != 2)
                    {
                        AnsiConsole.MarkupLine($"[red]Invalid command. Use '{args[0]} <number>'[/]");
                    }
                    else
                    {
                        PerformConversion(args[0], args[1], verbose);
                    }
                    break;
                default:
                    AnsiConsole.MarkupLine("[red]Unknown command. Type 'help' for usage information.[/]");
                    break;
            }
        }

        private void DisplayHelp()
        {
            var table = new Table();
            table.AddColumn("Command");
            table.AddColumn("Description");

            table.AddRow("help", "Display this help message");
            table.AddRow("decimal2binary <number>", "Convert a decimal number to binary");
            table.AddRow("binary2decimal <number>", "Convert a binary number to decimal");
            table.AddRow("hex2binary <number>", "Convert a hexadecimal number to binary");
            table.AddRow("binary2hex <number>", "Convert a binary number to hexadecimal");
            table.AddRow("decimal2hex <number>", "Convert a decimal number to hexadecimal");
            table.AddRow("hex2decimal <number>", "Convert a hexadecimal number to decimal");

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[yellow]Options:[/]");
            AnsiConsole.MarkupLine("  [green]-v, --verbose[/]  Show step-by-step conversion process");
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
                    result = PerformStandardConversion(command, input);
                    AnsiConsole.MarkupLine($"[green]Result:[/] {result}");
                }
            }
            catch (FormatException)
            {
                AnsiConsole.MarkupLine("[red]Invalid input format. Please check your input and try again.[/]");
            }
            catch (OverflowException)
            {
                AnsiConsole.MarkupLine("[red]Input is too large. Please enter a smaller number.[/]");
            }
            catch (ArgumentException ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
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

        private string PerformStandardConversion(string command, string input)
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
