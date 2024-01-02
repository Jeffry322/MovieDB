using Newtonsoft.Json;
using TMDbLib.Objects.General;
using TMDbLib.Objects.People;

namespace Domain.Extensions
{
    public class CreditsExtension
    {
        public List<ExtendedMovieRole>? Cast { get; set; }
        public List<Crew>? Crew { get; set; }
        public int Id { get; set; }
    }

    public class ExtendedMovieRole : MovieRole
    {
        public ExtendedMovieRole(int order)
        {
            Order = order;
        }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
