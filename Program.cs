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

        static void GetUserStartingCoordinates(char currentUser)
        {
            Console.Write("Podaj współrzędne pionka, którym chcesz się ruszyć (np. 'A1', 'H8'): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                var userInput = Console.ReadLine();
                string capitalizedInput = userInput.ToUpper();

                if (validateUserInput(capitalizedInput))
                {
                    Console.WriteLine("Prawidłowe pole literowe");
                    int x = int.Parse(capitalizedInput[1].ToString()) - 1;
                    int y = SwitchUserInput(capitalizedInput[0]);
                    Console.WriteLine("Wybrałeś pole zajęte przez: " + board[x, y]);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe pole literowe");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format pola!");
            }
}

        static void GetUserTargetCoordinates(char currentUser)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Podaj współrzędne pola, na którym chcesz postawić pionek (np. 'A1', 'H8'): ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                var userInput = Console.ReadLine();
                string capitalizedInput = userInput.ToUpper();

                if (validateUserInput(capitalizedInput))
                {
                    Console.WriteLine("Prawidłowe pole literowe");
                    int x = int.Parse(capitalizedInput[1].ToString()) - 1;
                    int y = SwitchUserInput(capitalizedInput[0]);
                    Console.WriteLine("Wybrałeś pole zajęte przez: " + board[x, y]);
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe pole literowe");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidłowy format pola!");
            }
        }

        static bool validateUserInput(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput) 
                && (avaliableLetters.Contains(userInput[0]))
                && int.Parse(userInput.Substring(1)) <= BoardSize)
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
            GetUserStartingCoordinates(currentUser);
            GetUserTargetCoordinates(currentUser);
        }
    }
}