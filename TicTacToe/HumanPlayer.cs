namespace TicTacToe {
    internal class HumanPlayer :Player {

        internal HumanPlayer(Symbol symbol) : base(symbol) { }

        internal override short[] GetNextMove() {
            Console.WriteLine("It's " + Symbol + "'s turn.");

            bool inputIsValid = false;
            short row = -1;
            short col = -1;

            while(!inputIsValid) {
                inputIsValid = true;

                Console.WriteLine("Enter à row :");
                if(!short.TryParse(Console.ReadLine()?.Trim(), out row)) {
                    Console.Error.WriteLine("Invalid row format, integer expected");
                    inputIsValid = false;
                    continue;
                }

                Console.WriteLine("Enter à col :");
                if(!short.TryParse(Console.ReadLine()?.Trim(), out col)) {
                    Console.Error.WriteLine("Invalid col format, integer expected");
                    inputIsValid = false;
                    continue;
                }
            }

            return [row, col];
        }
    }
}
