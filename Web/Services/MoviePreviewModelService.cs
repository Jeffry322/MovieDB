using Domain.Interfaces;
using System.Globalization;
using TMDbLib.Objects.Search;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class MoviePreviewModelService : IMoviePreviewModelService
    {
        private readonly ISearchService _movieSearchService;
        private readonly IUriComposer _uriComposer;

        public MoviePreviewModelService(ISearchService movieSearchService,
            IUriComposer uriComposer)
        {
            _movieSearchService = movieSearchService;
            _uriComposer = uriComposer;
        }

        public async Task<IEnumerable<MoviePreviewViewModel>> GetTrendingMovies()
        {
            var trendingMovies = await _movieSearchService.GetTrendingMovies();
            var result = new List<MoviePreviewViewModel>();

            foreach (SearchMovie movie in trendingMovies)
            {
                result.Add(new MoviePreviewViewModel
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    VoteAverage = movie.VoteAverage,
                    PosterPath = await _uriComposer.ComposePicUri(movie.PosterPath, PosterSize.w342),
                    ReleaseDate = movie.ReleaseDate!.Value
                }); 
            }

            return result;
        }
    }
}
