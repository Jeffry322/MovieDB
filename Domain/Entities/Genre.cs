using Domain.Interfaces;

namespace Domain.Entities
{
    public class Genre : BaseEntity, IAggregateRoot
    {
        public string GenreName { get; private set; }

        public Genre(string genreName)
        {
            GenreName = genreName;
        }
    }
}
