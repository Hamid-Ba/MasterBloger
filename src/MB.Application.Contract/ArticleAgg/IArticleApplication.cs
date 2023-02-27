using System;
using Framework.Application;

namespace MB.Application.Contract.ArticleAgg;

public interface IArticleApplication
{
    Task<List<ArticleListDto>> GetList();
    Task<OperationResult> Active(ulong id);
    Task<OperationResult> DeActive(ulong id);
    Task<OperationResult> Edit(EditArticleCommand command);
    Task<OperationResult> Create(CreateArticleCommand command);
}