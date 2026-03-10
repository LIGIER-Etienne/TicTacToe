using TicTacToe.Data;
using TicTacToe.Enums;
using TicTacToe.InputProviders;
using TicTacToe.Models;
using TicTacToe.Players;

namespace TicTacToe;

public class Game {
    private readonly GameDbContext DbContext;
    private Board Board;
    private Dictionary<Symbol, Player> Players;
    private Symbol turn;

    public Game(GameDbContext dbContext) {
        DbContext = dbContext;

        Board = new Board();
        IInputProvider inputProvider = new ConsoleInputProvider();

        Players = new Dictionary<Symbol, Player>() {
            {Symbol.Circle , new HumanPlayer(Symbol.Circle, inputProvider)},
            {Symbol.Cross , new BotPlayer(Board, Symbol.Cross)},
        };

        turn = Symbol.Circle;
    }
    public Game(GameDbContext dbContext, Dictionary<Symbol, Player> Players) {
        DbContext = dbContext;

        Board = new Board();
        this.Players = Players;
        turn = Symbol.Circle;
    }

    private void SwitchTurn() {
        turn = turn == Symbol.Circle ? Symbol.Cross : Symbol.Circle;
    }

    public async Task<GameState> Play() {
        Board.DisplayBoard();

        GameState gameState = Board.GetGameState();
        while(gameState == GameState.InProgress) {
            short[] nextMove = await Players[turn].GetNextMoveAsync();
            if(!Board.PlayMove(nextMove[0], nextMove[1], Players[turn].Symbol)) {
                continue;
            }

            SwitchTurn();
            Board.DisplayBoard();
            await SaveGame();

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

        return Board.GetGameState();
    }

    private async Task SaveGame() {
        DbGame game = new DbGame {
            PlayedAt = DateTime.Now,
            Board = this.Board.Cells,
            GameState = this.Board.GetGameState(),
            Turn = this.turn
        };

        DbContext.Games.Add(game);
        await DbContext.SaveChangesAsync();
    }
}
