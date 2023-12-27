using TMDbLib.Objects.Movies;

namespace Web.Models
{
    public sealed class ExtendedCastModel :Cast
    {
        public int Order { get; set; }
    }
}
