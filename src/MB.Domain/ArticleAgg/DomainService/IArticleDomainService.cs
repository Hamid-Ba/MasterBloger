using System;

namespace MB.Domain.ArticleAgg.DomainService;

public interface IArticleDomainService
{
    void IsTitleExist(string title);
}