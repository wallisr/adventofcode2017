using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayOneSolver : Solver
    {

        public override String SolvePartOne(String input)
        {
            double result = 0;

            char[] charArray = input.ToCharArray();

            for(int i = 0; i < charArray.Length; i++)
            {

                if (i != charArray.Length-1)
                {
                    // Does this char match the next one?
                    if(charArray[i] == charArray[i+1])
                    {
                        result += Char.GetNumericValue(charArray[i]);
                    }
                } else
                {
                    // Does this char match the first one?
                    if (charArray[i] == charArray[0])
                    {
                        result += Char.GetNumericValue(charArray[i]);
                    }
                }
            }

            return result.ToString();
        }

        public override string SolvePartTwo(String input)
        {
            double result = 0;

            char[] charArray = input.ToCharArray();

            int maxIndex = charArray.Length - 1;
            int offset = charArray.Length / 2;

            for (int i = 0; i < charArray.Length; i++)
            {
                int localOffset = (i + offset > maxIndex) ? (i + offset) - charArray.Length : i + offset;

                // Does this char match the one at the offset?
                if (charArray[i] == charArray[localOffset])
                {
                    result += Char.GetNumericValue(charArray[i]);
                }
            }

            return result.ToString();
        }

        public override string ToString()
        {
            return "Day 1";
        }
    }
}
