namespace MB.Domain.ArticleAgg.Exceptions;

public class ArticleTitleExistsException : Exception
{
    public ArticleTitleExistsException() { }

    public ArticleTitleExistsException(string? message) : base(message) { }
}

public class ArticleDoesNotExist : Exception
{
    public ArticleDoesNotExist() { }
    public ArticleDoesNotExist(string? message) : base(message) { }
}