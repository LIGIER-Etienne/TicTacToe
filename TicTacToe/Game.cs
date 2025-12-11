namespace TicTacToe {
    internal class Game {
        private Board Board;
        private Dictionary<Symbol, Player> Players;
        private Symbol turn;

        public Game() {
            Board = new Board();

            Players = new Dictionary<Symbol, Player>() {
                {Symbol.Circle , new HumanPlayer(Symbol.Circle)},
                {Symbol.Cross , new BotPlayer(Board, Symbol.Cross)},
            };

            turn = Symbol.Circle;
        }

        private void SwitchTurn() {
            turn = turn == Symbol.Circle ? Symbol.Cross : Symbol.Circle;
        }

        public void Play() {
            bool playAgain = true;

            while(playAgain) { // New game
                Board.DisplayBoard();

                GameState gameState = Board.GetGameState();
                while(gameState == GameState.InProgress) { // Game not over (next move)
                    bool movePlayed = false;
                    while(!movePlayed) { // Move not valid (ask again)
                        short[] nextMove = Players[turn].GetNextMove();
                        movePlayed = Board.PlayMove(nextMove[0], nextMove[1], Players[turn].Symbol);
                    }

                    SwitchTurn();
                    Board.DisplayBoard();

                    gameState = Board.GetGameState();
                }

                Console.Write("Game over, ");
                switch(gameState) {
                    case GameState.CircleWins:
                        Console.WriteLine("circle wins !");
                        break;
                    case GameState.CrossWins:
                        Console.WriteLine("cross wins !");
                        break;
                    case GameState.Draw:
                        Console.WriteLine("it's a draw !");
                        break;
                }

                Board.InitBoard();
            }
        }
    }
}
