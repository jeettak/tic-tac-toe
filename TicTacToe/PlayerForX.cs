using TicTacToe.Interfaces;

namespace TicTacToe
{
    public class PlayerForX : Player, IPlayer
    {
        private const int Player = 1;
        private const char Signature = 'X';

        public int PlayerId => Player;

        public char PlayerSignature => Signature;
    }
}
