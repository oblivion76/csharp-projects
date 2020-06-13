using System;

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
                    Console.WriteLine("{0} has won!", player);
                    RenderBoard(board);
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

        // Check for winner
        static bool GetWinner(string[,] board)
        {
            // Rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] != "  ")
                {
                    if (board[i, 0] == board[i, 1])
                    {
                        if (board[i, 0] == board[i, 2])
                            return true;
                    }
                }                
            }

            // Columns
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[0, j] != "  ")
                {
                    if (board[0, j] == board[1, j])
                    {
                        if (board[0, j] == board[2, j])
                            return true;
                    }
                }               
            }

            // Diagonals
            if (board[0, 0] != "  ")
            {
                if (board[0, 0] == board[2, 2])
                {
                    if (board[0, 0] == board[1, 1])
                        return true;
                }
            }
            if (board[2, 0] != "  ")
            {
                if (board[2, 0] == board[0, 2])
                {
                    if (board[2, 0] == board[1, 1])
                        return true;
                }
            }

            return false;
        }   
    }
}
