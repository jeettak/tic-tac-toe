namespace TicTacToe.Interfaces
{
    public interface IPlayer
    {
        int ReadChoice();

        int PlayerId { get; }

        char PlayerSignature { get; }
    }
}
