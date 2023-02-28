using System;
using MB.Domain.ArticleAgg;
using MB.Domain.CategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore;

public class BlogContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(CategoryMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}