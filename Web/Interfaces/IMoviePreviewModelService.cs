using Web.Models;

namespace Web.Interfaces
{
    public interface IMoviePreviewModelService
    {
        Task<IEnumerable<MoviePreviewViewModel>> GetTrendingMovies();
    }
}
