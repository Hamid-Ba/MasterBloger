using System;
using Framework.Application;

namespace MB.Application.Contract.CategoryAgg;

public interface ICategoryApplication
{
    Task<List<CategoryListDto>> GetList();
    Task<OperationResult> Active(ulong id);
    Task<OperationResult> DeActive(ulong id);
    Task<OperationResult> Create(CreateCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
}