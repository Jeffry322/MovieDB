using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Services;

namespace Web.Components
{
    public class ScrollMenuViewComponent : ViewComponent
    {
        private readonly IUriComposer _uriComposer;
        private readonly ISearchService _searchService;

        public ScrollMenuViewComponent(ISearchService searchService, IUriComposer uriComposer)
        {
            _searchService = searchService;
            _uriComposer = uriComposer;
        }

        public async Task<IViewComponentResult> InvokeAsync(int personId)
        {
            var movies = await _searchService.GetAssociatedMoviesForPersonAsync(personId);

            foreach (var movie in movies.Cast)
            {
                movie.PosterPath = await _uriComposer.ComposePicUri(movie.PosterPath, PosterSize.w342);
            }

            //order movie by release date
            movies.Cast.OrderByDescending(m => m.ReleaseDate);

            return View(movies);
        }
    }
}
