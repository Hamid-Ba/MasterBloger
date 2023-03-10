using MB.Domain.ArticleAgg.Exceptions;

namespace MB.Domain.ArticleAgg.DomainService;

public class ArticleDomainService : IArticleDomainService
{
    private readonly IArticleRepository _articleRepository;

    public ArticleDomainService(IArticleRepository articleRepository) => _articleRepository = articleRepository;

    public void CanBeModified(ulong id, string title)
    {
        if (_articleRepository.Exists(a => a.Title == title && a.Id != id))
            throw new ArticleTitleExistsException($"there is an article with this {title.GetType().Name}!");
    }

    public void IsArticleExistWithThis(ulong id)
    {
        if (!_articleRepository.Exists(a => a.Id == id))
            throw new ArticleDoesNotExist($"there is not an article with the id = {id}!");
    }

    public void IsTitleExist(string title)
    {
        if (_articleRepository.Exists(a => a.Title == title))
            throw new ArticleTitleExistsException($"there is an article with this {title.GetType().Name}!");
    }
}