using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class DayThreeSolver : Solver
    {
        private const int arraySize = 2048;
        private const int center = arraySize / 2;

        public override string SolvePartOne(string inputString)
        {
            double input = double.Parse(inputString);

            double result = 0.0;

            double sqrt = Math.Sqrt(input);

            double nearestBottomCornerSqrt = Math.Ceiling(sqrt);

            double spiral = (nearestBottomCornerSqrt + 1) / 2;

            double minDist = spiral - 1;

            double nearestBottomCorner = Math.Pow(nearestBottomCornerSqrt, 2);

            double previousBottomCorner = Math.Pow(nearestBottomCornerSqrt - 2, 2);

            double cornerOffset = nearestBottomCornerSqrt;

            double halfSqrt = nearestBottomCornerSqrt / 2;


            if (input <= nearestBottomCorner && input > (nearestBottomCorner - cornerOffset))
            {
                double medianVal = nearestBottomCorner - Math.Floor(halfSqrt);

                if (input == medianVal)
                {
                    result = minDist;
                } else if(input > medianVal)
                {
                    result = minDist + (input - medianVal);
                } else
                {
                    result = minDist + (medianVal - input);
                }
            } else if((input <= (nearestBottomCorner - cornerOffset) && input > (nearestBottomCorner - cornerOffset * 2)))
            {
                double medianVal = (nearestBottomCorner - cornerOffset) - Math.Floor(nearestBottomCornerSqrt / 2);

                if (input == medianVal)
                {
                    result = minDist;
                }
                else if (input > medianVal)
                {
                    result = minDist + ((input - cornerOffset) - medianVal);
                }
                else
                {
                    result = minDist + (medianVal - input);
                }
            } else if((input <= (nearestBottomCorner - cornerOffset * 2) && input > (nearestBottomCorner - cornerOffset * 3)))
            {
                double medianVal = (nearestBottomCorner - cornerOffset * 2) - Math.Floor(nearestBottomCornerSqrt / 2);

                if (input == medianVal)
                {
                    result = minDist;
                }
                else if (input > medianVal)
                {
                    result = minDist + ((input - cornerOffset * 2) - medianVal);
                }
                else
                {
                    result = minDist + (medianVal - input);
                }
            }
            else
            {
                double medianVal = (nearestBottomCorner - cornerOffset * 3) - Math.Floor(nearestBottomCornerSqrt / 2);

                if (input == medianVal)
                {
                    result = minDist;
                }
                else if (input > medianVal)
                {
                    result = minDist + ((input - cornerOffset * 3) - medianVal);
                }
                else
                {
                    result = minDist + (medianVal - input);
                }
            }

            return result.ToString();
        }

        public override string SolvePartTwo(string inputString)
        {
            double answer = double.Parse(inputString);

            int result = 0;

            int count = 1;
            int row = center, col = center;

            int[,] memory = new int[arraySize, arraySize];

            memory[row, col] = count;

            while (count < Math.Pow(arraySize, 2))
            {              

                if (count == 1 || Math.Sqrt(count) % 1 == 0)
                {
                    // calculate size of side
                    int side = count == 1 ? 2 : (int)Math.Sqrt(count)+1;

                    // Move to the position of the next square number
                    col++;
                    row--;

                    for (int i = 0; i < side; i ++)
                    {
                        row++;
                        result = calculateValue(col, row, memory);
                        memory[col, row] = result;
                        count++;

                        if (result >= answer)
                        {
                            return result.ToString();
                        }
                    }

                    for (int i = 0; i < side; i++)
                    {
                        col--;
                        result = calculateValue(col, row, memory);
                        memory[col, row] = result;
                        count++;

                        if (result >= answer)
                        {
                            return result.ToString();
                        }
                    }

                    for (int i = 0; i < side; i++)
                    {
                        row--;
                        result = calculateValue(col, row, memory);
                        memory[col, row] = result;
                        count++;

                        if (result >= answer)
                        {
                            return result.ToString();
                        }
                    }

                    for (int i = 0; i < side; i++)
                    {
                        col++;
                        result = calculateValue(col, row, memory);
                        memory[col, row] = result;
                        count++;

                        if (result >= answer)
                        {
                            return result.ToString();
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Something has gone wrong - expecting a square number here...");
                }
            }

            return "";
        }

        private int calculateValue(int col, int row, int[,] memory)
        {
            int sum = 0;
            
            sum += memory[col, row + 1];
            sum += memory[col, row - 1];
            sum += memory[col - 1, row];
            sum += memory[col - 1, row + 1];
            sum += memory[col - 1, row - 1];
            sum += memory[col + 1, row];
            sum += memory[col + 1, row + 1];
            sum += memory[col + 1, row - 1];

            return sum;
        }

        public override string ToString()
        {
            return "Day 3";
        }
    }
}
