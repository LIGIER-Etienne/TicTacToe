using System.Threading.Tasks;
using TicTacToe.Enums;

namespace TicTacToe.Players;

public class BotPlayer :Player {
    private readonly Board board;

    public BotPlayer(Board Board, Symbol symbol) : base(symbol) {
        this.board = Board;
    }

    public override async Task<short[]> GetNextMoveAsync() {
        Console.WriteLine("Bot is playing");
        await Think();
        return board.GetEmptyCells().First();
    }

    private async Task Think() {
        await Task.Delay(1000);
    }
}