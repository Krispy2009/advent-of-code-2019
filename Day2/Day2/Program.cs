using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{


    class Part1
    {
        public int RunProgram(int[] progInput, int startValue1, int startValue2)
        {
            // Replace values as instructed in part 1
            progInput[1] = startValue1;
            progInput[2] = startValue2;


            int idx = 0;
            while (idx < progInput.Length)
            {
                int opcode = progInput[idx];
                int first_position = progInput[idx + 1];
                int second_position = progInput[idx + 2];
                int destination = progInput[idx + 3];

                switch (opcode)
                {
                    case 1:
                       //Console.WriteLine("Adding");
                        progInput[destination] = progInput[first_position] + progInput[second_position];
                        break;
                    case 2:
                        //Console.WriteLine("Multiplying");

                        progInput[destination] = progInput[first_position] * progInput[second_position];
                        break;
                    case 99:
                        Console.WriteLine("Program Halted!");
                        return progInput[0];

                    default:
                        Console.WriteLine("ERROR!");
                        break;

                }

                idx += 4;
            }
            // If we haven't returned a number by now something has gone wrong
            return -1;
        }

        static void Main(string[] args)
        {
            int[] progInput = { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 10, 19, 2, 6, 19, 23, 1, 23, 5, 27, 1, 27, 13, 31, 2, 6, 31, 35, 1, 5, 35, 39, 1, 39, 10, 43, 2, 6, 43, 47, 1, 47, 5, 51, 1, 51, 9, 55, 2, 55, 6, 59, 1, 59, 10, 63, 2, 63, 9, 67, 1, 67, 5, 71, 1, 71, 5, 75, 2, 75, 6, 79, 1, 5, 79, 83, 1, 10, 83, 87, 2, 13, 87, 91, 1, 10, 91, 95, 2, 13, 95, 99, 1, 99, 9, 103, 1, 5, 103, 107, 1, 107, 10, 111, 1, 111, 5, 115, 1, 115, 6, 119, 1, 119, 10, 123, 1, 123, 10, 127, 2, 127, 13, 131, 1, 13, 131, 135, 1, 135, 10, 139, 2, 139, 6, 143, 1, 143, 9, 147, 2, 147, 6, 151, 1, 5, 151, 155, 1, 9, 155, 159, 2, 159, 6, 163, 1, 163, 2, 167, 1, 10, 167, 0, 99, 2, 14, 0, 0 };

            Part1 part = new Part1();
            int result = part.RunProgram(progInput, 12, 2);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }

    class Part2
    {
        int[] progInput = { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 10, 19, 2, 6, 19, 23, 1, 23, 5, 27, 1, 27, 13, 31, 2, 6, 31, 35, 1, 5, 35, 39, 1, 39, 10, 43, 2, 6, 43, 47, 1, 47, 5, 51, 1, 51, 9, 55, 2, 55, 6, 59, 1, 59, 10, 63, 2, 63, 9, 67, 1, 67, 5, 71, 1, 71, 5, 75, 2, 75, 6, 79, 1, 5, 79, 83, 1, 10, 83, 87, 2, 13, 87, 91, 1, 10, 91, 95, 2, 13, 95, 99, 1, 99, 9, 103, 1, 5, 103, 107, 1, 107, 10, 111, 1, 111, 5, 115, 1, 115, 6, 119, 1, 119, 10, 123, 1, 123, 10, 127, 2, 127, 13, 131, 1, 13, 131, 135, 1, 135, 10, 139, 2, 139, 6, 143, 1, 143, 9, 147, 2, 147, 6, 151, 1, 5, 151, 155, 1, 9, 155, 159, 2, 159, 6, 163, 1, 163, 2, 167, 1, 10, 167, 0, 99, 2, 14, 0, 0 };

    }
}
