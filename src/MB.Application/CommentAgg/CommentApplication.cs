using Framework.Application;
using Framework.Helpers;
using MB.Application.Contract.CommentAgg;
using MB.Domain.ArticleAgg.DomainService;
using MB.Domain.CommentAgg;

namespace MB.Application.CommentAgg;

public class CommentApplication : ICommentApplication
{
    private readonly ICommentRepository _commentRepository;
    private readonly IArticleDomainService _articleDomainService;

    public CommentApplication(ICommentRepository commentRepository, IArticleDomainService articleDomainService)
    {
        _commentRepository = commentRepository;
        _articleDomainService = articleDomainService;
    }

    public async Task<OperationResult> ChangeStatus(ulong id, CommentStatus status)
    {
        OperationResult result = new();

        var comment = await _commentRepository.GetEntityByIdAsync(id);
        comment.ChangeStatus(status);

        await _commentRepository.SaveChangesAsync();

        return result.Succeeded(new
        {
            articleId = comment.ArticleId,
            status = comment.Status.GetDisplayName()
        }, $"{comment.FullName}'s Comment Has Been Modified");
    }

    public async Task<OperationResult> Create(CreateCommentCommand command)
    {
        OperationResult result = new();

        var comment = new Comment(command.FullName!, command.Email!, command.Content!, command.ArticleId, _articleDomainService);

        await _commentRepository.AddEntityAsync(comment);
        await _commentRepository.SaveChangesAsync();

        return result.Succeeded(command.ArticleId, $"{command.FullName}'s Comment Has Been Created");
    }

    public async Task<List<CommentListDto>> GetListBy(ulong articleId) => await _commentRepository.GetListBy(articleId);
}