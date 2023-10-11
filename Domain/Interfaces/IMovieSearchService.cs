using TMDbLib.Objects.Search;

namespace Domain.Interfaces
{
    public interface IMovieSearchService
    {
        Task<IEnumerable<SearchMovie>> SearchAsync(string query);
        Task<IEnumerable<SearchMovie>> GetTrendingMovies();
    }
}
