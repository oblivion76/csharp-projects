using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameStatus = true;
            string player = "";
            int round = 0;

            string[,] board = NewBoard();

            // Loop until game is over
            while (gameStatus)
            {
                // Find current player
                round++;
                if (round % 2 == 1)
                    player = "X ";
                else
                    player = "O ";
                
                // Print the state of the board
                Console.WriteLine("Round {0} {1}'s turn", round, player);
                RenderBoard(board);

                // Get the player move input
                int[] moveCoords = GetMove();

                // Make the move onto the board
                board = MakeMove(board, moveCoords, player);

                // Check for winner
                if (GetWinner(board))
                {
                    Console.WriteLine("Winner!");
                    gameStatus = false;
                    break;
                }                    

                // If winner is not null, exit

                // Board is full without winner, exit

                // Repeat until game is over
                Console.Clear();
            }

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
            while (!IsValidMove(board, coords))
            {
                Console.WriteLine("The spot is already taken! Try again");

                coords = GetMove();
            }

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

        static bool GetWinner(string[,] board)
        {
            string[][,] allLineCoords = GetLineCoords(board);

            for (int i = 0; i < allLineCoords.Length; i++)
            {
                for (int j = 0; j < allLineCoords[i].Length; j++)
                {                   
                    /*
                    Cast<string> converts the string[,] array to an IEnumerable<string>
                    Distinct gets the set of distinct elements in the list.
                    Skip(1) ignores the first item from the previous set.
                    Any returns true if there are any items in the previous set (after the one that was skipped)
                    Finally, the result is negated with !. Note that this means the method will return true if the input array is empty.
                    */
                    if (!allLineCoords[i].Cast<string>().Distinct().Skip(0).Any())
                        return true;                    
                }
            }
            return false;
        }   
           
        static string[][,] GetLineCoords(string[,] board)
        {

            string[,] rows = new string[3, 3];
            string[,] columns = new string[3, 3];
            string[,] diagonals = new string[2, 3];

            string[][,] allCoords = { rows, columns, diagonals };

            // Rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    rows[i, j] = board[i, j];
                }
            }

            // Columns
            for (int k = 0; k < board.GetLength(0); k++)
            {
                for (int l = 0; l < board.GetLength(1); l++)
                {
                    columns[l, k] = board[l, k];
                }
            }

            #region diagonals
            // Diagonals
            diagonals[0, 0] = board[0, 0];
            diagonals[0, 1] = board[1, 1];
            diagonals[0, 2] = board[2, 2];
            diagonals[1, 0] = board[2, 0];
            diagonals[1, 1] = board[1, 1];
            diagonals[1, 2] = board[0, 2];
            #endregion

            return allCoords;
        }
    }
}
