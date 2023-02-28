using Framework.Infrastructure;
using MB.Application.ArticleAgg;
using MB.Application.CategoryAgg;
using MB.Application.CommentAgg;
using MB.Application.Contract.ArticleAgg;
using MB.Application.Contract.CategoryAgg;
using MB.Application.Contract.CommentAgg;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.DomainService;
using MB.Domain.CategoryAgg;
using MB.Domain.CategoryAgg.DomainService;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Configuration;
public static class Bootstrapper
{
    public static void Configure(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BlogContext>(options => options.UseNpgsql(connectionString));

        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ICategoryApplication, CategoryApplication>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();

        services.AddTransient<IArticleDomainService, ArticleDomainService>();
        services.AddTransient<IArticleApplication, ArticleApplication>();
        services.AddTransient<IArticleRepository, ArticleRepository>();

        services.AddTransient<ICommentApplication, CommentApplication>();
        services.AddTransient<ICommentRepository, CommentRepository>();

        services.AddTransient<IUnitOfWork, UnitOfWorkEF>();
    }
}