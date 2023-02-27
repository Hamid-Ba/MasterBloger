using System;
using Framework.Domain;
using MB.Application.Contract.ArticleAgg;

namespace MB.Domain.ArticleAgg;

public interface IArticleRepository : IRepository<Article>
{
    Task<List<ArticleListDto>> GetList();
}