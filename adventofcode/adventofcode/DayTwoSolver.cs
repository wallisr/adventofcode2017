using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayTwoSolver : Solver
    {
        public override string SolvePartOne(string input)
        {
            int result = 0;

            // split by new line
            string[] rows = input.Split('\n');

            foreach (string row in rows)
            {
                // split by whitespace
                string[] cells = row.Split(' ');

                int min = int.MaxValue;
                int max = int.MinValue;

                foreach (string cell in cells)
                {
                    int val = int.Parse(cell);

                    if(val > max)
                    {
                        max = val;
                    }

                    if(val < min)
                    {
                        min = val;
                    }
                }

                result += max - min;
            }

            return result.ToString();
        }

        public override string SolvePartTwo(string input)
        {
            int result = 0;

            // split by new line
            string[] rows = input.Split('\n');

            foreach (string row in rows)
            {
                // split by whitespace
                string[] cells = row.Split(' ');

                bool found = false;

                foreach (string currentCell in cells)
                {
                    if (found) break;

                    int currentVal = int.Parse(currentCell);

                    foreach(string otherCell in cells)
                    {
                        if(currentCell.Equals(otherCell))
                        {
                            continue;
                        }

                        int otherVal = int.Parse(otherCell);

                        if(currentVal % otherVal == 0)
                        {
                            result += currentVal / otherVal;
                            found = true;
                            break;
                        }
                    }
                }
            }

            return result.ToString();
        }

        public override string ToString()
        {
            return "Day 2";
        }
    }
}
