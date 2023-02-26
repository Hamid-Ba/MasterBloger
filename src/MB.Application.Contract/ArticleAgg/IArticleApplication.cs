using System;
using Framework.Application;

namespace MB.Application.Contract.ArticleAgg;

public interface IArticleApplication
{
    List<ArticleListDto> GetList();
    OperationResult ChangeStatus(bool isDelete);
    OperationResult Edit(EditArticleCommand command);
    OperationResult Create(CreateArticleCommand command);
}