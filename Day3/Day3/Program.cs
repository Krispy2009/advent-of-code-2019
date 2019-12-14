using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Part1
    {

        HashSet<Tuple<Int32, Int32>> myhash1 = new HashSet<Tuple<Int32, Int32>>();
        ArrayList crossings = new ArrayList();

        private Tuple<char, Int32> ParseInstruction(string instruction)
        {
            char direction = instruction[0];
            //Remove the direction from the instructions before converting to an int
            int steps = Convert.ToInt32(instruction.Remove(0, 1));

            return new Tuple<char, Int32>(direction, steps);
        }
        public Tuple<Int32, Int32> GenerateWire1Coordinates(int x, int y, string input)
        {

            Tuple<char, Int32> instruction = ParseInstruction(input);

            int i = 0;
            switch (instruction.Item1)
            {
                case 'R':
                    // Go right from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        x += 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);
                        myhash1.Add(coordinate);
                        i++;
                    }
                    break;
                case 'L':
                    // Go left from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        x -= 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);

                        myhash1.Add(new Tuple<int, int>(x, y));
                        i++;

                    }
                    break;
                case 'U':
                    // Go up from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        y += 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);

                        myhash1.Add(new Tuple<int, int>(x, y));
                        i++;

                    }
                    break;
                case 'D':
                    // Go down from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        y -= 1;
                        myhash1.Add(new Tuple<int, int>(x, y));
                        i++;

                    }
                    break;
                default:
                    throw new Exception("OH NO - Invalid instruction received");

            }
            Console.WriteLine("Wire turns at: <{0},{1}>", x, y);
            return new Tuple<Int32, Int32>(x, y);
        }
        public Tuple<Int32, Int32> GenerateWire2Coordinates(int x, int y, string input)
        {

            Tuple<char, Int32> instruction = ParseInstruction(input);

            int i = 0;
            switch (instruction.Item1)
            {
                case 'R':
                    // Go right from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        x += 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);
                        if (myhash1.Contains(coordinate))
                        {
                            crossings.Add(coordinate);
                        }
                        i++;
                    }
                    break;
                case 'L':
                    // Go left from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        x -= 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);

                        if (myhash1.Contains(coordinate))
                        {
                            crossings.Add(coordinate);
                        }
                        i++;

                    }
                    break;
                case 'U':
                    // Go up from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        y += 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);

                        if (myhash1.Contains(coordinate))
                        {
                            crossings.Add(coordinate);
                        }
                        i++;

                    }
                    break;
                case 'D':
                    // Go down from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                    while (i < instruction.Item2)
                    {
                        y -= 1;
                        Tuple<int, int> coordinate = new Tuple<int, int>(x, y);

                        if (myhash1.Contains(coordinate))
                        {
                            crossings.Add(coordinate);
                        }
                        i++;

                    }
                    break;
                default:
                    throw new Exception("OH NO - Invalid instruction received");

            }
            Console.WriteLine("Wire turns at: <{0},{1}>", x, y);
            return new Tuple<Int32, Int32>(x, y);
        }

        public int CalculateDistanceFrom0(Tuple<int, int> coordinate)
        {

            int distance = Math.Abs(coordinate.Item1) + Math.Abs(coordinate.Item2);
            return distance;
        }


        //static void Main(string[] args)
        //{

        //    Part1 part = new Part1();

        //    int x = 0;
        //    int y = 0;
        //    //Store the coordinates of wire 1 in a set for fast lookups later

        //    string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day3\input.txt";
        //    string[] wires = File.ReadAllLines(textFile);

        //    string[] wire1 = wires[0].Split(',');
        //    string[] wire2 = wires[1].Split(',');
        //    Tuple<int, int> coordinates = new Tuple<int, int>(x, y);

        //    foreach(string instruction in wire1)
        //    {
        //        coordinates = part.GenerateWire1Coordinates(x, y, instruction);
        //        x = coordinates.Item1;
        //        y = coordinates.Item2;
        //    }

        //    // Reset coordinates for second wire
        //    x= 0;
        //    y = 0;
        //    foreach(string instruction in wire2) {
        //        coordinates = part.GenerateWire2Coordinates(x, y, instruction);
        //        x = coordinates.Item1;
        //        y = coordinates.Item2;
        //    }

        //    Console.WriteLine("Found {0} crossings", part.crossings.Count);

        //    int smallestDistance = int.MaxValue;
        //    Tuple<int, int> smallestCoordinate = new Tuple<int, int>(0,0);
        //    foreach(Tuple<int, int> coordinate in part.crossings)
        //    {
        //        int distance = part.CalculateDistanceFrom0(coordinate);
        //        if(distance < smallestDistance)
        //        {
        //            smallestDistance = distance;
        //            smallestCoordinate = coordinate;
        //        }
        //    }

        //    Console.WriteLine("Smallest Distance: {0} \n Coordinates <{1},{2}>", smallestDistance, smallestCoordinate.Item1, smallestCoordinate.Item2);


        //    Console.ReadKey();

        //    }
    }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string WireName { get; set; }
        public int Step { get; set; }

        public Coordinate(int x, int y, string wireName, int step)
        {
            X = x;
            Y = y;
            WireName = wireName;
            Step = step;
        }

        public int CalculateDistanceFrom0()
        {

            int distance = Math.Abs(X) + Math.Abs(Y);
            return distance;

        }
        public override bool Equals(object obj)
        {

            Coordinate c = obj as Coordinate;

            return X == c.X && Y == c.Y;
        }

        public override int GetHashCode()
        {
            // Generate a hash by creating a tuple object and getting the hash of that
            //this takes in to consideration the position of the numbers in the tuple (1,2) != (2,1)
            return Tuple.Create(X, Y).GetHashCode();
        }

    }

    class Instruction
    {
        readonly char direction;
        private int steps;

        public Instruction(string instruction)
        {

            char direction = instruction[0];
            //Remove the direction from the instructions before converting to an int
            int steps = Convert.ToInt32(instruction.Remove(0, 1));

            this.direction = direction;
            this.steps = steps;

        }

        public char GetDirection()
        {
            return direction;
        }

        public int GetSteps()
        {
            return steps;
        }
    }

    class Part2
    {

        HashSet<Coordinate> coordinates = new HashSet<Coordinate>();
        ArrayList wire1Steps = new ArrayList();
        ArrayList wire2Steps = new ArrayList();
        ArrayList crossings = new ArrayList();

        public Coordinate GenerateCoordinates(int x, int y, string input, string wireName, int step)
        {
            Coordinate newCoordinate = new Coordinate(x, y, wireName, step);
            Instruction instruction = new Instruction(input);

            int i = 0;
            int steps = instruction.GetSteps();
            char direction = instruction.GetDirection();

            while (i < steps)
            {
                switch (direction)
                {
                    case 'R':
                        // Go right from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                        x += 1;
                        i++;
                        break;
                    case 'L':
                        // Go left from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                        x -= 1;
                        i++;
                        break;
                    case 'U':
                        // Go up from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                        y += 1;
                        i++;
                        break;
                    case 'D':
                        // Go down from the initial x,y coordinates, add the generated coordinates in the set and return the last coordinate generated
                        y -= 1;
                        i++;
                        break;
                    default:
                        throw new Exception("OH NO - Invalid instruction received");
                }
                step += 1;
                newCoordinate = new Coordinate(x, y, wireName, step);
                if (wireName == "A")
                {

                    coordinates.Add(newCoordinate);

                }
                else if (coordinates.Contains(newCoordinate))
                {
                    crossings.Add(newCoordinate);
                }
            }
            Console.WriteLine("Wire {0} turns at: <{1},{2}>", wireName, x, y);
            return newCoordinate;
        }

        static void Main(string[] args)
        {

            Part2 part = new Part2();

            int x = 0;
            int y = 0;

            string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day3\input.txt";
            string[] wires = File.ReadAllLines(textFile);

            string[] wire1 = wires[0].Split(',');
            string[] wire2 = wires[1].Split(',');

            // This is the origin
            Coordinate coordinate = new Coordinate(x, y, "A", 0);

            foreach (string instruction in wire1)
            {
                coordinate = part.GenerateCoordinates(coordinate.X, coordinate.Y, instruction, coordinate.WireName, coordinate.Step);
                x = coordinate.X;
                y = coordinate.Y;
            }


            // Reset coordinates for second wire

            coordinate = new Coordinate(0, 0, "B", 0);
            foreach (string instruction in wire2)
            {
                coordinate = part.GenerateCoordinates(coordinate.X, coordinate.Y, instruction, coordinate.WireName, coordinate.Step);
                x = coordinate.X;
                y = coordinate.Y;
            }
            Console.WriteLine("Generated {0} Coordinates for Wire A", part.coordinates.Count);
            Console.WriteLine("Found {0} crossings", part.crossings.Count);

            int smallestDistance = int.MaxValue;
            Coordinate smallestCoordinate = new Coordinate(0, 0, "A", 0);
            foreach (Coordinate c in part.crossings)
            {
                int distance = c.CalculateDistanceFrom0();
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    smallestCoordinate = c;
                }
            }

            Console.WriteLine("Smallest Distance: {0} \n Coordinates <{1},{2}>", smallestDistance, smallestCoordinate.X, smallestCoordinate.Y);


            Console.ReadKey();

        }
    }


}
