using System;
using Framework.Domain;
using MB.Domain.ArticleAgg.DomainService;
using MB.Domain.CategoryAgg;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg;

public class Article : EntityBase
{
    public string Title { get; private set; }
	public string ShortDescription { get; private set; }
	public string Description { get; private set; }
	public string Image { get; private set; }
	public ulong CategoryId { get; private set; }
    
    public Category Category { get; private set; }
    public ICollection<Comment> Comments { get; private set; }

    public Article(string title, string shortDescription, string description,
        string image, ulong categoryId, IArticleDomainService articleDomainService)
    {
        // PreProcessing
        Guard(title, shortDescription, description, categoryId);
        articleDomainService.IsTitleExist(title);

        // Initializing
        Title = title;
        ShortDescription = shortDescription;
        Description = description;
        Image = image;
        CategoryId = categoryId;
        Comments = new List<Comment>();
    }

    public void Edit(string title, string shortDescription, string description,
        string image, ulong categoryId, IArticleDomainService articleDomainService)
    {
        // PreProcessing
        Guard(title, shortDescription, description, categoryId);
        articleDomainService.IsTitleExist(title);

        // Initializing
        Title = title;
        ShortDescription = shortDescription;
        Description = description;

        if(!string.IsNullOrWhiteSpace(title))
            Image = image;

        CategoryId = categoryId;
        LastUpdateDate = DateTime.UtcNow;
    }

    // Guard
    private void Guard(string title, string shortDescription, string description, ulong categoryId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException($"{title.GetType().Name} can't be null");

        if (string.IsNullOrWhiteSpace(shortDescription))
            throw new ArgumentNullException($"{shortDescription.GetType().Name} can't be null");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException($"{description.GetType().Name} can't be null");

        if (categoryId <= 0)
            throw new FormatException($"{categoryId.GetType().Name} should be greater than 0");
    }
}