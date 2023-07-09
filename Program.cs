﻿using System;

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
            Console.WriteLine("Checkers Game by:");
            Console.WriteLine("Juta Kozińska, Grzegorz Łabojko, Radosław Rocławski");
            Console.WriteLine("---------------------------------------------------");

        }

        static void GetUserStartingPoint()
        {
            Console.Write("Podaj współrzędne pionka którym chcesz się ruszyć(np 'A1', 'H8'): ");
            var userInput = Console.ReadLine();
            int x = SwitchUserInput(userInput[0]);
            int y = int.Parse(userInput[1].ToString()) - 1;
            Console.WriteLine(board[x, y]);

        }

        static void GetUserEndingPoint()
        {
            Console.Write("Podaj współrzędne pola na którym chcesz postawić pionek (np 'A1', 'H8'): ");
            var userInput = Console.ReadLine();
            int x = SwitchUserInput(userInput[0]);
            int y = int.Parse(userInput[1].ToString()) - 1;
            Console.WriteLine(board[x, y]);
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
            InitializeBoard();
            DrawBoard();
            GetUserStartingPoint();
            GetUserEndingPoint();
        }
    }
}