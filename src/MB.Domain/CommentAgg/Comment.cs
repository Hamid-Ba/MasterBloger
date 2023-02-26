using System;
using Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.CommentAgg.Helpers;

namespace MB.Domain.CommentAgg;

public class Comment : EntityBase
{
    public string FullName { get; private set; }
	public string Email { get; private set; }
	public string Content { get; private set; }
	public CommentStatus Status { get; private set; }
	public ulong ArticleId { get; private set; }

	public Article Article { get; private set; }

    public Comment(string fullName, string email, string content,
        CommentStatus status, ulong articleId)
    {
        // PreProcessing
        Guard(email, content, articleId);

        // Initializing
        FullName = fullName;
        Email = email;
        Content = content;
        Status = status;
        ArticleId = articleId;
    }

    public void ChangeStatus(CommentStatus newStatus)
    {
        Status = newStatus;
        LastUpdateDate = DateTime.Now;
    }

    // Guard
    private void Guard(string email, string content, ulong articleId)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException($"{email.GetType().Name} can't be null!");

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentNullException($"{content.GetType().Name} can't be null!");

        if (articleId <= 0)
            throw new FormatException($"{articleId.GetType().Name} should be greater than zero!");
    }
}