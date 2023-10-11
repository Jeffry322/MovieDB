using Domain.Interfaces;
using TMDbLib.Client;
using Web.Interfaces;

namespace Web.Services
{
    public enum PosterSize
    {
      w92,
      w154,
      w185,
      w342,
      w500,
      w780,
      original
    }

    public class UriComposer : IUriComposer
    {
        private readonly TMDbClient _client = new TMDbClient(Environment.GetEnvironmentVariable("tmdb_api_key"));

        public async Task<string> ComposePicUri(string picPath, PosterSize size)
        {
            var config = await _client.GetConfigAsync();
            return $"{config.Images.SecureBaseUrl}{config.Images.PosterSizes[(int)size]}/{picPath}";
        }
    }
}
