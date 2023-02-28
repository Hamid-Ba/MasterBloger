using System;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping;

public class ArticleMapping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasMaxLength(85).IsRequired();
        builder.Property(p => p.ShortDescription).HasMaxLength(225).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Image);
        builder.Property(p => p.IsDelete);
        builder.Property(p => p.CreationDate);
        builder.Property(p => p.LastUpdateDate);
        builder.Property(p => p.DeletionDate);

        builder.HasOne(c => c.Category)
            .WithMany(a => a.Articles)
            .HasForeignKey(f => f.CategoryId);

        builder.HasMany(c => c.Comments)
            .WithOne(a => a.Article)
            .HasForeignKey(f => f.ArticleId);
    }
}