using Web.Models;

namespace Web.Abstractions.Interfaces
{
    public interface IMovieDetailsViewModelService
    {
        public Task<MovieDetailsViewModel> GetMovieDetailsViewModel(int movieId);
    }
}
