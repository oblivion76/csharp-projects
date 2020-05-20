using System;

namespace FindPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            while (true)
            {
                program.FindInput();
            }
        }

        // Find the user Input
        private void FindInput()
        {
            Console.WriteLine("Please type out how many places of PI you want. (Limit is 15)");
            string placeInput = Console.ReadLine();
            
            // Turn user input into string
            int maxSpaces = 15;
            int space;
            Int32.TryParse(placeInput, out space);
            
            // Check if userinput is past the limit
            if (space < maxSpaces)
            {
                Render(space);
            }
            else
            {
                Render(maxSpaces);
            }
        }

        // Render PI with the precision that the user chooses
        private void Render(int places)
        {
            // NumberFormatInfo setPrecision = new NumberFormatInfo();

            // setPrecision.NumberDecimalDigits = places;

            double pi = Math.PI;
            // Console.WriteLine(pi.ToString("N", setPrecision));

            pi = Math.Round(pi, places);
            Console.WriteLine(pi);
        }
    }
}
