using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;

namespace TicTacToe.Data {
    public class GameDbContext : DbContext {
        public DbSet<DbGame> Games { get; set; }

        public GameDbContext() {
        }
        //public GameDbContext(DbContextOptions<GameDbContext> options)
        //    : base(options) {
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tictactoe;Username=postgres;Password=postgres");


        }
    }
}
