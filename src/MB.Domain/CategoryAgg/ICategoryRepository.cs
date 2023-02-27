using System;
using Framework.Domain;
using MB.Application.Contract.CategoryAgg;

namespace MB.Domain.CategoryAgg;

public interface ICategoryRepository : IRepository<Category>
{
   Task<List<CategoryListDto>> GetList();
}