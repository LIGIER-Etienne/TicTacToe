namespace TicTacToe {
    internal class BotPlayer :Player {
        private readonly Board board;

        internal BotPlayer(Board Board, Symbol symbol) : base(symbol) {
            this.board = Board;
        }

        internal override short[] GetNextMove() {
            Console.WriteLine("Bot is playing");
            return board.GetEmptyCells().First();
        }
    }
}
