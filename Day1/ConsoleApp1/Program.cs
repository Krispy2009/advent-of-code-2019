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

        private int getFuel(int mass)

        {
            double  m = mass / 3;
            return Convert.ToInt32(Math.Floor(m)) - 2;
        }

        static void Main(string[] args)
        {

            Problem1 problem = new Problem1();
            string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day1\input.txt";
            string[] lines = File.ReadAllLines(textFile);
            int sum = 0;
            foreach (string line in lines) {
                int mass = Convert.ToInt32(line);
                sum += problem.getFuel(mass);
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
