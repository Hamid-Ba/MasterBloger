using System;
using Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.CategoryAgg.DomainService;

namespace MB.Domain.CategoryAgg;

public class Category : EntityBase
{
	public string? Title { get; private set; }

	public ICollection<Article>? Articles { get; private set; }

	protected Category() { }

	public Category(string title,ICategoryDomainService categoryDomainService)
	{
		// PreProcessing
		Guard(title);
		categoryDomainService.IsTitleExist(title);

		// Initializing
		Title = title;
		Articles = new List<Article>();
	}

	public void Edit(string title,ICategoryDomainService categoryDomainService)
	{
		// PreProcessing
        Guard(title);
		categoryDomainService.IsTitleExist(title);

		// Initializing
        Title = title;
		LastUpdateDate = DateTime.UtcNow;
	}

	// Guard
	private void Guard(string title)
	{
		if (string.IsNullOrWhiteSpace(title))
			throw new ArgumentNullException($"{title.GetType().Name} Can't be null!");
	}
}