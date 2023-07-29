using Ardalis.GuardClauses;
using Domain.Entities.MovieAggregate;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Director : BaseEntity, IAggregateRoot
    {
        public string Fullname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string? Biography { get; private set; }
        public string? PictureUri { get; private set; }

        public IReadOnlyCollection<Movie> Movies => _movies.AsReadOnly();
        private readonly List<Movie> _movies = new List<Movie>();

        public Director(string fullname, DateTime dateOfBirth, string? biography, string? pictureUri)
        {
            Guard.Against.NullOrEmpty(fullname, nameof(fullname));
            Guard.Against.OutOfRange(dateOfBirth, nameof(dateOfBirth), new DateTime(1800, 1, 1), DateTime.Now);

            Fullname = fullname;
            DateOfBirth = dateOfBirth;
            Biography = biography;
            PictureUri = pictureUri;
        }
    }
}
