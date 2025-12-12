using TicTacToe.Enums;

namespace TicTacToe.Players {
    public abstract class Player {
        public Symbol Symbol { get; }

        protected Player(Symbol symbol) {
            Symbol = symbol;
        }

        public abstract short[] GetNextMove();
    }
}
