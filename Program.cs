using System;
using System.Linq.Expressions;

namespace checkers
{
    internal class Program
    {
        static readonly char[] avaliableLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        private const int BoardSize = 10;

        static char[,]? board;
        static int playerOne = 0;
        static int playerTwo = 0;
        static char currentPlayer = 'W';

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
            Console.ForegroundColor = ConsoleColor.White;
            ///Console.WriteLine("     A  B  C  D  E  F  G  H  I  J");
            ///Console.WriteLine("   -------------------------------");
            Console.WriteLine("     A   B   C   D   E   F   G   H   I   J");
            Console.WriteLine("   -----------------------------------------");
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
                        ///checker = char.ConvertFromUtf32(0x1F535);
                        checker = " W ";

                    }
                    else if (board[row, col] == 'B')
                    {
                        ///checker = char.ConvertFromUtf32(0x1F534);
                        checker = " B ";

                    }
                    else
                    {
                        ///checker = "  ";
                        checker = "   ";
                    }
                    Console.Write($"{checker}|");

                }
                Console.WriteLine();
                ///Console.WriteLine("   -------------------------------");
                Console.WriteLine("   -----------------------------------------");

            }
            Console.ForegroundColor = ConsoleColor.Red;
            ///string playerOneSymbol = char.ConvertFromUtf32(0x1F535);
            ///string playerTwoSymbol = char.ConvertFromUtf32(0x1F534);
            char playerOneSymbol = 'W';
            char playerTwoSymbol = 'B';
            ///string currentPlayerIcon;
            char currentPlayerIcon;
            if (currentPlayer == 'W')
            {
                ///currentPlayerIcon = char.ConvertFromUtf32(0x1F535);
                currentPlayerIcon = 'W';
            }
            else
            {
                ///currentPlayerIcon = char.ConvertFromUtf32(0x1F534);
                currentPlayerIcon = 'B';
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{playerOneSymbol} Gracz 1: " + playerOnePoints + " pkt");
            Console.WriteLine($"{playerTwoSymbol} Gracz 2: " + playerTwoPoints + " pkt");
            Console.WriteLine($"\u25A0\u25A0 RUCH GRACZA: {currentPlayerIcon}");
            Console.WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static Tuple<int, int> GetUserStartingCoordinates()
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

                        if (validatePlayerField(board[x, y]))
                        {
                            if (!IsBlocked(new Tuple<int, int>(x, y)))
                            {
                                validUserEntry = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ten pionek nie ma możliwości ruchu!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("W podanej lokalizacji nie ma Twojego pionka!");
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

        static Tuple<int, int> SolvePlayerMove(Tuple<int, int> startingPoint)
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

                        if (validateUserMove(startingPoint, (x, y)))
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
                                UpdateScore();
                            }
                            validUserEntry = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Niedozwolony ruch!");
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

        static char switchCurrentPlayer()
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

        static bool validatePlayerField(char chosenField)
        {
            return currentPlayer == chosenField;
        }

        static bool validateUserMove(Tuple<int, int> startingPoint, (int x, int y) targetPoint)
        {
            int deltaX = Math.Abs(startingPoint.Item1 - targetPoint.x);
            int deltaY = Math.Abs(startingPoint.Item2 - targetPoint.y);

            //Blocking the backward move of the checkers
            //if (currentPlayer == 'W' && startingPoint.Item1 < targetPoint.x)
            //{
            //    return false;
            //}
            //else if (currentPlayer == 'B' && startingPoint.Item1 > targetPoint.x)
            //{
            //    return false;
            //}

            if (deltaX != deltaY
                || deltaX > 2
                || deltaY > 2
                || board[targetPoint.x, targetPoint.y] != '-')
            {
                return false;
            }
            else if (deltaX == 2)
            {
                int passedByFieldX = (startingPoint.Item1 + targetPoint.x) / 2;
                int passedByFieldY = (startingPoint.Item2 + targetPoint.y) / 2;

                if (currentPlayer == 'W'
                    && board[passedByFieldX, passedByFieldY] == 'B')
                {
                    return true;
                }
                else if (currentPlayer == 'B'
                    && board[passedByFieldX, passedByFieldY] == 'W')
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

        static void UpdateScore()
        {
            if (currentPlayer == 'W')
            {
                playerOne++;
            }
            else
            {
                playerTwo++;
            }
        }

        static bool IsBlocked(Tuple<int, int> pickedChecker)
        {
            int row = pickedChecker.Item1;
            int col = pickedChecker.Item2;

            if (checkField(new Tuple<int, int>(row - 1, col - 1), pickedChecker))
            {
                return false;
            }
            else if (checkField(new Tuple<int, int>(row + 1, col + 1), pickedChecker))
            {
                return false;
            }
            else if (checkField(new Tuple<int, int>(row - 1, col + 1), pickedChecker))
            {
                return false;
            }
            else if (checkField(new Tuple<int, int>(row + 1, col - 1), pickedChecker))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool checkField(Tuple<int, int> checkedField, Tuple<int, int> currentPosition)
        {
            try
            {
                if (board[checkedField.Item1, checkedField.Item2] == '-')
                {
                    return true;
                }
                else if (board[checkedField.Item1, checkedField.Item2] == currentPlayer)
                {
                    return false;
                }
                else
                {
                    int newX = checkedField.Item1 - (currentPosition.Item1 - checkedField.Item1);
                    int newY = checkedField.Item2 - (currentPosition.Item2 - checkedField.Item2);

                    if (board[newX, newY] == '-')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
        static bool CheckGameEnd()
        {
            if (playerOne >= 20 || playerTwo >= 20)
            {
                DrawBoard(currentPlayer, playerOne, playerTwo);
                char winner = playerOne >= 20 ? 'W' : 'B';
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Gracz {winner} wygrał grę!");
                Console.ReadLine();
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            bool gamePlay = true;
            InitializeBoard();
            while (gamePlay)
            {
                DrawBoard(currentPlayer, playerOne, playerTwo);
                Tuple<int, int> startingCoordinates = GetUserStartingCoordinates();
                SolvePlayerMove(startingCoordinates);
                currentPlayer = switchCurrentPlayer();
                if (CheckGameEnd())
                {
                    gamePlay = false;
                }
            }
        }
    }
}