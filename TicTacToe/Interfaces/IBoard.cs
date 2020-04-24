namespace TicTacToe.Interfaces
{
    public interface IBoard
    {
        void ResetBoard();
        void DrawBoard();
        void MakeMove(IPlayer player, int input);
        void CheckWinStatus();
        void ReportDraw();
        int ValidateInput(IPlayer player);
        int TotalTurns { get; }
    }
}
