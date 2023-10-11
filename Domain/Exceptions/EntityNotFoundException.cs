using System.Runtime.Serialization;

namespace Infrastructure.Data
{
    [Serializable]
    public sealed class EntityNotFoundException : Exception
    {
        private string name;
        private int id;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public EntityNotFoundException(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}