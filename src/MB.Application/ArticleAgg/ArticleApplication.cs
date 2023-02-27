using System;
using Framework.Application;
using MB.Application.Contract.ArticleAgg;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.DomainService;

namespace MB.Application.ArticleAgg;

public class ArticleApplication : IArticleApplication
{
    private readonly IArticleRepository _articleRepository;
    private readonly IArticleDomainService _articleDomainService;

    public ArticleApplication(IArticleRepository articleRepository,
        IArticleDomainService articleDomainService)
    {
        _articleRepository = articleRepository;
        _articleDomainService = articleDomainService;
    }

    public async Task<OperationResult> Active(ulong id)
    {
        OperationResult result = new();

        var article = await _articleRepository.GetEntityByIdAsync(id);
        article.Active();
        await _articleRepository.SaveChangesAsync();

        return result.Succeeded("Article Has Been Activated");
    }

    public async Task<OperationResult> DeActive(ulong id)
    {
        OperationResult result = new();

        var article = await _articleRepository.GetEntityByIdAsync(id);
        article.Deactive();
        await _articleRepository.SaveChangesAsync();

        return result.Succeeded("Article Has Been Deactiveted");
    }

    public async Task<OperationResult> Create(CreateArticleCommand command)
    {
        OperationResult result = new();

        var imageName = Uploader.ImageUploader(command.Image!, "articles", null!);

        var article = new Article(command.Title!, command.ShortDescription!, command.Description!
            , imageName, command.CategoryId, _articleDomainService);
        await _articleRepository.AddEntityAsync(article);
        await _articleRepository.SaveChangesAsync();

        return result.Succeeded($"Article With Title {article.Title} Has Been Created");
    }

    public async Task<OperationResult> Edit(EditArticleCommand command)
    {
        OperationResult result = new();

        var article = await _articleRepository.GetEntityByIdAsync(command.Id);
        var imageName = Uploader.ImageUploader(command.Image!, "articles", article.Image!);

        article.Edit(command.Title!, command.ShortDescription!, command.Description!
            , imageName, command.CategoryId, _articleDomainService);
        await _articleRepository.SaveChangesAsync();

        return result.Succeeded($"Article With Title {article.Title} Has Been Modified");
    }

    public async Task<List<ArticleListDto>> GetList() => await _articleRepository.GetList();
}