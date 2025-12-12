using TicTacToe;
using TicTacToe.Enums;

namespace TicTacToeTest {
    public class BoardUnitTests {
        private Board CreateBoard() => new Board();

        // public void DisplayBoard() {}


        // ---------------------------
        // Constructor and InitBoard()
        // ---------------------------

        [Fact]
        public void Board_Is_Empty_When_Created() {
            // Arrange
            var board = CreateBoard();

            // Act - Assert
            Assert.Equal(9, board.GetEmptyCells().Count);
        }

        // --------------
        // GetGameState()
        // --------------

        [Fact]
        public void GetGameState_Should_Return_CircleWins_On_Row() {
            // Arrange
            var board = CreateBoard();
            
            board.PlayMove(0, 0, Symbol.Circle);
            board.PlayMove(0, 1, Symbol.Circle);
            board.PlayMove(0, 2, Symbol.Circle);

            // Act - Assert
            Assert.Equal(GameState.CircleWins, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_CrossWins_On_Column() {
            // Arrange
            var board = CreateBoard();

            board.PlayMove(0, 1, Symbol.Cross);
            board.PlayMove(1, 1, Symbol.Cross);
            board.PlayMove(2, 1, Symbol.Cross);

            // Act - Assert
            Assert.Equal(GameState.CrossWins, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_CircleWins_On_MainDiagonal() {
            // Arrange
            var board = CreateBoard();

            board.PlayMove(0, 0, Symbol.Circle);
            board.PlayMove(1, 1, Symbol.Circle);
            board.PlayMove(2, 2, Symbol.Circle);

            // Act - Assert
            Assert.Equal(GameState.CircleWins, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_CrossWins_On_AntiDiagonal() {
            // Arrange
            var board = CreateBoard();

            board.PlayMove(0, 2, Symbol.Cross);
            board.PlayMove(1, 1, Symbol.Cross);
            board.PlayMove(2, 0, Symbol.Cross);

            // Act - Assert
            Assert.Equal(GameState.CrossWins, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_Draw_When_No_Empty_Cell_And_No_Winner() {
            // Arrange
            var board = CreateBoard();

            // X O X
            // X X O
            // O X O

            board.PlayMove(0, 0, Symbol.Cross);
            board.PlayMove(0, 1, Symbol.Circle);
            board.PlayMove(0, 2, Symbol.Cross);

            board.PlayMove(1, 0, Symbol.Cross);
            board.PlayMove(1, 1, Symbol.Cross);
            board.PlayMove(1, 2, Symbol.Circle);

            board.PlayMove(2, 0, Symbol.Circle);
            board.PlayMove(2, 1, Symbol.Cross);
            board.PlayMove(2, 2, Symbol.Circle);

            // Act - Assert
            Assert.Equal(GameState.Draw, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_InProgress_On_New_Board() {
            // Arrange
            var board = CreateBoard();

            // Act - Assert
            Assert.Equal(GameState.InProgress, board.GetGameState());
        }

        [Fact]
        public void GetGameState_Should_Return_InProgress_When_No_Winner_And_Not_Full() {
            // Arrange
            var board = CreateBoard();
            board.PlayMove(0, 0, Symbol.Circle);

            // Act - Assert
            Assert.Equal(GameState.InProgress, board.GetGameState());
        }


        // ----------
        // PlayMove()
        // ----------

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(3, 2)]
        [InlineData(0, -1)]
        [InlineData(2, 3)]
        public void PlayMove_Should_Return_False_On_Invalid_Coordinates(short row, short col) {
            // Arrange
            var board = CreateBoard();

            // Act
            bool ok = board.PlayMove(row, col, Symbol.Cross);

            // Assert
            Assert.False(ok);
        }

        [Fact]
        public void PlayMove_Should_Place_Symbol_When_Cell_Is_Empty() {
            // Arrange
            var board = CreateBoard();
            
            // Act
            bool moveOk = board.PlayMove(0, 0, Symbol.Circle);

            // Assert
            Assert.True(moveOk);
            Assert.Equal(GameState.InProgress, board.GetGameState());
            Assert.DoesNotContain(board.GetEmptyCells(), c => c[0] == 0 && c[1] == 0);
        }

        [Fact]
        public void PlayMove_Should_Return_False_If_Cell_Is_Taken() {
            // Arrange
            var board = CreateBoard();
            board.PlayMove(1, 1, Symbol.Cross);

            // Act
            var ok = board.PlayMove(1, 1, Symbol.Circle);

            // Assert
            Assert.False(ok);
        }

        [Fact]
        public void Move_In_Range_On_Empty_Cell_But_Board_Not_Empty_Returns_True() {
            // Arrange
            var board = CreateBoard();
            board.PlayMove(0, 0, Symbol.Circle);

            // Act
            bool movePlayed = board.PlayMove(1, 1, Symbol.Cross);

            // Assert
            Assert.True(movePlayed);
        }

        // ---------------
        // GetEmptyCells()
        // ---------------

        [Fact]
        public void GetEmptyCells_Should_Return_9_On_New_Board() {
            // Arrange
            var board = CreateBoard();

            // Act
            var cells = board.GetEmptyCells();

            // Assert
            Assert.Equal(9, cells.Count);
        }

        [Fact]
        public void GetEmptyCells_Should_Decrease_When_Moves_Are_Played() {
            // Arrange
            var board = CreateBoard();

            /*
             * OO#
             * X##
             * ###
             */

            board.PlayMove(0, 0, Symbol.Circle);
            board.PlayMove(1, 0, Symbol.Cross);
            board.PlayMove(0, 1, Symbol.Circle);

            // Act - Assert
            Assert.Equal(6, board.GetEmptyCells().Count);
        }
    }
}
