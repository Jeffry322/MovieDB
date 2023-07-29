using Ardalis.GuardClauses;
using Domain.Interfaces;

namespace Domain.Entities.MovieAggregate
{
    public class MovieCast : BaseEntity
    {
        public string Role { get; private set; }

        public int ActorId { get; private set; }
        public int MovieId { get; private set; }

        public MovieCast(string role, int actorId)
        {
            Guard.Against.Null(role, nameof(role));

            Role = role;
            ActorId = actorId;
        }
    }
}
