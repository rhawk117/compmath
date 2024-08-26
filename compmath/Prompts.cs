using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath
{
    public static class Prompts
    {

        public static string divider = new string('=', 100);

        public static void Header()
        {
            AnsiConsole.MarkupLine($"[bold green]{divider}[/]\n");
            AnsiConsole.Write(
                new FigletText("CompMath").Color(Color.Green)
            );
            AnsiConsole.MarkupLine("\n\t[bold blue][ developed by: rhawk117 ][/]");
            AnsiConsole.MarkupLine("\n\t[bold blue](i) Press ENTER to Continue.. (i)[/]");
            AnsiConsole.MarkupLine($"[bold green]{divider}[/]\n");
        }

        public static string Center(string text)
        {
            int padding = (Console.WindowWidth - text.Length) / 2;
            return new string(' ', padding) + text;
        }




    }
}
