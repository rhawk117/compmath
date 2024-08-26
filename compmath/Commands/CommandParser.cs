using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compmath.Commands
{
    public static class CommandParser
    {
        public static int CheckDecimalInput(string input)
        {
            if (int.TryParse(input, out int result) == false)
            {
                Prompts.ErrorMessage("Invalid Command Argument: Input must be based 10");
                throw new ArgumentException(nameof(input));
            }
            return Math.Abs(result);
        }



    }
}
