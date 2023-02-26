using MB.Domain.CategoryAgg.Exceptions;

namespace MB.Domain.CategoryAgg.DomainService;

public class CategoryDomainSerivce : ICategoryDomainService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryDomainSerivce(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public void IsTitleExist(string title)
    {
        if(_categoryRepository.Exists(c => c.Title == title))
            throw new CategoryTitleExistsException($"there is an category with this {title.GetType().Name}");
    }
}