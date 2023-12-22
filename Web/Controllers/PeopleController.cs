using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Services;

namespace Web.Controllers
{
    [AllowAnonymous]
    public sealed class PeopleController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IUriComposer _uriComposer;

        public PeopleController(ISearchService searchService, IUriComposer uriComposer)
        {
            _searchService = searchService;
            _uriComposer = uriComposer;
        }

        public async Task<IActionResult> Details(int personId)
        {
            var person  = await _searchService.GetPersonAsync(personId);

            person.ProfilePath = await _uriComposer.ComposePicUri(person.ProfilePath, PosterSize.w780);

            return View(person);
        }

        public async Task<IActionResult> GetMovieCast(int movieId)
        {
            var credits = await _searchService.GetCreditsAsync(movieId);

            return View(credits.Cast);
        }
    }
}
