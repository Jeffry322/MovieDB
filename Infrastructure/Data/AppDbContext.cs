using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.MovieAggregate;
using Domain.Entities.WatchlistAggregate;
using System.Reflection;
using Domain.Entities.FavoritesAggregate;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        #pragma warning disable CS8618 // Required by Entity Framework
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<WatchlistMovie> WatchlistMovies { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<FavoriteMovie> FavoritesMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
