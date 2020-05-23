using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a text to reverse: ");
            string input = Console.ReadLine();

            // Put user input into individual character array
            Char[] array = input.ToCharArray();

            Reverse(array);
            Console.WriteLine(array);
        }

        // Reverse each letter in the array
        static void Reverse(char[] text)
        {
            Array.Reverse(text);
        }
    }
}
