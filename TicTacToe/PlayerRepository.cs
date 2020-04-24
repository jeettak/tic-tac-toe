using System;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Func<string, IPlayer> _player;

        public PlayerRepository(Func<string, IPlayer> player)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public IPlayer GetPlayer(string player)
        {
            return _player(player);
        }
    }
}
