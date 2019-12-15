using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{

    class Computer
    {
        public ArrayList Output { get; set; }
        public ArrayList Input { get; set; }
        int[] progInstructions;

        public Computer(ArrayList input, ArrayList output, int[] progInstructions)
        {
            this.Output = output;
            this.Input = input;
            this.progInstructions = progInstructions;
        }

        public int RunProgram()
        {

            int inputValue = int.MaxValue;

            if (Input.Count > 0)

            {
                inputValue = (int)Input[0];
                Input.RemoveAt(0);
            }

            int idx = 0;
            while (idx < progInstructions.Length)
            {
                int opcode = progInstructions[idx];
                int first_position;
                int second_position;
                int destination;





                switch (opcode)
                {
                    case 1:
                        //Console.WriteLine("Adding");
                        first_position = progInstructions[idx + 1];
                        second_position = progInstructions[idx + 2];
                        destination = progInstructions[idx + 3];

                        progInstructions[destination] = progInstructions[first_position] + progInstructions[second_position];
                        idx += 4;
                        break;
                    case 2:
                        first_position = progInstructions[idx + 1];
                        second_position = progInstructions[idx + 2];
                        destination = progInstructions[idx + 3];

                        //Console.WriteLine("Multiplying");

                        progInstructions[destination] = progInstructions[first_position] * progInstructions[second_position];
                        idx += 4;
                        break;
                    case 3:
                        first_position = progInstructions[idx + 1];

                        if (inputValue == int.MaxValue) { Console.WriteLine("Tried to read input but no input exists"); return -1; }
                        progInstructions[first_position] = inputValue;
                        idx += 2;
                        break;
                    case 4:
                        first_position = progInstructions[idx + 1];

                        Output.Add(progInstructions[first_position]);
                        idx += 2;
                        break;
                    case 99:
                        Console.WriteLine("Program Halted!");
                        return progInstructions[0];

                    default:
                        ComplexInstruction inst = new ComplexInstruction(opcode);


                        Console.WriteLine("parameters?");
                        break;

                }

            }
            // If we haven't returned a number by now something has gone wrong
            return -1;
        }
    }

    internal class ComplexInstruction
    {
        private int opcode { get; set; }
        private int modeParam1 { get; set; }
        private int modeParam2 { get; set; }
        private int modeParam3 { get; set; }

        public ComplexInstruction(int opcode)
        {
            ParseOpcode(opcode);
        }

        public void ParseOpcode(int opcode)
        {
            // The opcode is 5 characters long that might have a leading zero
            string paddedOpcode = opcode.ToString().PadLeft(5, '0');
            // The actual opcode is the last two characters
            opcode = Convert.ToInt32(paddedOpcode[3] + paddedOpcode[4]);
            modeParam1 = Convert.ToInt32(paddedOpcode[2]);
            modeParam2 = Convert.ToInt32(paddedOpcode[1]);
            modeParam3 = Convert.ToInt32(paddedOpcode[0]);

        }
    }

    class Part1
    {
        static void Main(string[] args)
        {
            ArrayList input = new ArrayList();
            ArrayList output = new ArrayList();
            //int[] progInstructions = { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 37, 61, 225, 101, 34, 121, 224, 1001, 224, -49, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 224, 223, 223, 1101, 67, 29, 225, 1, 14, 65, 224, 101, -124, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1102, 63, 20, 225, 1102, 27, 15, 225, 1102, 18, 79, 224, 101, -1422, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 1, 224, 1, 223, 224, 223, 1102, 20, 44, 225, 1001, 69, 5, 224, 101, -32, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1102, 15, 10, 225, 1101, 6, 70, 225, 102, 86, 40, 224, 101, -2494, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1102, 25, 15, 225, 1101, 40, 67, 224, 1001, 224, -107, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 2, 126, 95, 224, 101, -1400, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 151, 84, 224, 101, -2100, 224, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 329, 101, 1, 223, 223, 1107, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 8, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 359, 101, 1, 223, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 1001, 223, 1, 223, 1008, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 1001, 223, 1, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 479, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 509, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 539, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 554, 1001, 223, 1, 223, 1107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 569, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 599, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 614, 1001, 223, 1, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 644, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 659, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226 };

            // int[] progInstructions = { 3, 0, 4, 0, 99 };
            int[] progInstructions = { 1002, 4, 3, 4, 33 };

            input.Add(1);

            Computer computer = new Computer(input, output, progInstructions);
            computer.RunProgram();

            Console.WriteLine(computer.Output[0]);
            Console.ReadKey();
        }


    }
}
