using Domain.Entities.FavoritesAggregate;
using Domain.Entities.WatchlistAggregate;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieSearchService _movieSearchService;
        private readonly IMoviePreviewModelService _moviePreviewModelService;
        private readonly IRepository<Watchlist> _watchlistRepositort;
        private readonly IRepository<Favorites> _favoritesRepository;

        public MovieController(IRepository<Favorites> favoritesRepository,
            IRepository<Watchlist> watchlistRepositort,
            IMovieSearchService movieSearchService,
            IMoviePreviewModelService moviePreviewModelService)
        {
            _favoritesRepository = favoritesRepository;
            _watchlistRepositort = watchlistRepositort;
            _movieSearchService = movieSearchService;
            _moviePreviewModelService = moviePreviewModelService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var trendingMovies = await _moviePreviewModelService.GetTrendingMovies();
            return View(trendingMovies.Take(26));
        }
    }
}
