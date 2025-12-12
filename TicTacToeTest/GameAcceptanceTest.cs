using TicTacToe;
using TicTacToe.Enums;
using TicTacToe.InputProviders;
using TicTacToe.Players;

namespace TicTacToeTest;

public class GameAcceptanceTest {
    [Theory]

    // CircleWins by row
    [InlineData(
        new[] { "0", "0", "0", "1", "0", "2" },
        new[] { "1", "0", "1", "1" },
        GameState.CircleWins)]

    // CrossWins by col
    [InlineData(
    new[] { "0", "0", "0", "2", "2", "0" },
    new[] { "0", "1", "1", "1", "2", "1" },
    GameState.CrossWins)]

    // Draw by full board
    [InlineData(
    new[] { "0", "0", "0", "1", "1", "2", "2", "0", "2", "2" },
    new[] { "0", "2", "1", "0", "1", "1", "2", "1" },
    GameState.Draw)]

    public void Play_Should_Return_Expected_State(IEnumerable<string> oInputs, IEnumerable<string> xInputs, GameState result) {
        IInputProvider circleInputProvider = new TestInputProvider(oInputs);

        IInputProvider crossInputProvider = new TestInputProvider(xInputs);

        Dictionary<Symbol, Player> Players = new() {
            {Symbol.Circle , new HumanPlayer(Symbol.Circle, circleInputProvider)},
            {Symbol.Cross , new HumanPlayer(Symbol.Cross, crossInputProvider)},
        };

        Game game = new(Players);

        Assert.Equal(result, game.Play());
    }
}
