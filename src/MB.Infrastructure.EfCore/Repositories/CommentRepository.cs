using System.Globalization;
using Framework.Application;
using Framework.Infrastructure;
using MB.Application.Contract.CommentAgg;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    private readonly BlogContext _context;

    public CommentRepository(BlogContext context) : base(context) => _context = context;

    public async Task<List<CommentListDto>> GetListBy(ulong articleId) => await _context.Comments
        .Where(a => a.ArticleId == articleId)
        .Include(a => a.Article)
        .Select(c => new CommentListDto
        {
            Id = c.Id,
            FullName = string.IsNullOrWhiteSpace(c.FullName) ? "-" : c.FullName,
            Email = c.Email,
            ArticleTitle = c.Article!.Title,
            Content = c.Content!.Substring(0, 5) + " ...",
            Status = c.Status.GetDisplayName(),
            CreationDate = c.CreationDate.ToString(CultureInfo.CurrentCulture)
        }).OrderByDescending(c => c.Id).ToListAsync();

}

