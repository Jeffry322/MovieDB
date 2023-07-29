using Domain.Entities.FavoritesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class FavoriteMovieConfig : IEntityTypeConfiguration<FavoriteMovie>
    {
        public void Configure(EntityTypeBuilder<FavoriteMovie> builder)
        {
            builder.Property(fm => fm.Rating)
                .IsRequired()
                .HasDefaultValue(0)
                .HasAnnotation("MaxValue", 10);

            builder.Property(fm => fm.Review)
                .IsRequired(false)
                .HasMaxLength(2048);
        }
    }
}
