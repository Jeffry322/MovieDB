using Domain.Interfaces;
using Web.Abstractions.Interfaces;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public sealed class MovieDetailsViewModelService : IMovieDetailsViewModelService
    {
        private readonly ISearchService _movieSearchService;
        private readonly IUriComposer _uriComposer;

        public MovieDetailsViewModelService(IUriComposer uriComposer,
            ISearchService movieSearchService)
        {
            _uriComposer = uriComposer;
            _movieSearchService = movieSearchService;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsViewModel(int movieId)
        {
            var movie = await _movieSearchService.GetMovieAsync(movieId);
            var credits = await _movieSearchService.GetCreditsAsync(movieId);

            var model  = new MovieDetailsViewModel
            {
                MovieId = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                ReleaseDate = movie.ReleaseDate!.Value,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Genres = movie.Genres,
                Credits = credits,
                VoteAverage = movie.VoteAverage,
                PosterPath = await _uriComposer.ComposePicUri(movie.PosterPath, PosterSize.w780)
            };

            foreach (var cast in model.Credits.Cast)
            {
                cast.ProfilePath = await _uriComposer.ComposePicUri(cast.ProfilePath, PosterSize.w185);
            }

            return model;
        }
    }
}
