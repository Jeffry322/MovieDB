using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(actor => actor.Fullname)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(actor => actor.Biography)
                .IsRequired(false)
                .HasMaxLength(2048);

            builder.Property(actor => actor.PictureUri)
                .IsRequired(false)
                .HasMaxLength(2048);
        }
    }
}
