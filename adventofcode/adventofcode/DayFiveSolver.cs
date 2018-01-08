using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayFiveSolver : Solver
    {
        public override string SolvePartOne(string inputString)
        {
            int result = 0;

            string[] strings = inputString.Split('\n');

            int[] instructions = new int[strings.Length];

            for(int i = 0; i < strings.Length; i++)
            {
                instructions[i] = int.Parse(strings[i]);
            }

            int instIndex = 0;

            while (instIndex < instructions.Length && instIndex >= 0)
            {
                int temp = instIndex;

                instIndex += instructions[instIndex];

                instructions[temp]++;

                result++;
            }

            return result.ToString();
        }

        public override string SolvePartTwo(string inputString)
        {
            int result = 0;

            string[] strings = inputString.Split('\n');

            int[] instructions = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                instructions[i] = int.Parse(strings[i]);
            }

            int instIndex = 0;

            while (instIndex < instructions.Length && instIndex >= 0)
            {
                int temp = instIndex;

                instIndex += instructions[instIndex];

                if (instructions[temp] >= 3)
                {
                    instructions[temp]--;
                }
                else
                {
                    instructions[temp]++;
                }                

                result++;
            }

            return result.ToString();
        }

        public override string ToString()
        {
            return "Day 5";
        }
    }
}
