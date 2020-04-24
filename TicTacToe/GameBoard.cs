using System;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    public class GameBoard : IBoard
    {
        private char[] _gameBoard = new char[]
        {
            '1', '2', '3','4', '5', '6','7', '8', '9'
        };
        private readonly char[] _validSignatures = { 'X', 'O' };

        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", _gameBoard[0], _gameBoard[1], _gameBoard[2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", _gameBoard[3], _gameBoard[4], _gameBoard[5]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", _gameBoard[6], _gameBoard[7], _gameBoard[8]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
        }

        public void MakeMove(IPlayer player, int input)
        {
            _ = player ?? throw new ArgumentNullException(nameof(player));

            if (input < 1 || input > 9)
            {
                throw new ArgumentException($"Invalid input value: {input}", nameof(input));
            }

            _gameBoard[input - 1] = player.PlayerSignature;
            TotalTurns++;
        }

        public void ResetBoard()
        {
            _gameBoard = new char[]
            {
                '1', '2', '3','4', '5', '6','7', '8', '9'
            };
            DrawBoard();
            TotalTurns = 0;
        }

        public void CheckWinStatus()
        {
            var gameWon = HorizontalWin() || VerticalWin() || DiagonalWin();
            if (gameWon)
            {
                Console.WriteLine("Please press any key to reset the game, or to exit type q.");
                var quit = Console.ReadLine();
                if (quit.Equals("q")) Environment.Exit(0);
                ResetBoard();
            }
        }

        public void ReportDraw()
        {
            Console.WriteLine("The result is a draw.");
            Console.WriteLine("Please press any key to reset the game and play again.");
            Console.ReadKey();
            ResetBoard();
        }

        public int ValidateInput(IPlayer player)
        {
            _ = player ?? throw new ArgumentNullException(nameof(player));

            int input;
            bool validChoice;

            do
            {
                Console.WriteLine($"Ready Player {player.PlayerId}: It's your move. Choose a number and press enter");
                input = player.ReadChoice();

                validChoice = input > 0 && input < 10;

                if (validChoice)
                {
                    // Check if choosen position has already been taken
                    validChoice = (_gameBoard[input - 1] != 'O' && _gameBoard[input - 1] != 'X');
                }

                if (!validChoice)
                {
                    Console.WriteLine("Position has already been taken or invalid number entered.\nPlease try again...");
                }

            } while (!validChoice);

            return input;
        }

        public int TotalTurns { get; private set; } = 0;

        private bool DiagonalWin()
        {
            foreach (char signature in _validSignatures)
            {
                if (((_gameBoard[0] == signature) && (_gameBoard[4] == signature) && (_gameBoard[8] == signature)) ||
                    ((_gameBoard[2] == signature) && (_gameBoard[4] == signature) && (_gameBoard[6] == signature)))
                {
                    Console.Clear();
                    Console.WriteLine(signature.Equals('X')
                        ? $"Player 1 won - Diagonal Win in {TotalTurns} turns."
                        : $"Player 2 won - Diagonal Win in {TotalTurns} turns.");

                    return true;
                }
            }

            return false;
        }

        private bool VerticalWin()
        {
            foreach (char signature in _validSignatures)
            {
                if (((_gameBoard[0] == signature) && (_gameBoard[3] == signature) && (_gameBoard[6] == signature)) ||
                    ((_gameBoard[1] == signature) && (_gameBoard[4] == signature) && (_gameBoard[7] == signature)) ||
                    ((_gameBoard[2] == signature) && (_gameBoard[5] == signature) && (_gameBoard[8] == signature)))
                {
                    Console.Clear();
                    Console.WriteLine(signature.Equals('X')
                        ? $"Player 1 won - Vertical Win in {TotalTurns} turns."
                        : $"Player 2 won - Vertical Win in {TotalTurns} turns.");

                    return true;
                }
            }

            return false;
        }

        private bool HorizontalWin()
        {
            foreach (var signature in _validSignatures)
            {
                if (((_gameBoard[0] == signature) && (_gameBoard[1] == signature) && (_gameBoard[2] == signature)) ||
                    ((_gameBoard[3] == signature) && (_gameBoard[4] == signature) && (_gameBoard[5] == signature)) ||
                    ((_gameBoard[6] == signature) && (_gameBoard[7] == signature) && (_gameBoard[8] == signature)))
                {
                    Console.Clear();
                    Console.WriteLine(signature.Equals('X')
                        ? $"Player 1 won - Horizontal Win in {TotalTurns} turns."
                        : $"Player 2 won - Horizontal Win in {TotalTurns} turns.");

                    return true;
                }
            }

            return false;
        }
    }
}
