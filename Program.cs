namespace checkers
{
    internal class Program
    {
        private const int BoardSize = 8;

        static char[,] board;
        static void InitializeBoard()
        {
            board = new char[BoardSize, BoardSize]
            {
                { '.-', 'B', '-', 'B', '-', 'B', '-', 'B' },
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
            for (int row = 0; row < 8; row++)
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
        public enum PieceColor
        {
            None,
            White,
            Black
        }
        static void Main(string[] args)
        {
            bool gamePlay = false;
            InitializeBoard();
            DrawBoard();
            Console.WriteLine("Checkers Game");
            Console.WriteLine("Juta Kozińska, Grzegorz Łabojko, Radosław Rocławski");
            while (gamePlay)
            {
                /// main game loop curently set to unactive via gamePlay = false;
            }
        }
    }
}