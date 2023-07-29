using Domain.Entities.WatchlistAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class WatchlistMovieConfig : IEntityTypeConfiguration<WatchlistMovie>
    {
        public void Configure(EntityTypeBuilder<WatchlistMovie> builder)
        {
            builder.Property(wm => wm.IsWatched)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
