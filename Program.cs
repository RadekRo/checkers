using System;

namespace checkers
{
    internal class Program
    {
        private readonly char[] avaliableLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
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
        static void DrawBoard()
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
            Console.WriteLine("Checkers Game by:");
            Console.WriteLine("Juta Kozińska, Grzegorz Łabojko, Radosław Rocławski");
            Console.WriteLine("---------------------------------------------------");

        }

        static void GetUserStartingPoint(char currentUser)
        {
            Console.Write("Podaj współrzędne pionka którym chcesz się ruszyć(np 'A1', 'H8'): ");
            var userInput = Console.ReadLine();

            int x = SwitchUserInput(Char.ToUpper(userInput[0]));
            int y = int.Parse(userInput[1].ToString()) - 1;
            Console.WriteLine("Wybrałeś pole zajęte przez: " + board[x, y]);

        }

        static void GetUserEndingPoint(char currentUser)
        {
            Console.Write("Podaj współrzędne pola na którym chcesz postawić pionek (np 'A1', 'H8'): ");
            var userInput = Console.ReadLine();
            int x = SwitchUserInput(userInput[0]);
            int y = int.Parse(userInput[1].ToString()) - 1;
            Console.WriteLine("Stawiasz na polu zajętym przez: " + board[x, y]);
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
   
        public enum PieceColor
        {
            None,
            White,
            Black
        }

        static void Main(string[] args)
        {
            bool gamePlay = false;
            while (gamePlay)
            {
                /// main game loop curently set to unactive via gamePlay = false;
            }
            InitializeBoard();
            DrawBoard();
            GetUserStartingPoint('W');
            GetUserEndingPoint('W');
        }
    }
}