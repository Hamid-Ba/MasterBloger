using System;
namespace MB.Domain.ArticleAgg.Exceptions
{
	public class ArticleTitleExistsException : Exception
	{
		public ArticleTitleExistsException() { }

		public ArticleTitleExistsException(string? message) : base(message) { }
	}
}