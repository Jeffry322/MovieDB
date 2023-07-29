using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.MovieAggregate;
using Domain.Entities.WatchlistAggregate;
using System.Reflection;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actore { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Watchlist> WatchLists { get; set; }
        public DbSet<WatchlistMovie> WatchlistMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
