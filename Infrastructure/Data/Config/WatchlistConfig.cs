using Domain.Entities.WatchlistAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class WatchlistConfig : IEntityTypeConfiguration<Watchlist>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Watchlist> builder)
        {
            throw new NotImplementedException();
        }
    }
}
