using Domain.Interfaces;
using TMDbLib.Client;
using TMDbLib.Objects.Credit;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace Web.Services
{
    public sealed class SearchService : ISearchService
    {
        private TMDbClient _client = new TMDbClient(Environment.GetEnvironmentVariable("tmdb_api_key"));
        private readonly CustomTMDBLibClient _customClient;

        public SearchService(CustomTMDBLibClient customClient)
        {
            _customClient = customClient;
        }

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

        public async Task<Person> GetPersonAsync(int personId)
        {
            var person = await _client.GetPersonAsync(personId);

            return person;
        }

        public async Task<MovieCredits> GetAssociatedMoviesForPersonAsync(int personId)
        {
            var test = await _customClient.GetMovieCredits(personId);

            var results = await _client.GetPersonMovieCreditsAsync(personId);
            return results;
        }
    }
}
