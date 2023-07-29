﻿using Domain.Entities.MovieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            var directorsNavigation = builder.Metadata.FindNavigation(nameof(Movie.Directors));
            var castsNavigation = builder.Metadata.FindNavigation(nameof(Movie.Cast));
            var genresNavigation = builder.Metadata.FindNavigation(nameof(Movie.Genres));

            directorsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            castsNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
            genresNavigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(m => m.ProductionCost)
                .IsRequired(false)
                .HasDefaultValue(0);

            builder.Property(m => m.Length)
                .IsRequired(false);

            builder.Property(m => m.PictureUri)
                .IsRequired(false);

            builder.Property(m => m.Rating)
                .IsRequired(false)
                .HasDefaultValue(0)
                .HasAnnotation("MaxValue", 10);
        }
    }
}