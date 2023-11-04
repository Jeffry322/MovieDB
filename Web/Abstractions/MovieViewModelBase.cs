using System.ComponentModel.DataAnnotations;

namespace Web.Abstractions
{
    public abstract class MovieViewModelBase
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PosterPath { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
    }
}
