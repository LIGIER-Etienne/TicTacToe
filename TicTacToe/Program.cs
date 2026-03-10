using TicTacToe;
using TicTacToe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

class Program {
    public static IHostBuilder CreateHostBuilder(string[] args) =>

        Host.CreateDefaultBuilder(args)

        .ConfigureServices((hostContext, services) => {

    });


    static async Task Main() {
        while(true) {
            GameDbContext dbContext = new GameDbContext();

            // TODO : BotPlayer KO
            await new Game(dbContext).Play();
        }
     }
}