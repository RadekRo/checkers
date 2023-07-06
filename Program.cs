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

        static void GetMoveCoordinates()
        {
            Console.Write("Podaj współrzędne pionka którym chcesz się ruszyć(np 'A1', 'H8'): ");
            string userPieceChoice = Console.ReadLine();
            
            Dictionary<string, int[]> coordinatesMap = new Dictionary<string, int[]>();
            coordinatesMap.Add("A1", new int[] { 1, 0 });
            coordinatesMap.Add("A2", new int[] { 1, 1 });
            coordinatesMap.Add("A3", new int[] { 1, 2 });
            coordinatesMap.Add("A4", new int[] { 1, 3 });
            coordinatesMap.Add("A5", new int[] { 1, 4 });
            coordinatesMap.Add("A6", new int[] { 1, 5 });
            coordinatesMap.Add("A7", new int[] { 1, 6 });
            coordinatesMap.Add("A8", new int[] { 1, 7 });
            coordinatesMap.Add("B1", new int[] { 2, 0 });
            coordinatesMap.Add("B2", new int[] { 2, 1 });
            coordinatesMap.Add("B3", new int[] { 2, 2 });
            coordinatesMap.Add("B4", new int[] { 2, 3 });
            coordinatesMap.Add("B5", new int[] { 2, 4 });
            coordinatesMap.Add("B6", new int[] { 2, 5 });
            coordinatesMap.Add("B7", new int[] { 2, 6 });
            coordinatesMap.Add("B8", new int[] { 2, 7 });
            coordinatesMap.Add("C1", new int[] { 3, 0 });
            coordinatesMap.Add("C2", new int[] { 3, 1 });
            coordinatesMap.Add("C3", new int[] { 3, 2 });
            coordinatesMap.Add("C4", new int[] { 3, 3 });
            coordinatesMap.Add("C5", new int[] { 3, 4 });
            coordinatesMap.Add("C6", new int[] { 3, 5 });
            coordinatesMap.Add("C7", new int[] { 3, 6 });
            coordinatesMap.Add("C8", new int[] { 3, 7 });
            coordinatesMap.Add("D1", new int[] { 4, 0 });
            coordinatesMap.Add("D2", new int[] { 4, 1 });
            coordinatesMap.Add("D3", new int[] { 4, 2 });
            coordinatesMap.Add("D4", new int[] { 4, 3 });
            coordinatesMap.Add("D5", new int[] { 4, 4 });
            coordinatesMap.Add("D6", new int[] { 4, 5 });
            coordinatesMap.Add("D7", new int[] { 4, 6 });
            coordinatesMap.Add("D8", new int[] { 4, 7 });
            coordinatesMap.Add("E1", new int[] { 5, 0 });
            coordinatesMap.Add("E2", new int[] { 5, 1 });
            coordinatesMap.Add("E3", new int[] { 5, 2 });
            coordinatesMap.Add("E4", new int[] { 5, 3 });
            coordinatesMap.Add("E5", new int[] { 5, 4 });
            coordinatesMap.Add("E6", new int[] { 5, 5 });
            coordinatesMap.Add("E7", new int[] { 5, 6 });
            coordinatesMap.Add("E8", new int[] { 5, 7 });
            coordinatesMap.Add("F1", new int[] { 5, 0 });
            coordinatesMap.Add("F2", new int[] { 6, 1 });
            coordinatesMap.Add("F3", new int[] { 6, 2 });
            coordinatesMap.Add("F4", new int[] { 6, 3 });
            coordinatesMap.Add("F5", new int[] { 6, 4 });
            coordinatesMap.Add("F6", new int[] { 6, 5 });
            coordinatesMap.Add("F7", new int[] { 6, 6 });
            coordinatesMap.Add("F8", new int[] { 6, 7 });
            coordinatesMap.Add("G1", new int[] { 7, 0 });
            coordinatesMap.Add("G2", new int[] { 7, 1 });
            coordinatesMap.Add("G3", new int[] { 7, 2 });
            coordinatesMap.Add("G4", new int[] { 7, 3 });
            coordinatesMap.Add("G5", new int[] { 7, 4 });
            coordinatesMap.Add("G6", new int[] { 7, 5 });
            coordinatesMap.Add("G7", new int[] { 7, 6 });
            coordinatesMap.Add("G8", new int[] { 7, 7 });
            coordinatesMap.Add("H1", new int[] { 8, 0 });
            coordinatesMap.Add("H2", new int[] { 8, 1 });
            coordinatesMap.Add("H3", new int[] { 8, 2 });
            coordinatesMap.Add("H4", new int[] { 8, 3 });
            coordinatesMap.Add("H5", new int[] { 8, 4 });
            coordinatesMap.Add("H6", new int[] { 8, 5 });
            coordinatesMap.Add("H7", new int[] { 8, 6 });
            coordinatesMap.Add("H8", new int[] { 8, 7 });

            Console.WriteLine(board[coordinatesMap[userPieceChoice][0], coordinatesMap[userPieceChoice][1]]);
            board[coordinatesMap[userPieceChoice][0], coordinatesMap[userPieceChoice][1]] = 'X';
            Console.WriteLine(board[coordinatesMap[userPieceChoice][0], coordinatesMap[userPieceChoice][1]]);
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
            GetMoveCoordinates();
            DrawBoard();
        }
    }
}