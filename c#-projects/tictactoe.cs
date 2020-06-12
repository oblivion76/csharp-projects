using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameOngoing = true;
            string[,] board = NewBoard();           

            RenderBoard(board);

            int[] moveCoords = GetMove();

            while (!IsValidMove(board, moveCoords))
            {
                Console.WriteLine("The spot is already taken! Try again");

                moveCoords = GetMove();
            }

            board = MakeMove(board, moveCoords, "X ");
            RenderBoard(board);

            #region While Loop
            // Loop through every turn until game is over
            // while (gameOngoing)
            //{
            // Find current player

            // Print the state of the board

            // Get the player move input

            // Make the move onto the board

            // Check for winner

            // If winner is not null, exit

            // Board is full without winner, exit

            // Repeat until game is over


            //}
            #endregion

            Console.ReadLine();
        }

        // Generate an empty board
        static string[,] NewBoard()
        {
            string[,] board = new string[,]
            {
                { "  ", "  ", "  " },
                { "  ", "  ", "  " },
                { "  ", "  ", "  " }
            };

            return board;
        }

        // Print the current board
        static void RenderBoard(string[,] board)
        {
            int length = board.GetLength(0);
            int width = board.GetLength(1);

            Console.WriteLine(" X 0 1 2");
            Console.WriteLine("Y  ------");

            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} |", i);
                for (int j = 0; j < width; j++)
                {
                    Console.Write("{0}", board[i, j]);
                }
                Console.Write("| \n");
            }

            Console.WriteLine("   ------");
        }

        // Get the move from the player
        static int[] GetMove()
        {
            int[] moveCoords = new int[2];

            Console.WriteLine("What are your Move's X co-ordinate?: ");
            string resultX = Console.ReadLine();           

            // If number is not valid
            while (!Int32.TryParse(resultX, out moveCoords[1]))
            {
                Console.WriteLine("Not a valid number, try again.");

                resultX = Console.ReadLine();
            }

            Console.WriteLine("What are your Move's Y co-ordinate?: ");
            string resultY = Console.ReadLine();

            // If number is not valid
            while (!Int32.TryParse(resultY, out moveCoords[0]))
            {
                Console.WriteLine("Not a valid number, try again.");

                resultY = Console.ReadLine();
            }

            return moveCoords;
        }

        // Put the move onto a new board
        static string[,] MakeMove(string[,] board, int[] coords, string player)
        {
            board[coords[0], coords[1]] = player;

            return board;
        }

        // Check if the move is valid
        static bool IsValidMove(string[,] board, int[] coords)
        {
            if (board[coords[0], coords[1]] != "  ")
                return false;
            else
                return true;
        }
    }
}
