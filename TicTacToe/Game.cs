using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TicTacToe {
    internal class Game {
        private Symbol[,] Board { get; set; }
        private const short BOARD_SIZE = 3;
        private Symbol turn;

        public Game() {
            Board = new Symbol[BOARD_SIZE, BOARD_SIZE];

            InitBoard();

            turn = Symbol.Circle;
        }

        private void InitBoard() {
            for(int i = 0; i < BOARD_SIZE; i++) {
                for(int j = 0; j < BOARD_SIZE; j++) {
                    Board[i, j] = Symbol.Empty;
                }
            }
        }

        public void DisplayBoard() {
            Console.WriteLine();

            for(int i = 0; i < BOARD_SIZE; i++) {
                for(int j = 0; j < BOARD_SIZE; j++) {
                    Console.Write((char)Board[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void GetUserInput() {
            Console.WriteLine("It's " + turn + "'s turn.");

            bool inputIsValid = false;
            string? row = "";
            string? col = "";

            while(! inputIsValid) {
                Console.WriteLine("Enter à row :");
                row = Console.ReadLine();

                Console.WriteLine("Enter à col :");
                col = Console.ReadLine();

                inputIsValid = IsInputValid(row, col);
            }

            try {
                Board[short.Parse(row), short.Parse(col)] = turn;
            } catch(Exception e) {
                // IsInputValid() KO
                Console.Error.WriteLine(e.ToString());
            }
            
            SwitchTurn();
        }

        private bool IsInputValid(string? row, string? col) {
            short shRow;
            short shCol;

            try {
                shRow = short.Parse(row);
            } catch(FormatException) {
                Console.Error.WriteLine("Invalid row format, integer expected");
                return false;
            }

            try {
                shCol = short.Parse(col);
            } catch(FormatException) {
                Console.Error.WriteLine("Invalid col format, integer expected");
                return false;
            }

            if(shRow < 0 || shRow > BOARD_SIZE - 1) {
                Console.Error.WriteLine("Row must be >= 0 and < " + BOARD_SIZE);
                return false;
            }

            if(shCol < 0 || shCol > BOARD_SIZE - 1) {
                Console.Error.WriteLine("Col must be >= 0 and < " + BOARD_SIZE);
                return false;
            }

            if(! Board[shRow, shCol].Equals(Symbol.Empty)) {
                Console.Error.WriteLine("Slot [" + shRow + ", " + shCol + "] is already taken");
                return false;
            }

            return true;
        }

        private void SwitchTurn() {
            turn = turn == Symbol.Circle ? Symbol.Cross : Symbol.Circle;
        }
        private bool LineMatch(Symbol a, Symbol b, Symbol c) {
            return !a.Equals(Symbol.Empty) && a == b && b == c;
        }
        private GameState GetGameState() {

            // Rows
            for(int i = 0; i < 3; i++) {
                if(LineMatch(Board[i, 0], Board[i, 1], Board[i, 2]))
                    return Board[i, 0].Equals(Symbol.Circle) ? GameState.CircleWins : GameState.CrossWins;
            }

            // Columns
            for(int j = 0; j < 3; j++) {
                if(LineMatch(Board[0, j], Board[1, j], Board[2, j]))
                    return Board[0, j].Equals(Symbol.Circle) ? GameState.CircleWins : GameState.CrossWins;
            }

            // Diagonals
            if(LineMatch(Board[0, 0], Board[1, 1], Board[2, 2]))
                return Board[0, 0].Equals(Symbol.Circle) ? GameState.CircleWins : GameState.CrossWins;

            if(LineMatch(Board[0, 2], Board[1, 1], Board[2, 0]))
                return Board[0, 2].Equals(Symbol.Circle) ? GameState.CircleWins : GameState.CrossWins;

            // Draw check
            bool full = true;
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    if(Board[i, j].Equals(Symbol.Empty))
                        full = false;

            return full ? GameState.Draw : GameState.InProgress;
        }

        public void Play() {
            bool playAgain = true;

            while(playAgain) {
                DisplayBoard();

                GameState gameState = GameState.InProgress;
                while(gameState.Equals(GameState.InProgress)) {
                    GetUserInput();
                    DisplayBoard();
                    gameState = GetGameState();
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

                InitBoard();
            }
        }
    }
}
