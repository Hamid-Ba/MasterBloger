using System;
using MB.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasMaxLength(85).IsRequired();
        builder.Property(p => p.IsDelete);
        builder.Property(p => p.IsDelete);
        builder.Property(p => p.CreationDate);
        builder.Property(p => p.LastUpdateDate);
        builder.Property(p => p.DeletionDate);

        builder.HasMany(a => a.Articles)
            .WithOne(c => c.Category)
            .HasForeignKey(f => f.CategoryId);
    }
}