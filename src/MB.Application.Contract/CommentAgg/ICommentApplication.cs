using System;
using Framework.Application;
using MB.Domain.CommentAgg.Helpers;

namespace MB.Application.Contract.CommentAgg;

public interface ICommentApplication
{
    List<CommentListDto> GetList();
    OperationResult ChangeStatus(CommentStatus status);
    OperationResult Create(CreateCommentCommand command);
}