using System;
using System.Linq;

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
                    Console.WriteLine("Game Over! Score: {0}", game.Score);
                    gameStatus = false;
                    break;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }

        // Check where player wants to move
        static void CheckInput(Game game)
        {
            string DirectionInput = Console.ReadLine();

            switch (DirectionInput.ToUpper())
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

        public int Score { get; set; }

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
        public Apple apple { get; set; }

        // Set the size of the board and 
        public Game(int height, int width)
        {
            Height = height;
            Width = width;

            snake = new Snake(Initialize(), Up);
            apple = new Apple(this);
        }

        // Create empty board
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

        // Render the board while checking 
        // which squares has the snake and apple
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

                    if ((i, j) == apple.ApplePos)
                    {
                        boardMatrix[i][j] = "*";
                    }

                    if (boardMatrix[i][j] == null)
                        Console.Write(" ");
                    else if (boardMatrix[i][j] == "*")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(boardMatrix[i][j]);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
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

        // Create horizontal border
        public void HorizontalBorder()
        {
            Console.Write("+");

            for (int i = 0; i < Width; i++)
                Console.Write("-");

            Console.WriteLine("+");
        }

        // Set Snake coords
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

        // Create the Snake Position
        public Snake((int, int)[] snakePos, (int, int) direction)
        {
            SnakePos = snakePos;
            Direction = direction;
        }        

        // Move the Snake Coords
        public void TakeStep((int, int) position)
        {
            for (int i = SnakePos.Length - 1; i > 0; i--)
                SnakePos[i] = SnakePos[i - 1];
            SnakePos[0] = position;
        }

        // Set the direction property
        public void SetDirection((int, int) direction)
        {
            Direction = direction;
        }

        // Get the head of the snake
        public (int, int) Head()
        {
            return SnakePos[0];
        }

        // Calculate the position to move to
        public (int, int) PositionToMove()
        {
            return (Head().Item1 + Direction.Item1, Head().Item2 + Direction.Item2);
        }

        // Check if the snake collides with something
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

            if (Head() == game.apple.ApplePos)
            {
                (int, int) tail = (game.snake.SnakePos[^1].Item1 + 1, game.snake.SnakePos[^1].Item2);

                game.Score++;
                game.apple.Generate();
                SnakePos = SnakePos.Append(tail).ToArray();
            }

            return false;
        }
    }

    class Apple
    {
        public (int, int) ApplePos { get; set; }

        Game game;

        // Get the game class started
        public Apple(Game gameClass)
        {
            game = gameClass;
        }

        // Generate random apple location
        public void Generate()
        {
            Random random = new Random();

            int x = random.Next(0, game.Height);
            int y = random.Next(0, game.Width);

            ApplePos = (x, y);
        }
    }
}
