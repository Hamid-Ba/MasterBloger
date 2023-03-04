using System;
using Framework.Application;
using Framework.Infrastructure;
using MB.Application.Contract.ArticleAgg;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.DomainService;

namespace MB.Application.ArticleAgg;

public class ArticleApplication : IArticleApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IArticleRepository _articleRepository;
    private readonly IArticleDomainService _articleDomainService;

    public ArticleApplication(IArticleRepository articleRepository,
        IArticleDomainService articleDomainService,
        IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _articleDomainService = articleDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<OperationResult> Active(ulong id)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var article = await _articleRepository.GetEntityByIdAsync(id);
        article.Active();

        _unitOfWork.CommitTransaction();

        return result.Succeeded(article.Id,"Article Has Been Activated");
    }

    public async Task<OperationResult> DeActive(ulong id)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var article = await _articleRepository.GetEntityByIdAsync(id);
        article.Deactive();

        _unitOfWork.CommitTransaction();

        return result.Succeeded(article.Id, "Article Has Been Deactiveted");
    }

    public async Task<OperationResult> Create(CreateArticleCommand command)
    {
        OperationResult result = new();

        var imageName = Uploader.ImageUploader(command.Image!, "articles", null!);

        var article = new Article(command.Title!, command.ShortDescription!, command.Description!
            , imageName, command.CategoryId, _articleDomainService);
        await _articleRepository.AddEntityAsync(article);
        await _articleRepository.SaveChangesAsync();

        return result.Succeeded(article.Id, $"Article With Title {article.Title} Has Been Created");
    }

    public async Task<OperationResult> Edit(EditArticleCommand command)
    {
        OperationResult result = new();

        _unitOfWork.BeginTransaction();

        var article = await _articleRepository.GetEntityByIdAsync(command.Id);
        var imageName = Uploader.ImageUploader(command.Image!, "articles", article.Image!);

        article.Edit(command.Title!, command.ShortDescription!, command.Description!
            , imageName, command.CategoryId, _articleDomainService);

        _unitOfWork.CommitTransaction();

        return result.Succeeded(article.Id, $"Article With Title {article.Title} Has Been Modified");
    }

    public async Task<List<ArticleListDto>> GetList() => await _articleRepository.GetList();

    public async Task<ArticleDto> GetBy(ulong id) => await _articleRepository.GetBy(id);
    
}