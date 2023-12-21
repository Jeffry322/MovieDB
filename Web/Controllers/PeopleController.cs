using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Objects.Movies;

namespace Web.Controllers
{
    [AllowAnonymous]
    public sealed class PeopleController : Controller
    {
        private readonly ISearchService _searchService;

        public PeopleController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IActionResult> Details(int personId)
        {
            var person  = await _searchService.GetPersonAsync(personId);

            return View(person);
        }

        public async Task<IActionResult> GetMovieCast(int movieId)
        {
            var credits = await _searchService.GetCreditsAsync(movieId);

            return View(credits.Cast);
        }
    }
}
