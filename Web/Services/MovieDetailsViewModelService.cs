using Domain.Interfaces;
using Web.Abstractions.Interfaces;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public sealed class MovieDetailsViewModelService : IMovieDetailsViewModelService
    {
        private readonly IMovieSearchService _movieSearchService;
        private readonly IUriComposer _uriComposer;

        public MovieDetailsViewModelService(IUriComposer uriComposer,
            IMovieSearchService movieSearchService)
        {
            _uriComposer = uriComposer;
            _movieSearchService = movieSearchService;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsViewModel(int movieId)
        {
            var movie = await _movieSearchService.GetMovieAsync(movieId);

            var model  = new MovieDetailsViewModel
            {
                MovieId = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Budget = movie.Budget,
                Runtime = movie.Runtime,
                Genres = movie.Genres,
                Credits = movie.Credits,
                VoteAverage = movie.VoteAverage,
                PosterPath = await _uriComposer.ComposePicUri(movie.PosterPath, PosterSize.w780)
            };

            return model;
        }
    }
}
