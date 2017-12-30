using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayOneSolver : ISolver
    {

        public override string ToString()
        {
            return "Day 1";
        }

        public Tuple<String, String> solve(string input)
        {
            String result1 = null;
            String result2 = null;

            result1 = solvePart1(input);
            result2 = solvePart2(input);

            Tuple<String, String> result = new Tuple<string, string>(result1, result2);

            return result;
        }

        private String solvePart1(String input)
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

        private String solvePart2(String input)
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
    }
}
