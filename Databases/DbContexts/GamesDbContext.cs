using Databases.Tables;
using Microsoft.EntityFrameworkCore;

namespace Databases.DbContexts
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Studio> Studios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                    .HasMany(g => g.Genres)
                    .WithMany(g => g.Games)
                    .UsingEntity<GameGenre>();

            modelBuilder.Entity<Game>()
                    .HasMany(g => g.Studios)
                    .WithMany(g => g.Games)
                    .UsingEntity<GameStudio>();
        }
    }
}
