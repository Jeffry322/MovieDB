using Microsoft.EntityFrameworkCore;
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
