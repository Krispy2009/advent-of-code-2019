using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Parts
    {

        public bool HasIdenticalAdjacentDigits(int number)
        {
            string num = number.ToString();
            char prevChar = num[0];
            num = num.Remove(0, 1);
            int idx = 0;
            bool hasMoreThanTwo = false;

            foreach (char c in num)

            {
                if (c == prevChar)
                {

                    bool isLastOne = idx == num.Length - 1;

                    if (isLastOne && !hasMoreThanTwo || idx < num.Length-1 && num[idx + 1] != c && !hasMoreThanTwo)
                    {

                        return true;
                    }
                    else
                    {
                        // Three or more detected! Abort! Abort! Check if there's a chance for another double digit later
                        if (idx > 2)
                        {
                            return false;
                        }
                        else
                        {
                            hasMoreThanTwo = true;
                            prevChar = c;
                        }
                    }
                }
                else
                {
                    hasMoreThanTwo = false;
                    prevChar = c;
                }
                idx++;
            }
            return false;

        }

        public bool HasIncreasingDigits(int number)
        {
            string num = number.ToString();
            char prevChar = num[0];
            num = num.Remove(0, 1);
            foreach (char c in num)
            {
                if (prevChar <= c)
                {
                    prevChar = c;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool AllDigitsTheSame(int number)
        {
            string num = number.ToString();
            char firstChar = num[0];
            
            foreach (char c in num)
            {
                if(firstChar != c)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            /*
            It is a six-digit number.
            The value is within the range given in your puzzle input.
            Two adjacent digits are the same (like 22 in 122345).
            Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).
            Other than the range rule, the following are true
            111111 meets these criteria (double 11, never decreases).
            223450 does not meet these criteria (decreasing pair of digits 50).
            123789 does not meet these criteria (no double).

            my input: 108457-562041
            */
            Parts parts = new Parts();


            int low = 108457;
            int high = 562041;
            int count = 0;


            while (low <= high)
            {
                if (parts.AllDigitsTheSame(low)) { }

                else if (parts.HasIdenticalAdjacentDigits(low) && parts.HasIncreasingDigits(low)) { Console.WriteLine(low);  count++; }
                low++;
            }

            Console.WriteLine(count);

            Console.ReadKey();

        }
    }
}
