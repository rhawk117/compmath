using Spectre.Console;
using System;

namespace compmath
{
    public static class Prompts
    {
        private static string divider = new string('=', Console.WindowWidth);

        public static void Header()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold green]{divider}[/]");
            AnsiConsole.Write(new FigletText("CompMath").Color(Color.Green));
            AnsiConsole.MarkupLine("[italic blue] \t\t(^) made by: rhawk117 (v) [/]");
            AnsiConsole.MarkupLine($"[bold green]{divider}[/]");
            AnsiConsole.MarkupLine("[bold yellow]\t\tPress ENTER to Continue[/]");
            Console.ReadKey();
            AnsiConsole.Clear();
        }

        public static void InfoMessage(string text) =>
            AnsiConsole.MarkupLine($"[bold green](i) {text} (i)[/]");

        public static void Welcome(string text) =>
            AnsiConsole.MarkupLine($"[bold italic cyan] {text} [/]");

        public static void ErrorMessage(string errorMsg) =>
            AnsiConsole.MarkupLine($"[bold red](!) {errorMsg} (!)[/]");

        public static void VerboseMessage(string verboseInfo) =>
            AnsiConsole.MarkupLine($"[italic blue](*) {verboseInfo} (*)[/]");

        public static void ConvertedOutput(string convertedNumber) =>
            AnsiConsole.MarkupLine($"[bold yellow](>) {convertedNumber} (<)[/]");
    }
}
