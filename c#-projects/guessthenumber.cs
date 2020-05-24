using System;

namespace GuessTheNumber.Main
{
    class CoreSystem
    {
        #region VariableDeclaration

        Random rand = new Random();
        private int range;
        private int tries;
        private int maxTries = 3;
        private bool gameActive = true;

        #endregion

        // Starts the program
        static void Main(string[] args)
        {
            // Need to call class as an variable to create nonstatic methods
            CoreSystem coreSystem = new CoreSystem();
            coreSystem.Say("Console Started.");
            coreSystem.StartGame();
        }

        // Start the program
        private void StartGame()
        {
            while (gameActive == true) 
            {
                Say("");
                Say("Welcome to Guess the Number!");
                Say("----------------------------");
                Say("Please Select your difficulty: Easy, Medium, or Hard");
                CheckForDifficulty();
                CheckForNumber();
                CheckForRepeat();
            }            
        }

        // The difficulty of the range
        private void CheckForDifficulty()
        {
            string difficulty = Console.ReadLine();
            if (difficulty == "Easy" || difficulty == "easy")
            {
                range = 11;
                Say("Easy (1-10)");
            }
            else if (difficulty == "Medium" || difficulty == "medium")
            {
                range = 26;
                Say("Medium (1-25)");
            }
            else if (difficulty == "Hard" || difficulty == "hard")
            {
                range = 101;
                Say("Hard (1-100)");
            }
            else
            {
                Say("Check your spelling!");
            }
        }

        // Check if player guesses correctly
        private void CheckForNumber()
        {
            int RandomNumberOutput = RandomNumberGenerator();

            // Test if the player still have turns left
            for (tries = maxTries; tries > -1; tries--)
            {
                // See if player guess right
                string userInput = Console.ReadLine();
                int inputInt = Convert.ToInt32(userInput);

                // Player got the correct answer
                if (inputInt == RandomNumberOutput)
                {
                    Say("Correct!");
                    Say("You had " + tries + " tries left!");
                    Say("The number was " + RandomNumberOutput);
                    break;
                }
                // Player gets the wrong answer too many times
                else if (tries == 0)
                {
                    Say("Wrong!");
                    Say("The number was " + RandomNumberOutput);
                    break;
                }
                // Player gets wrong answer and gets a hint
                else if (inputInt != RandomNumberOutput)
                {
                    Say("Wrong!");
                    Say("You have " + tries + " tries left!");
                    
                    if (inputInt > RandomNumberOutput)
                    {
                        Say("The number was too high!");
                    }
                    else if (inputInt < RandomNumberOutput) 
                    {
                        Say("The number was too low!");
                    }
                    else
                    {
                        Say("Please use a number!");
                    }
                }
            }                
        }
        
        // Generate random number
        private int RandomNumberGenerator()
        {
            int RandomNumber = rand.Next(range);
            return RandomNumber;
        }

        // See if the player wants to play again
        private void CheckForRepeat()
        {
            Say("");
            Say("Do you want to play again? (Yes or No)");
            string startAgain = Console.ReadLine();
            
            if (startAgain == "No" || startAgain == "no")
            {
                gameActive = false;
                Say("");
                Say("Game Ended!");
                Console.Clear();
            }
            else
            {
                Say("");
                Say("Game Restarted!");
                Console.Clear();
            }
        }

        // Short form for saying Console.WriteLine
        private void Say(string text)
        {
            Console.WriteLine(text);
        }
    }
}
