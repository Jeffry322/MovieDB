using Ardalis.GuardClauses;
using Domain.Interfaces;

namespace Domain.Entities.MovieAggregate
{
    public class Movie : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string? PictureUri { get; private set; }
        public string Description { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int ProductionCost { get; private set; }
        public double Length { get; private set; }
        public int Rating { get; private set; }

        public IReadOnlyCollection<Genre> Genres => _genres.AsReadOnly();
        private readonly List<Genre> _genres = new List<Genre>();
        public IReadOnlyCollection<Director> Directors => _directors.AsReadOnly();
        private readonly List<Director> _directors = new List<Director>();

        private readonly List<MovieCast> _cast = new List<MovieCast>();
        public IReadOnlyCollection<MovieCast> Cast => _cast.AsReadOnly();

        public Movie(string title, string? pictureUri, string description, DateTime releaseDate, int productionCost, double length, int rating)
        {
            Guard.Against.NullOrEmpty(title, nameof(title));
            Guard.Against.OutOfRange(releaseDate, nameof(releaseDate), new DateTime(1900, 1, 1), DateTime.Now);
            Guard.Against.Negative(productionCost, nameof(productionCost));
            Guard.Against.Negative(length, nameof(length));
            Guard.Against.Negative(rating, nameof(rating));

            Title = title;
            PictureUri = pictureUri;
            Description = description;
            ReleaseDate = releaseDate;
            ProductionCost = productionCost;
            Length = length;
            Rating = rating;
        }

        public void AddCast(int actorId, string role)
        {
            if (!Cast.Any(c => c.ActorId == actorId))
            {
                _cast.Add(new MovieCast(role, actorId));
                return;
            }

            //TODO: Create custom exception
            throw new Exception("Actor already in cast");
        }

        public void SetNewRating(int rating)
        {
            Guard.Against.Negative(rating, nameof(rating));

            Rating = rating;
        }
    }
}
