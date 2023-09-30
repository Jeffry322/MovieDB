namespace Domain.Entities.WatchlistAggregate
{
    public class WatchlistMovie : BaseEntity
    {
        public bool IsWatched { get; private set; }
        public int MovieId { get; private set; }
        public int WatchlistId { get; private set; }

        public WatchlistMovie(int movieId, bool isWatched)
        {
            MovieId = movieId;
            IsWatched = isWatched;
        }
    }
}
