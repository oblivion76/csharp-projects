using System;

namespace FizzBuzz
{
    class Program
    {
        /*
            Prints out numbers from 1 to 100
            If the number is a multiple of 3, it will print Fizz
            If the number is a multiple of 5, it will print Buzz
            If the number is a multiple of both 3 and 5, it will print FizzBuzz
        */
        static void Main(string[] args)
        {
            int length = 101;

            // Print numbers from 1 to 100
            for (int i = 1; i < length; i++)
            {
                Console.WriteLine(CheckForMultiple(i));
            }
        }

        // Check if the number printed is a multiple of 3 or 5
        static string CheckForMultiple(int number)
        {
            // If a multiple of 3
            if (number % 3 == 0)
            {
                // If both multiple of 3 and 5
                if (number % 5 == 0)
                {
                    return ("FizzBuzz");
                }
                else
                {
                    return ("Fizz");
                }
            }
            // If a multiple of 5
            else if (number % 5 == 0)
            {
                return ("Buzz");
            }
            // If the number is not a multiple of 3 or 5
            else
            {
                return number.ToString();
            }                     
        }
    }
}
