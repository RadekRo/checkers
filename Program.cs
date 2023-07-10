﻿using System;

namespace checkers
{
    internal class Program
    {
        static readonly char[] avaliableLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        private const int BoardSize = 10;

        static char[,]? board;

        static void InitializeBoard()
        {
            board = new char[BoardSize, BoardSize]
            {
                { '-', 'B', '-', 'B', '-', 'B', '-', 'B', '-', 'B' },
                { 'B', '-', 'B', '-', 'B', '-', 'B', '-', 'B', '-' },
                { '-', 'B', '-', 'B', '-', 'B', '-', 'B', '-', 'B' },
                { 'B', '-', 'B', '-', 'B', '-', 'B', '-', 'B', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-' },
                { '-', 'W', '-', 'W', '-', 'W', '-', 'W', '-', 'W' },
                { 'W', '-', 'W', '-', 'W', '-', 'W', '-', 'W', '-' },
                { '-', 'W', '-', 'W', '-', 'W', '-', 'W', '-', 'W' },
                { 'W', '-', 'W', '-', 'W', '-', 'W', '-', 'W', '-' }
            };
        }
        static void DrawBoard(char currentPlayer, int playerOnePoints, int playerTwoPoints)
        {
            Console.Clear();
            Console.WriteLine("     A  B  C  D  E  F  G  H  I  J");
            Console.WriteLine("   -------------------------------");
            for (int row = 0; row < BoardSize; row++)
            {
                int boardsRow = row + 1;
                string checker;
                if (boardsRow == 10)
                {
                    Console.Write(boardsRow + " |");
                }
                else
                {
                    Console.Write(boardsRow + "  |");
                }

                for (int col = 0; col < BoardSize; col++)
                {

                    if (board[row, col] == 'W')
                    {
                        checker = char.ConvertFromUtf32(0x1F535);
                        ///checker = "W";

                    }
                    else if (board[row, col] == 'B')
                    {
                        checker = char.ConvertFromUtf32(0x1F534);
                        ///checker = "B";

                    }
                    else
                    {
                        checker = "  ";
                    }
                    Console.Write($"{checker}|");
                
                }
                Console.WriteLine();
                Console.WriteLine("   -------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            ///string playerOneSymbol = "⚫";
            ///string playerTwoSymbol = "🔵";
            string playerOneSymbol = char.ConvertFromUtf32(0x1F535);
            string playerTwoSymbol = char.ConvertFromUtf32(0x1F534);
            string currentPlayerIcon;
            if (currentPlayer == 'W') 
            {
                currentPlayerIcon = char.ConvertFromUtf32(0x1F535);
                ///currentPlayerIcon = "W";
            }
            else
            {
                currentPlayerIcon = char.ConvertFromUtf32(0x1F534);
                ///currentPlayerIcon = "B";
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{playerOneSymbol} Gracz 1: " + playerOnePoints + " pkt");
            Console.WriteLine($"{playerTwoSymbol} Gracz 2: " + playerTwoPoints + " pkt");
            Console.WriteLine($"\u25A0\u25A0 RUCH GRACZA: {currentPlayerIcon}");
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static Tuple<int, int> GetUserStartingCoordinates(char currentPlayer)
        {
            bool validUserEntry = false;
            int x = 0;
            int y = 0;
            while (!validUserEntry)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Podaj współrzędne pionka, którym chcesz się ruszyć (np. 'A1'): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var userInput = Console.ReadLine();
                    var capitalizedInput = userInput.ToUpper();

                    if (validateUserInput(capitalizedInput))
                    {
                        x = int.Parse(capitalizedInput.Substring(1).ToString()) - 1;
                        y = SwitchUserInput(capitalizedInput[0]);

                        if (validatePlayerField(currentPlayer, board[x, y]))
                        {
                            validUserEntry = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("W podanej lokalizacji nie ma Twojego pionka!");
                            Console.WriteLine(board[x, y]);
                            Console.WriteLine(x);
                            Console.WriteLine(y);
                        }
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

        static Tuple<int, int> GetUserTargetCoordinates(char currentPlayer, Tuple<int, int> startingPoint)
        {
            bool validUserEntry = false;
            int x = 0;
            int y = 0;
            while (!validUserEntry)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Podaj współrzędne pola, na którym chcesz postawić pionek (np. 'B2'): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    var userInput = Console.ReadLine();
                    var capitalizedInput = userInput.ToUpper();

                    if (validateUserInput(capitalizedInput))
                    {
                        x = int.Parse(capitalizedInput.Substring(1).ToString()) - 1;
                        y = SwitchUserInput(capitalizedInput[0]);
                        
                        if (validateUserMove(startingPoint, (x, y), currentPlayer))
                        {
                            if (Math.Abs(startingPoint.Item1 - x) == 1)
                            {
                                board[startingPoint.Item1, startingPoint.Item2] = '-';
                                board[x, y] = currentPlayer;
                            }
                            else
                            {
                                int enemyX = (startingPoint.Item1 + x) / 2;
                                int enemyY = (startingPoint.Item2 + y) / 2;

                                board[startingPoint.Item1, startingPoint.Item2] = '-';
                                board[enemyX, enemyY] = '-';
                                board[x, y] = currentPlayer;
                            }
                            validUserEntry = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Niedozwolony ruch!");
                            Console.WriteLine(board[x, y]);
                        }
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

        static char switchCurrentPlayer(char currentPlayer) 
        {
            if (currentPlayer == 'W')
            {
                return 'B';
            } 
            else
            {
                return 'W';
            }
        }
        static bool validateUserInput(string userInput)
        {
            return (!string.IsNullOrEmpty(userInput)
                    && (avaliableLetters.Contains(userInput[0]))
                    && int.Parse(userInput.Substring(1)) <= BoardSize
                    && int.Parse(userInput.Substring(1)) > 0);
        }

        static bool validatePlayerField(char currentPlayer, char chosenField)
        {
            return currentPlayer == chosenField;
        }

        static bool validateUserMove(Tuple<int, int> startingPoint, (int x, int y) targetPoint, char currentPlayer)
        {
            int deltaX = Math.Abs(startingPoint.Item1 - targetPoint.x);
            int deltaY = Math.Abs(startingPoint.Item2 - targetPoint.y);
            ///Console.WriteLine(board[targetPoint.x, targetPoint.y]);

            if (deltaX != deltaY 
                || deltaX > 2 
                || deltaY > 2 
                || board[targetPoint.x, targetPoint.y] != '-')
            {
                return false;
            }
            else if (deltaX == 2)
            {
                int passedX = (startingPoint.Item1 + targetPoint.x) / 2;
                int passedY = (startingPoint.Item2 + targetPoint.y) / 2;
                if (currentPlayer == 'W' 
                    && board[passedX, passedY] == 'B')
                {
                    return true;
                }
                else if (currentPlayer == 'B'
                    && board[passedX, passedY] == 'W')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
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
                case 'I':
                    modifiedInput = 8; break;
                case 'J':
                    modifiedInput = 9; break;
                default:
                    modifiedInput = 0; break;
            }
            return modifiedInput;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            bool gamePlay = true;
            char currentPlayer = 'W';
            int playerOne = 0;
            int playerTwo = 0;
            InitializeBoard();
            while (gamePlay)
            {
                DrawBoard(currentPlayer, playerOne, playerTwo);
                Tuple<int, int> startingCoordinates = GetUserStartingCoordinates(currentPlayer);
                Tuple<int, int> targetCoordinates = GetUserTargetCoordinates(currentPlayer, startingCoordinates);
                ///reach the values by startingCoordinates.Item1, Item2, etc.
                currentPlayer = switchCurrentPlayer(currentPlayer);

            }
        }
    }
}