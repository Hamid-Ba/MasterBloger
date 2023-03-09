using System;
using System.Globalization;
using Framework.Infrastructure;
using MB.Application.Contract.ArticleAgg;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    private readonly BlogContext _context;

    public ArticleRepository(BlogContext context) : base(context) => _context = context;

    public async Task<ArticleDto> GetBy(ulong id) => (await _context.Articles
        .Include(c => c.Category)
        .Select(a => new ArticleDto
        {
            Id = a.Id,
            Title = a.Title,
            CategoryTitle = a.Category!.Title,
            Image = a.Image,
            ShortDescription = a.ShortDescription,
            Description = a.Description,
            IsDelete = a.IsDelete,
            CreationDate = a.CreationDate.ToString(CultureInfo.CurrentCulture)
        }).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id))!;

    public async Task<EditArticleCommand> GetForEditBy(ulong id) => (await _context.Articles.Select(a => new EditArticleCommand
    {
        Id = a.Id,
        Title = a.Title,
        CategoryId = a.CategoryId,
        ShortDescription = a.ShortDescription,
        Description = a.Description
    }).FirstOrDefaultAsync(a => a.Id == id))!;

    public async Task<List<ArticleListDto>> GetList() => await _context.Articles
        .Include(c => c.Category)
        .Select(a => new ArticleListDto
        {
            Id = a.Id,
            Title = a.Title,
            CategoryTitle = a.Category!.Title,
            Image = a.Image,
            ShortDescription = a.ShortDescription!.Substring(0, 10) + " ...",
            IsDelete = a.IsDelete,
            CreationDate = a.CreationDate.ToString(CultureInfo.CurrentCulture)
        }).OrderByDescending(a => a.Id).ToListAsync();
}