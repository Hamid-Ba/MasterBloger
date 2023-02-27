using System;
using Framework.Application;
using Framework.Helpers;
using MB.Application.Contract.CommentAgg;
using MB.Domain.CommentAgg;

namespace MB.Application.CommentAgg;

public class CommentApplication : ICommentApplication
{
    private readonly ICommentRepository _commentRepository;

    public CommentApplication(ICommentRepository commentRepository) => _commentRepository = commentRepository;

    public async Task<OperationResult> ChangeStatus(ulong id, CommentStatus status)
    {
        OperationResult result = new();

        var comment = await _commentRepository.GetEntityByIdAsync(id);
        comment.ChangeStatus(status);
        await _commentRepository.SaveChangesAsync();

        return result.Succeeded($"{comment.FullName}'s Comment Has Been Modified");
    }

    public async Task<OperationResult> Create(CreateCommentCommand command)
    {
        OperationResult result = new();

        var comment = new Comment(command.FullName!, command.Email!, command.Content!, command.ArticleId);
        await _commentRepository.AddEntityAsync(comment);
        await _commentRepository.SaveChangesAsync();

        return result.Succeeded($"{command.FullName}'s Comment Has Been Created");
    }

    public async Task<List<CommentListDto>> GetList() => await _commentRepository.GetList();

}