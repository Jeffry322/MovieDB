using Domain.Extensions;
using Newtonsoft.Json;

namespace Web.Services
{
    public sealed class CustomTMDBLibClient
    {
        private readonly HttpClient _httpClient;

        public CustomTMDBLibClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CreditsExtension> GetMovieCredits(int personId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/person/{personId}/movie_credits?language=en-US"),
            };

            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                Environment.GetEnvironmentVariable("api_read_access_token"));

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject<CreditsExtension>(json);

                return obj;
            }
        }
    }
}
