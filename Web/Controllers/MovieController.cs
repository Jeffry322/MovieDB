using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Abstractions.Interfaces;
using Web.Interfaces;
using Ardalis.GuardClauses;

namespace Web.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieSearchService _movieSearchService;
        private readonly IMoviePreviewModelService _moviePreviewModelService;
        private readonly IMovieDetailsViewModelService _movieDetailsViewModelService;

        public MovieController(IMovieSearchService movieSearchService,
            IMoviePreviewModelService moviePreviewModelService,
            IMovieDetailsViewModelService movieDetailsViewModelService)
        {
            _movieSearchService = movieSearchService;
            _moviePreviewModelService = moviePreviewModelService;
            _movieDetailsViewModelService = movieDetailsViewModelService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var trendingMovies = await _moviePreviewModelService.GetTrendingMovies();

            Guard.Against.NullOrEmpty(trendingMovies, nameof(trendingMovies));

            return View(trendingMovies.Take(26));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int movieId)
        {
            var movie = await _movieDetailsViewModelService.GetMovieDetailsViewModel(movieId);

            Guard.Against.Null(movie, nameof(movie));

            return View(movie);
        }
    }
}
