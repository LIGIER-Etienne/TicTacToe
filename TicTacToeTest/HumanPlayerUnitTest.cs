using TicTacToe.Enums;
using TicTacToe.InputProviders;
using TicTacToe.Players;

namespace TicTacToeTest {
    public class HumanPlayerUnitTest {

        [Fact]
        public void GetNextMove_Should_Return_Valid_Coordinates() {
            // Arrange
            var inputProvider = new TestInputProvider(new[] { "1", "2" });
            var player = new HumanPlayer(Symbol.Circle, inputProvider);

            // Act
            var move = player.GetNextMove();

            // Assert
            Assert.Equal(1, move[0]);
            Assert.Equal(2, move[1]);
        }

        [Fact]
        public void GetNextMove_Should_Ignore_Invalid_Row_Then_Accept_Valid_Row() {
            // Inputs: invalid row → valid row → valid col
            var inputProvider = new TestInputProvider(new[] { "abc", "0", "1" });
            var player = new HumanPlayer(Symbol.Cross, inputProvider);

            var move = player.GetNextMove();

            Assert.Equal(0, move[0]);
            Assert.Equal(1, move[1]);
        }

        [Fact]
        public void GetNextMove_Should_Ignore_Invalid_Col_Then_Accept_Valid_Col() {
            // Inputs: valid row → invalid col → valid col
            var inputProvider = new TestInputProvider(new[] { "2", "xyz", "1" });
            var player = new HumanPlayer(Symbol.Circle, inputProvider);

            var move = player.GetNextMove();

            Assert.Equal(2, move[0]);
            Assert.Equal(1, move[1]);
        }

        [Fact]
        public void Symbol_Should_Be_Readonly_And_Set_By_Constructor() {
            var inputProvider = new TestInputProvider(new[] { "0", "0" });

            var player = new HumanPlayer(Symbol.Cross, inputProvider);

            Assert.Equal(Symbol.Cross, player.Symbol);
        }
    }
}
