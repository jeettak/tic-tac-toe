using TicTacToe.Interfaces;

namespace TicTacToe
{
    public class PlayerForO : Player, IPlayer
    {
        private const int Player = 2;
        private const char Signature = 'O';

        public int PlayerId => Player;

        public char PlayerSignature => Signature;
    }
}
