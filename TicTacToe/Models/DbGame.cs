using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Enums;

namespace TicTacToe.Models {
    public class DbGame {
        public int Id { get; set; }
        public required DateTime PlayedAt { get; set; }
        public required Symbol[,] Board { get; set; }
        public required GameState GameState { get; set; }
        public required Symbol Turn { get; set; }
    }
}
