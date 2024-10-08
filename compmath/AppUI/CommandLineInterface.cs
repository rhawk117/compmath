﻿using Spectre.Console;
using System;
using compmath.Commands;

namespace compmath
{
    public class CommandLineInterface
    {
        private Converter standardCalc;
        private VerboseConversions verboseCalc;

        public CommandLineInterface(Converter converter, VerboseConversions verboseConverter)
        {
            standardCalc = converter;
            verboseCalc = verboseConverter;
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
                   arg != "-v" && arg != "--verbose"
            );

            switch (args[0].ToLower())
            {
                case "exit": return;

                case "decimal2binary":
                case "binary2decimal":
                case "hex2binary":
                case "binary2hex":
                case "decimal2hex":
                case "hex2decimal":
                    HandleCommand(args, verbose);
                    break;

                case "help":
                    DisplayHelp();
                    break;

                default:
                    Prompts.ErrorMessage("Unknown command. Type 'help' for example usage and additional information.");
                    break;
            }
        }

        private void HandleCommand(string[] args, bool verbose)
        {
            if (args.Length != 2)
            {
                Prompts.ErrorMessage(string.Format(
                    "Invalid Command, cannot parse input. Use '{0} <number>'", args[0])
                );
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

                if (result == string.Empty) DisplayHelp();
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
                    return verboseCalc.DecimalToBinary(CommandParser.CheckDecimalInput(input));

                case "binary2decimal":
                    return verboseCalc.BinaryToDecimal(input);

                case "hex2binary":
                    return verboseCalc.HexToBinary(input);

                case "binary2hex":
                    return verboseCalc.BinaryToHex(input);

                case "decimal2hex":
                    return verboseCalc.DecimalToHex(CommandParser.CheckDecimalInput(input));

                case "hex2decimal":
                    return verboseCalc.HexToDecimal(input);

                default:
                    Prompts.ErrorMessage(
                        "Command Argument Invalid and Could not be parsed, Type help to view all commands & Syntax"
                     );
                    return string.Empty;
            }
        }

        private string StandardConversion(string command, string input)
        {
            switch (command.ToLower())
            {
                case "decimal2binary":
                    return standardCalc.DecimalToBinary(CommandParser.CheckDecimalInput(input));

                case "binary2decimal":
                    return standardCalc.BinaryToDecimal(input).ToString();

                case "hex2binary":
                    return standardCalc.HexToBinary(input);

                case "binary2hex":
                    return standardCalc.BinaryToHex(input);

                case "decimal2hex":
                    return standardCalc.DecimalToHex(CommandParser.CheckDecimalInput(input));

                case "hex2decimal":
                    return standardCalc.HexToDecimal(input).ToString();

                default:
                    Prompts.ErrorMessage(
                        "Command Argument Invalid and Could not be parsed, Type help to view all commands & Syntax");
                    return string.Empty;
            }
        }







    }
}
