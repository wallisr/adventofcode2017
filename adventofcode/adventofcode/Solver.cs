using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    abstract class Solver : ISolver
    {
        public Tuple<string, string> solve(string input)
        {
            String result1 = SolvePartOne(input);
            String result2 = SolvePartTwo(input);

            Tuple<String, String> result = new Tuple<string, string>(result1, result2);

            return result;
        }

        abstract public string SolvePartOne(string inputString);

        abstract public string SolvePartTwo(string inputString);

        public override string ToString()
        {
            return "Day X";
        }

    }
}
