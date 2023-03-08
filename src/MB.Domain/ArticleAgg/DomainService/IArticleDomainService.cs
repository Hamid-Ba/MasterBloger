namespace MB.Domain.ArticleAgg.DomainService;

public interface IArticleDomainService
{
    void IsTitleExist(string title);
    void IsArticleExistWithThis(ulong id);
    void CanBeModified(ulong id, string title);
}