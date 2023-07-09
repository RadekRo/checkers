using System;

namespace checkers
{
    internal class Program
    {
        static readonly char[] avaliableLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private const int BoardSize = 8;

        static char[,] board;

        static void InitializeBoard()
        {
            board = new char[BoardSize, BoardSize]
            {
                { '-', 'B', '-', 'B', '-', 'B', '-', 'B' },
                { 'B', '-', 'B', '-', 'B', '-', 'B', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', 'W', '-', 'W', '-', 'W', '-', 'W' },
                { 'W', '-', 'W', '-', 'W', '-', 'W', '-' },
            };
        }
        static void DrawBoard(char currentPlayer)
        {
            Console.Clear();
            Console.WriteLine("   A B C D E F G H");
            Console.WriteLine("  -----------------");
            for (int row = 0; row < BoardSize; row++)
            {
                Console.Write(row + 1 + " |");
                for (int col = 0; col < BoardSize; col++)
                {
                    Console.Write(board[row, col] + "|");
                }
                Console.WriteLine();
                Console.WriteLine("  -----------------");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\u25A0 RUCH GRACZA: " + currentPlayer);
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static Tuple<int, int> GetUserStartingCoordinates(char currentUser)
        {
            bool validUserEntry = false;
            int x = 0;
            int y = 0;
            while (!validUserEntry)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Podaj współrzędne pionka, którym chcesz się ruszyć (np. 'A1', 'H8'): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var userInput = Console.ReadLine();
                    var capitalizedInput = userInput.ToUpper();

                    if (validateUserInput(capitalizedInput))
                    {
                        x = int.Parse(capitalizedInput[1].ToString()) - 1;
                        y = SwitchUserInput(capitalizedInput[0]);
                        validUserEntry = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pole poza zasięgiem planszy!");
                        ///Needed discussion if we want to use it or no
                        ///Console.Write("\u001b[2A");
                        ///Console.Write("\u001b[2K");
                        ///Console.Write("\u001b[2B");
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format pola!");
                }
            }
            return Tuple.Create(x, y); 
        }

        static Tuple<int, int> GetUserTargetCoordinates(char currentUser)
        {
            bool validUserEntry = false;
            int x = 0;
            int y = 0;
            while (!validUserEntry)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Podaj współrzędne pola, na którym chcesz postawić pionek (np. 'A1', 'H8'): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var userInput = Console.ReadLine();
                    var capitalizedInput = userInput.ToUpper();

                    if (validateUserInput(capitalizedInput))
                    {
                        x = int.Parse(capitalizedInput[1].ToString()) - 1;
                        y = SwitchUserInput(capitalizedInput[0]);
                        validUserEntry = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pole poza zasięgiem planszy!");
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nieprawidłowy format pola!");
                }
            }
            return Tuple.Create(x, y);
        }

        static bool validateUserInput(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput) 
                && (avaliableLetters.Contains(userInput[0]))
                && int.Parse(userInput.Substring(1)) <= BoardSize
                && int.Parse(userInput.Substring(1)) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int SwitchUserInput(char userHorizontalCoordinate)
        {
      
            int modifiedInput;

            switch (userHorizontalCoordinate)
            {
                case 'A':
                    modifiedInput = 0; break;
                case 'B':
                    modifiedInput = 1; break;
                case 'C':
                    modifiedInput = 2; break;
                case 'D':
                    modifiedInput = 3; break;
                case 'E':
                    modifiedInput = 4; break;
                case 'F':
                    modifiedInput = 5; break;
                case 'G':
                    modifiedInput = 6; break;
                case 'H':
                    modifiedInput = 7; break;
                default:
                    modifiedInput = 0; break;
            }
            return modifiedInput;
        }

        static void Main(string[] args)
        {
            bool gamePlay = false;
            char currentUser = 'W';
            while (gamePlay)
            {
                /// main game loop curently set to unactive via gamePlay = false;
            }
            InitializeBoard();
            DrawBoard(currentUser);
            Tuple<int, int> startingCoordinates = GetUserStartingCoordinates(currentUser);
            Tuple<int, int> targetCoordinates = GetUserTargetCoordinates(currentUser);
            Console.WriteLine(startingCoordinates.Item1);
            ///reach the values by startingCoordinates.Item1, Item2, etc.
        }
    }
}