namespace Domain.Exceptions
{
    public class MovieAlreadyExistInCollectionException : Exception
    {
        public MovieAlreadyExistInCollectionException(int movieId) : base($"Movie with id: {movieId} already exists")
        {
        }
    }
}
