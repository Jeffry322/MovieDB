﻿using Domain.Extensions;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;

namespace Domain.Interfaces
{
    public interface ICreditsSearchService
    {
        public Task<Credits> GetCreditsAsync (int movieId);

        public Task<Person> GetPersonAsync (int personId);

        public Task<CreditsExtension> GetAssociatedMoviesForPersonAsync(int personId);
    }
}
