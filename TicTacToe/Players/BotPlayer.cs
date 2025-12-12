using TicTacToe.Enums;

namespace TicTacToe.Players;

public class BotPlayer :Player {
    private readonly Board board;

    public BotPlayer(Board Board, Symbol symbol) : base(symbol) {
        this.board = Board;
    }

    public override short[] GetNextMove() {
        Console.WriteLine("Bot is playing");
        return board.GetEmptyCells().First();
    }
}