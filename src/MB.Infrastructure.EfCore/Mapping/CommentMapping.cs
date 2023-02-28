using System;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.FullName).HasMaxLength(125);
        builder.Property(p => p.Email).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Content).HasMaxLength(825).IsRequired();
        builder.Property(p => p.Status);
        builder.Property(p => p.CreationDate);
        builder.Property(p => p.LastUpdateDate);
        builder.Property(p => p.DeletionDate);

        builder.HasOne(a => a.Article)
            .WithMany(c => c.Comments)
            .HasForeignKey(f => f.ArticleId);
    }
}