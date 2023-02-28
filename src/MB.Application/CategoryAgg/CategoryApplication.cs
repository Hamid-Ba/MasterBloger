using System;
using Framework.Application;
using Framework.Infrastructure;
using MB.Application.Contract.CategoryAgg;
using MB.Domain.CategoryAgg;
using MB.Domain.CategoryAgg.DomainService;

namespace MB.Application.CategoryAgg;

public class CategoryApplication : ICategoryApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    public CategoryApplication(ICategoryRepository categoryRepository,
        ICategoryDomainService categoryDomainService,
        IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Active(ulong id)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var category = await _categoryRepository.GetEntityByIdAsync(id);
        category.Active();

        _unitOfWork.CommitTransaction();

        return result.Succeeded("Category Has Been Activated");
    }

    public async Task<OperationResult> DeActive(ulong id)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var category = await _categoryRepository.GetEntityByIdAsync(id);
        category.Deactive();

        _unitOfWork.CommitTransaction();

        return result.Succeeded("Category Has Been Deactivated");
    }

    public async Task<OperationResult> Create(CreateCategoryCommand command)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var category = new Category(command.Title!, _categoryDomainService);
        await _categoryRepository.AddEntityAsync(category);

        _unitOfWork.CommitTransaction();

        return result.Succeeded($"Category With Title {category.Title} Has Been Created");
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var category = await _categoryRepository.GetEntityByIdAsync(command.Id);
        category.Edit(command.Title!, _categoryDomainService);

        _unitOfWork.CommitTransaction();

        return result.Succeeded($"Category With Title {category.Title} Has Been Modified");
    }

    public async Task<List<CategoryListDto>> GetList() => await _categoryRepository.GetList();
}