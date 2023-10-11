using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public sealed class MoviePreviewViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
    }
}
