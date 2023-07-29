using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Entities.WatchlistAggregate
{
    public class Watchlist : BaseEntity, IAggregateRoot
    {
        public string CustomerId { get; private set; }

        public IReadOnlyCollection<WatchlistMovie> WatchlistMovies => _watchlistMovies.AsReadOnly();
        private readonly List<WatchlistMovie> _watchlistMovies = new List<WatchlistMovie>();

        public Watchlist(string id)
        {
            CustomerId = id;
        }

        public void AddMovieToWatchlist(int movieId, bool isWatched)
        {
            if (!WatchlistMovies.Any(x => x.MovieId == movieId))
            {
                _watchlistMovies.Add(new WatchlistMovie(movieId, isWatched));
                return;
            }
            throw new MovieAlreadyExistInCollectionException(movieId);
        }
    }
}
