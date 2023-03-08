using Framework.Application;
using Framework.Helpers;

namespace MB.Application.Contract.CommentAgg;

public interface ICommentApplication
{
    Task<List<CommentListDto>> GetListBy(ulong articleId);
    Task<OperationResult> Create(CreateCommentCommand command);
    Task<OperationResult> ChangeStatus(ulong id,CommentStatus status);
}