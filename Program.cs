using System;

namespace checkers
{
    internal class Program
    {
        private const int BoardSize = 8;

        static char[,] board;

        static void InitializeBoard()
        {
            board = new char[BoardSize + 1, BoardSize]
            {
                { '-', '-', '-', '-', '-', '-', '-', '-' },
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
            Console.WriteLine(board[1, 1]);
            Console.WriteLine("   A B C D E F G H");
            Console.WriteLine("  -----------------");
            for (int row = 1; row < 9; row++)
            {
                Console.Write(row + " |");
                for (int col = 0; col < 8; col++)
                {
                    Console.Write(board[row, col] + "|");
                }
                Console.WriteLine();
                Console.WriteLine("  -----------------");
            }
        }

        static void GetUserCoordinates()
        {
            Console.Write("Podaj współrzędne pionka którym chcesz się ruszyć(np 'A1', 'H8'): ");
            var userPieceChoice = Console.ReadLine();
            int x = SwitchUserInput(userPieceChoice[0]);
            int y = int.Parse(userPieceChoice[1].ToString()) - 1;
            Console.WriteLine(board[x, y]);

            Console.Write("Podaj współrzędne pola na którym chcesz postawić pionek (np 'A1', 'H8'): ");
            var userDestinationChoice = Console.ReadLine();
            ///Console.WriteLine(board[SwitchUserInput(userDestinationChoice[0]), userDestinationChoice[1]]);

        }

        static int SwitchUserInput(char userHorizontalCoordinate)
        {
      
            int modifiedInput;

            switch (userHorizontalCoordinate)
            {
                case 'A':
                    modifiedInput = 1; break;
                case 'B':
                    modifiedInput = 2; break;
                case 'C':
                    modifiedInput = 3; break;
                case 'D':
                    modifiedInput = 4; break;
                case 'E':
                    modifiedInput = 5; break;
                case 'F':
                    modifiedInput = 6; break;
                case 'G':
                    modifiedInput = 7; break;
                case 'H':
                    modifiedInput = 8; break;
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
            Console.WriteLine("Checkers Game");
            Console.WriteLine("Juta Kozińska, Grzegorz Łabojko, Radosław Rocławski");
            InitializeBoard();
            DrawBoard();
            GetUserCoordinates();
            DrawBoard();
        }
    }
}