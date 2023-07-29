using Ardalis.GuardClauses;
using Domain.Entities.MovieAggregate;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Actor : BaseEntity, IAggregateRoot
    {
        public string Fullname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string? Biography { get; private set; }
        public string? PictureUri { get; private set; }

        public Actor(string fullname, DateTime dateOfBirth, string? biography, string? pictureUri)
        {
            Fullname = fullname;
            DateOfBirth = dateOfBirth;
            Biography = biography;
            PictureUri = pictureUri;
        }

        public void UpdateDetails(ActorDetails actorDetails)
        {
            Guard.Against.NullOrEmpty(actorDetails.Fullname, nameof(actorDetails.Fullname));
            Guard.Against.OutOfRange(actorDetails.DateOfBirth, nameof(actorDetails.DateOfBirth), new DateTime(1900, 1, 1), DateTime.Now);


            Fullname = actorDetails.Fullname;
            DateOfBirth = actorDetails.DateOfBirth;
            Biography = actorDetails.Biography;
            PictureUri = actorDetails.PictureUri;
        }

        public readonly struct ActorDetails
        {
            public string Fullname { get; }
            public DateTime DateOfBirth { get; }
            public string? Biography { get; }
            public string? PictureUri { get; }

            public ActorDetails(string fullname, DateTime dateOfBirth, string? biography, string? pictureUri)
            {
                Fullname = fullname;
                DateOfBirth = dateOfBirth;
                Biography = biography;
                PictureUri = pictureUri;
            }
        }
    }
}
