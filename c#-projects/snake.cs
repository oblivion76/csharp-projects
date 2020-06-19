using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Snake!";
            Game game = new Game(10, 20);
            bool gameStatus = true;

            while (gameStatus)
            {
                game.Render();

                CheckInput(game);

                game.snake.TakeStep((game.snake.PositionToMove()));

                if (game.snake.CheckForCollision(game))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    gameStatus = false;
                    break;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }

        static void CheckInput(Game game)
        {
            string DirectionInput = Console.ReadLine();

            switch (DirectionInput)
            {
                case "W":
                    game.snake.Direction = game.Up;
                    break;
                case "A":
                    game.snake.Direction = game.Left;
                    break;
                case "S":
                    game.snake.Direction = game.Down;
                    break;
                case "D":
                    game.snake.Direction = game.Right;
                    break;
                default:
                    break;
            }
        }
    }

    class Game 
    {
        public int Width { get; set; }
        public int Height { get; set; }

        #region Directions

        public (int, int) Up = (-1, 0);
        public (int, int) Down = (1, 0);
        public (int, int) Left = (0, -1);
        public (int, int) Right = (0, 1);
        public (int, int) UpLeft = (-1, 1);
        public (int, int) DownRight = (1, -1);
        public (int, int) DownLeft = (-1, -1);
        public (int, int) UpRight = (1, 1);

        #endregion

        public Snake snake { get; set; }

        public Game(int height, int width)
        {
            Height = height;
            Width = width;

            snake = new Snake(Initialize(), Up);
        }

        public string[][] CreateBoard()
        {
            string[][] boardMatrix = new string[Height][];

            for (int i = 0; i < Height; i++)
            {
                boardMatrix[i] = new string[Width];

                for (int j = 0; j < Width; j++)
                {
                    boardMatrix[i][j] = null;
                }
            }

            return boardMatrix;
        }

        public void Render()
        {
            string[][] boardMatrix = CreateBoard();

            Console.ForegroundColor = ConsoleColor.Cyan;

            HorizontalBorder();

            for (int i = 0; i < Height; i++)
            {
                Console.Write("|");

                Console.ForegroundColor = ConsoleColor.Green;

                for (int j = 0; j < Width; j++)
                {
                    int k = 0;
                    foreach ((int, int) position in snake.SnakePos)
                    {
                        k++;
                        if (position == (i, j))
                        {
                            if (k == 1)
                                boardMatrix[i][j] = "X";
                            else
                                boardMatrix[i][j] = "O";       
                        }
                    }
                    if (boardMatrix[i][j] == null)
                        Console.Write(" ");
                    else
                    {
                        Console.Write(boardMatrix[i][j]);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("|\n");
            }

            HorizontalBorder();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void HorizontalBorder()
        {
            Console.Write("+");

            for (int i = 0; i < Width; i++)
                Console.Write("-");

            Console.WriteLine("+");
        }

        public (int, int)[] Initialize()
        {
            var SnakeCoordinates = new (int x, int y)[]
            {
                (2, 2),
                (2, 3),
                (3, 3),
                (4, 3),
                (4, 4),
                (4, 5),
                (4, 6)
            };

            return SnakeCoordinates;
        }
    }

    class Snake 
    {
        public (int, int)[] SnakePos { get; set; }
        public (int, int) Direction { get; set; }

        public Snake((int, int)[] snakePos, (int, int) direction)
        {
            SnakePos = snakePos;
            Direction = direction;
        }        

        public void TakeStep((int, int) position)
        {
            for (int i = SnakePos.Length - 1; i > 0; i--)
                SnakePos[i] = SnakePos[i - 1];
            SnakePos[0] = position;
        }

        public void SetDirection((int, int) direction)
        {
            Direction = direction;
        }

        public (int, int) Head()
        {
            return SnakePos[0];
        }

        public (int, int) PositionToMove()
        {
            return (Head().Item1 + Direction.Item1, Head().Item2 + Direction.Item2);
        }

        public bool CheckForCollision(Game game)
        {
            int i = 0;

            foreach ((int, int) coords in SnakePos)
            {
                i++;
                if (coords == Head() && i > 1)
                {
                    return true;
                }
            }

            if (Head().Item1 < 0)
                return true;
            else if (Head().Item1 > game.Height - 1)
                return true;
            else if (Head().Item2 < 0)
                return true;
            else if (Head().Item2 > game.Width - 1)
                return true;


            return false;
        }
    }

    class Apple
    {

    }
}
