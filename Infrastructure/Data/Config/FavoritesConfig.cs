using Domain.Entities.FavoritesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Config
{
    public class FavoritesConfig : IEntityTypeConfiguration<Favorites>
    {
        public void Configure(EntityTypeBuilder<Favorites> builder)
        {
            var navigationBuilder = builder.Metadata.FindNavigation(nameof(Favorites.FavoriteMovie));
            navigationBuilder?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(f => f.CustomerId)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
