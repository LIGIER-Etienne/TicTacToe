using TicTacToe;

class Program {
     static async Task Main() {
        while(true) {
            // TODO : BotPlayer KO
           await new Game().Play();
        }
     }
}
