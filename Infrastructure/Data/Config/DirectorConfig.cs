using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DirectorConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Director.Movies));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(d => d.Fullname)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(d => d.Biography)
                .IsRequired(false)
                .HasMaxLength(2048);

            builder.Property(d => d.PictureUri)
                .IsRequired(false)
                .HasMaxLength(2048);

            builder.Property(d => d.DateOfBirth)
                .HasConversion(
            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );
        }
    }
}
