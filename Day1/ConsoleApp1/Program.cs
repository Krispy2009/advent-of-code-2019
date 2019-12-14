using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Problem1
    {

        public int getFuel(int mass)

        {
            double m = mass / 3;
            return Convert.ToInt32(Math.Floor(m)) - 2;
        }

        //static void Main(string[] args)
        //{

        //    Problem1 problem = new Problem1();
        //    string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day1\input.txt";
        //    string[] lines = File.ReadAllLines(textFile);
        //    int sum = 0;
        //    foreach (string line in lines) {
        //        int mass = Convert.ToInt32(line);
        //        sum += problem.getFuel(mass);
        //    }
        //    Console.WriteLine(sum);
        //    Console.ReadKey();
        //}
    }

    class Problem2
    {

        static void Main(string[] args)
        {
            Problem1 problem1 = new Problem1();
            string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day1\input.txt";
            string[] lines = File.ReadAllLines(textFile);
            int sum = 0;
            foreach (string line in lines)
            {
                int original_mass = Convert.ToInt32(line);
                int new_mass = problem1.getFuel(original_mass);
                sum += new_mass;

                while (problem1.getFuel(new_mass) >= 0)
                {
                    new_mass = problem1.getFuel(new_mass);
                    sum += new_mass;
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
