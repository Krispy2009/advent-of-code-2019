using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            //string textFile = @"C:\Users\krispy\source\repos\advent-of-code-2019\Day6\input.txt";
            //string[] lines = File.ReadAllLines(textFile);

            string[] lines = { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "E)J", "J)K", "K)L", };

            Dictionary<string, ArrayList> orbits = new Dictionary<string, ArrayList>();

            foreach(string line in lines)
            {
                string[] parts = line.Split(')');
                string centerOfOrbit = parts[0];
                string particleInOrbit = parts[1];
                if(orbits.Keys.Contains(centerOfOrbit))
                {

                orbits[centerOfOrbit].Add(particleInOrbit);
                } else
                {
                    ArrayList orbit = new ArrayList { particleInOrbit };
                    orbits.Add(centerOfOrbit, orbit);
                }
            }
            int count = 0;
            
            foreach(string center in orbits.Keys)
            {
                foreach (string item in orbits[center])
                {
                    count++;
                }
            }

            Console.WriteLine(count);


            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
