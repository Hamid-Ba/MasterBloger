using System;
using Framework.Application;

namespace MB.Application.Contract.CategoryAgg;

public interface ICategoryApplication
{
    List<CategoryListDto> GetList();
    OperationResult ChangeStatus(bool isDelete);
    OperationResult Create(CreateCategoryCommand command);
    OperationResult Edit(EditCategoryCommand command);
}