using System;
using System.Collections.Generic;

namespace LoveCalculator
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            List<string> people = new List<string>();

            people = AskForInput();
            
            int percent = Calculate();            

            string bar = CreateBar(percent);

            Console.WriteLine(people);

            RenderMessage(percent, people, bar);
        }

        // Choose two people to select
        static List<string> AskForInput()
        {
            List<string> array = new List<string>();

            Console.WriteLine("Choose two people to ship below!");

            Console.Write("1: ");
            string personOne = Console.ReadLine().ToString(); 

            Console.WriteLine("");

            Console.Write("2: ");
            string personTwo = Console.ReadLine().ToString(); 

            array.Add(personOne);
            array.Add(personTwo);

            return array;
        }

        // Get random percent
        static int Calculate()
        {
            int percent = random.Next(0, 101);

            return percent;
        }

        // Create a bar that represents how large the percent is
        static string CreateBar(int percent)
        {
            string bar = "";

            percent /= 10;

            for (int i = 0; i <= percent; i++)
            {
                bar += "|";
            }

            // Add spaces to make it fit better
            while (bar.Length < 11)
            {
                bar += " ";
            }

            return bar;
        }

        // Render the final message
        static void RenderMessage(int percent, List<string> stringList, string bar)
        {
            Console.Clear();
            Console.WriteLine("Here are the results!");
            Console.WriteLine("{0} + {1}", stringList[0], stringList[1]);
            Console.Write("{0}% {1}", percent, bar);
        }
    }
}
