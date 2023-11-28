using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Domain.Interfaces
{
    public interface IMovieSearchService
    {
        Task<IEnumerable<SearchMovie>> SearchAsync(string query);
        Task<IEnumerable<SearchMovie>> GetTrendingMovies();
        Task<Movie> GetMovieAsync(int movieId);
        Task<Credits> GetCreditsAsync(int movieId);
    }
}
