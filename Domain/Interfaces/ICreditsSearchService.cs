using TMDbLib.Objects.Credit;

namespace Domain.Interfaces
{
    public interface ICreditsSearchService
    {
        public Task<Credit> SearchCredits (int movieId);
    }
}
