using Domain.Entities;
using Domain.Entities.MovieAggregate;
using Infrastructure.Constants;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public sealed class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILogger logger)
        {
            try
            {
                if (!context.Actors.Any())
                {
                    await context.Actors.AddRangeAsync(GetPreconfiguredActors());
                    await context.SaveChangesAsync();

                    logger.LogInformation("Actors were seeded successfully.");
                }

                if (!context.Directors.Any())
                {
                    await context.Directors.AddRangeAsync(GetPreconfiguredDirectors());
                    await context.SaveChangesAsync();

                    logger.LogInformation("Directors were seeded successfully.");
                }

                if (!context.Genres.Any())
                {
                    await context.Genres.AddRangeAsync(GetPreconfiguredGenres());
                    await context.SaveChangesAsync();

                    logger.LogInformation("Genres were seeded successfully.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        private static IEnumerable<Actor> GetPreconfiguredActors()
        {
            return new List<Actor>
            {
                new("Tom Hanks", new DateTime(1956, 7, 9), ActorsBios.TOM_HANKS_BIO, "C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Actors\\Tom_Hanks.jpg"),
                new("Steve Buscemi", new DateTime(1957, 12, 13), ActorsBios.STEVE_BUSCEMI_BIO, "C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Actors\\Steve_Buscemi.jpg"),
                new("Nicole Kidman", new DateTime(1967, 6, 20), ActorsBios.NICOLE_KIDMAN_BIO, "C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Actors\\Nicole_Kidman.jpg"),
                new("Leonardo DiCaprio", new DateTime(1974, 11, 11), ActorsBios.LEONARDO_DICAPRIO_BIO, "C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Actors\\Leonardo_DiCaprio.jpg"),
            };
        }

        private static IEnumerable<Director> GetPreconfiguredDirectors()
        {
            return new List<Director>
              {
                  new("Joel Coen", new DateTime(1954, 11, 29), DirectorsBios.JOEL_COEN_BIO,"C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Directors\\Joel_Coen.jpg"),
                  new("Ethan Coen", new DateTime(1957, 9, 21), DirectorsBios.ETHAN_COEN_BIO,"C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Directors\\Ethan_Coen.jpg"),
                  new("Lars von Trier", new DateTime(1956, 4, 30), DirectorsBios.LARS_VON_TRIER_BIO,"C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Directors\\Lars_von_Trier.jpg"),
                  new("Guy Ritchie", new DateTime(1968, 9, 10), DirectorsBios.GUY_RITCHIE_BIO, "C:\\Users\\Jeffry\\source\\repos\\MovieDB\\Web\\wwwroot\\Images\\Directors\\Guy_Ritchie.jpg")
              };
        }

        private static IEnumerable<Movie> GetPreconfiguredMovie()
        {
            return new List<Movie>
            {

            };
        }

        private static IEnumerable<Genre> GetPreconfiguredGenres()
        {
            return new List<Genre>
            {
                new("Action"),
                new("Adventure"),
                new("Animation"),
                new("Comedy"),
                new("Crime"),
                new("Documentary"),
                new("Drama"),
                new("Family"),
                new("Fantasy"),
                new("History"),
                new("Horror"),
                new("Music"),
                new("Mystery"),
                new("Romance"),
                new("Science Fiction"),
                new("TV Movie"),
                new("Thriller"),
                new("War"),
                new("Western"),
            };
        }
    }
}
