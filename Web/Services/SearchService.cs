using Domain.Interfaces;
using TMDbLib.Client;
using TMDbLib.Objects.Credit;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Web.Services
{
    public sealed class SearchService : ICreditsSearchService, IMovieSearchService
    {
        private TMDbClient _client = new TMDbClient(Environment.GetEnvironmentVariable("tmdb_api_key"));

        public async Task<Movie> GetMovieAsync(int movieId)
        {
            return await _client.GetMovieAsync(movieId);
        }

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

        public async Task<Credits> GetCreditsAsync(int movieId)
        {
            var result = await _client.GetMovieCreditsAsync(movieId);
            return result;
        }

        public Task<Credit> SearchCredits(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
