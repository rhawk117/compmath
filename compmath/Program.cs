using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter();
            VerboseConversions verboseConverter = new VerboseConversions();
            CommandLineInterface cli = new CommandLineInterface(converter, verboseConverter);

            if (args.Length == 0)
            {
                cli.RunInteractive();
            }
            else
            {
                cli.ProcessCommands(args);
            }
        }
    }
}
