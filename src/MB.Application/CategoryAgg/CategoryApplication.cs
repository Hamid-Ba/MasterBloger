using System;
using Framework.Application;
using MB.Application.Contract.CategoryAgg;
using MB.Domain.CategoryAgg;
using MB.Domain.CategoryAgg.DomainService;

namespace MB.Application.CategoryAgg;

public class CategoryApplication : ICategoryApplication
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public CategoryApplication(ICategoryRepository categoryRepository,
        ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Active(ulong id)
    {
        OperationResult result = new();

        var category = await _categoryRepository.GetEntityByIdAsync(id);
        category.Active();
        await _categoryRepository.SaveChangesAsync();

        return result.Succeeded("Category Has Been Activated");
    }

    public async Task<OperationResult> DeActive(ulong id)
    {
        OperationResult result = new();

        var category = await _categoryRepository.GetEntityByIdAsync(id);
        category.Deactive();
        await _categoryRepository.SaveChangesAsync();

        return result.Succeeded("Category Has Been Deactivated");
    }

    public async Task<OperationResult> Create(CreateCategoryCommand command)
    {
        OperationResult result = new();

        var category = new Category(command.Title!, _categoryDomainService);
        await _categoryRepository.AddEntityAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return result.Succeeded($"Category With Title {category.Title} Has Been Created");
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        OperationResult result = new();

        var category = await _categoryRepository.GetEntityByIdAsync(command.Id);
        category.Edit(command.Title!, _categoryDomainService);
        await _categoryRepository.SaveChangesAsync();

        return result.Succeeded($"Category With Title {category.Title} Has Been Modified");
    }

    public async Task<List<CategoryListDto>> GetList() => await _categoryRepository.GetList();
}