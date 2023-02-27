using System;
using Framework.Domain;
using MB.Application.Contract.ArticleAgg;

namespace MB.Domain.ArticleAgg;

public interface IArticleRepository : IRepository<Article>
{
    List<ArticleListDto> GetList();
}