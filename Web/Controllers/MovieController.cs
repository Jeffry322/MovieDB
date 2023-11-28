using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Abstractions.Interfaces;
using Web.Interfaces;
using Ardalis.GuardClauses;
using Domain.Entities.FavoritesAggregate;
using Domain.Entities.WatchlistAggregate;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMoviePreviewModelService _moviePreviewModelService;
        private readonly IMovieDetailsViewModelService _movieDetailsViewModelService;
        private readonly IRepository<Favorites> _favoritesRepository;
        private readonly IRepository<Watchlist> _watchlistRepository;

        public MovieController(IMoviePreviewModelService moviePreviewModelService,
            IMovieDetailsViewModelService movieDetailsViewModelService,
            IRepository<Favorites> favoritesRepository,
            IRepository<Watchlist> watchlistRepository)
        {
            _moviePreviewModelService = moviePreviewModelService;
            _movieDetailsViewModelService = movieDetailsViewModelService;
            _favoritesRepository = favoritesRepository;
            _watchlistRepository = watchlistRepository;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var favorites = await _favoritesRepository.FirstOrDeffaultAsync(f => f.CustomerId == userId);

            if (favorites == null)
            {
                favorites = new Favorites(userId);
                await _favoritesRepository.AddAsync(favorites);
            }

            return View(favorites);
        }
    }
}
