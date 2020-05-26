using System;

namespace AlphabetToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type a sentence you want to convert!");
            string input = Console.ReadLine();

            Char[] charArray;

            charArray = ConvertToArray(input);
            FindLetterPosInAlphabet(charArray);
        }

        // Turn the string into each individual letter
        static Char[] ConvertToArray(string text)
        {
            Char[] charArray = text.ToCharArray();

            return charArray;
        }  

        // A = 1, B = 2, etc...
        static void FindLetterPosInAlphabet(Char[] array) 
        {
            // Loop through each character
            foreach (char item in array)
            {
                // If the character is a letter
                if (Char.IsLetter(item))
                {
                    item.ToString();

                    int index = (int)item % 32;
                    Console.Write(index);
                }
                else
                {
                    Console.Write(item);
                }                                
            }
        }
    }
}
