using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe {
    internal class Game {
        private string[,] Board { get; set; }
        private const short BOARD_SIZE = 3;
        private Turn turn;

        public Game() {
            Board = new string[BOARD_SIZE, BOARD_SIZE];

            for(int i = 0; i < BOARD_SIZE; i++) {
                for(int j = 0; j < BOARD_SIZE; j++) {
                    Board[i, j] = "#";
                }
            }

            turn = Turn.Circle;
        }

        public void displayBoard() {
            for(int i = 0; i < BOARD_SIZE; i++) {
                for(int j = 0; j < BOARD_SIZE; j++) {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void getUserInput() {
            Console.WriteLine("It's " + turn + "'s turn.");

            Console.WriteLine("Enter à row :");
            short row = short.Parse(Console.ReadLine());
            Console.WriteLine("Enter à col :");
            short col = short.Parse(Console.ReadLine());

            Board[row, col] = ((char) turn).ToString();
            switchTurn();
        }

        public void switchTurn() {
            turn = turn == Turn.Circle ? Turn.Cross : Turn.Circle;
        }

        public void play() {
            displayBoard();

            while(true) {
                getUserInput();
                displayBoard();
            }
        }
    }
}
