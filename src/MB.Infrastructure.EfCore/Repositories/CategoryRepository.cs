using System;
using System.Globalization;
using Framework.Infrastructure;
using MB.Application.Contract.CategoryAgg;
using MB.Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly BlogContext _context;

    public CategoryRepository(BlogContext context) : base(context) => _context = context;

    public async Task<List<CategoryListDto>> GetList() => await _context.Categories
        .Select(c => new CategoryListDto
        {
            Id = c.Id,
            Title = c.Title,
            IsDelete = c.IsDelete,
            CreationDate = c.CreationDate.ToString(CultureInfo.CurrentCulture)
        }).ToListAsync();
}