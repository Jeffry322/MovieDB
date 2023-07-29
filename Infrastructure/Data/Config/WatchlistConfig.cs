using Domain.Entities.WatchlistAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class WatchlistConfig : IEntityTypeConfiguration<Watchlist>
    {
        public void Configure(EntityTypeBuilder<Watchlist> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Watchlist.WatchlistMovies));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(w => w.CustomerId)
                .IsRequired();
        }
    }
}
