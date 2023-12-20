using System.ComponentModel.DataAnnotations;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using Web.Abstractions;

namespace Web.Models
{
    public class MovieDetailsViewModel : MovieViewModelBase
    {
        [Required]
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public long Budget { get; set; }
        public long Revenue { get; set; }
        public int? Runtime { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Credits? Credits { get; set; }
    }
}
