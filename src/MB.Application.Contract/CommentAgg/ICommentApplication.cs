using System;
using Framework.Application;
using Framework.Helpers;

namespace MB.Application.Contract.CommentAgg;

public interface ICommentApplication
{
    Task<List<CommentListDto>> GetList();
    Task<OperationResult> Create(CreateCommentCommand command);
    Task<OperationResult> ChangeStatus(ulong id,CommentStatus status);
}