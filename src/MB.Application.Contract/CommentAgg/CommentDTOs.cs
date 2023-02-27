using System;
using Framework.Helpers;

namespace MB.Application.Contract.CommentAgg;

public class CommentListDto
{
    public ulong Id { get;  set; }
    public string? FullName { get;  set; }
    public string? Email { get;  set; }
    public string? Content { get;  set; }
    public CommentStatus Status { get;  set; }
    public string? ArticleTitle { get;  set; } 
    public string? CreationDate { get;  set; }
}

public class CreateCommentCommand
{
    public ulong ArticleId { get;  set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Content { get; set; }
}