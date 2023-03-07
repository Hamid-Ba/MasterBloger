using System;

namespace MB.Domain.ArticleAgg.DomainService;

public interface IArticleDomainService
{
    void IsTitleExist(string title);
    void CanBeModified(ulong id, string title);
}