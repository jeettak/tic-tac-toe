using System;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    public class Game : IGame
    {
        private readonly PlayerForX _player1;
        private readonly PlayerForO _player2;
        private readonly IBoard _gameBoard;
        private readonly IPlayerRepository _playerRepository;

        public Game(IBoard gameBoard, IPlayerRepository playerRepository)
        {
            _gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));

            _player1 = _playerRepository.GetPlayer("PlayerX") as PlayerForX ?? throw new ArgumentNullException(nameof(PlayerForX));
            _player2 = _playerRepository.GetPlayer("PlayerO") as PlayerForO ?? throw new ArgumentNullException(nameof(PlayerForO));
        }

        public void Play()
        {
            IPlayer player = _player2;

            Console.WriteLine("Welcome to Tic Tac Toe, X goes first.");
            Console.WriteLine("Pick a number to select a space.  To exit, type q.");
            Console.WriteLine("Players are represented by either an X or O.\nPlayer 1 = X.  Player 2 = O");
            Console.WriteLine("The first player to score three of their values in a row is the winner");
            Console.ReadKey();

            do
            {
                _gameBoard.DrawBoard();
                player = player == _player2 ? _player1 : (IPlayer)_player2;
                int input = _gameBoard.ValidateInput(player);
                try
                {
                    _gameBoard.MakeMove(player, input);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Please enter a number between 1 and 9");
                }

                _gameBoard.CheckWinStatus();

                if (_gameBoard.TotalTurns >= 9)
                {
                    _gameBoard.ReportDraw();
                }
            } while (true);
        }
    }
}
