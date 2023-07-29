using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Entities.FavoritesAggregate
{
    public class Favorites : BaseEntity, IAggregateRoot
    {
        public string CustomerId { get; private set; }

        private readonly List<FavoriteMovie> _favoriteMovie = new List<FavoriteMovie>();
        public IReadOnlyCollection<FavoriteMovie> FavoriteMovie => _favoriteMovie.AsReadOnly();

        public Favorites(string id)
        {
            CustomerId = id;
        }

        public void AddMovieToFavorites(int movieId, int rating, string? review)
        {
            if (!FavoriteMovie.Any(x => x.MovieId == movieId))
            {
                _favoriteMovie.Add(new FavoriteMovie(movieId, Id, review, rating));
                return;
            }
            throw new MovieAlreadyExistInCollectionException(movieId);
        }
    }
}
