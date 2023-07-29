using Domain.Interfaces;

namespace Domain.Entities
{
    public class Customer : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        public Customer(string identityGuid)
        {
            IdentityGuid = identityGuid;
        }
    }
}
