namespace checkers
{
    internal class Program
    {
        static char[,]? board;
        static void InitializeBoard()
        {
            board = new char[8, 8]
            {
                { '-', 'b', '-', 'b', '-', 'b', '-', 'b' },
                { 'b', '-', 'b', '-', 'b', '-', 'b', '-' },
                { '-', 'b', '-', 'b', '-', 'b', '-', 'b' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-' },
                { 'w', '-', 'w', '-', 'w', '-', 'w', '-' },
                { '-', 'w', '-', 'w', '-', 'w', '-', 'w' },
                { 'w', '-', 'w', '-', 'w', '-', 'w', '-' },
            };
            Console.WriteLine(board[0, 1]);
        }
        static void Main(string[] args)
        {
            bool gamePlay = false;
            InitializeBoard();
            Console.WriteLine("Checkers Game");
            Console.WriteLine("Juta Kozińska, Grzegorz Łabojko, Radosław Rocławski");
            while (gamePlay)
            {
                /// main game loop curently set to unactive via gamePlay = false;
            }
        }
    }
}