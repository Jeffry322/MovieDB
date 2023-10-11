using Domain.Interfaces;
using TMDbLib.Client;
using TMDbLib.Objects.Search;

namespace Web.Services
{
    public sealed class MovieSearchService : IMovieSearchService
    {
        private TMDbClient _client = new TMDbClient(Environment.GetEnvironmentVariable("tmdb_api_key"));

        public async Task<IEnumerable<SearchMovie>> SearchAsync(string query)
        {
            var results = await _client.SearchMovieAsync(query);
            return results.Results;
        }

        public async Task<IEnumerable<SearchMovie>> GetTrendingMovies()
        {
            var results = await _client.GetTrendingMoviesAsync(TMDbLib.Objects.Trending.TimeWindow.Week);
            return results.Results;
        }
    }
}
