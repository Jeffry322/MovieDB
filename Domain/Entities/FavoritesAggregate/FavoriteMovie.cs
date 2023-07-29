using Ardalis.GuardClauses;

namespace Domain.Entities.FavoritesAggregate
{
    public class FavoriteMovie : BaseEntity
    {
        public int Rating { get; private set; }
        public string? Review { get; private set; }
        public int MovieId { get; private set; }
        public int FavoritesId { get; private set; }

        public FavoriteMovie(int movieId, int favoritesId, string? review, int rating)
        {
            Guard.Against.Negative(rating, nameof(rating));

            MovieId = movieId;
            FavoritesId = favoritesId;
            Review = review;
            Rating = rating;
        }
    }
}
