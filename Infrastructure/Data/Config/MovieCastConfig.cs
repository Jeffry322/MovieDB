using Domain.Entities.MovieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MovieCastConfig : IEntityTypeConfiguration<MovieCast>
    {
        public void Configure(EntityTypeBuilder<MovieCast> builder)
        {
            builder.Property(mc => mc.Role)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
