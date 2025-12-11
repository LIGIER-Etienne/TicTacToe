namespace TicTacToe {
    internal abstract class Player {
        internal Symbol Symbol { get; }

        protected Player(Symbol symbol) {
            Symbol = symbol;
        }

        internal abstract short[] GetNextMove();
    }
}
