using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace MB.Application.Contract.ArticleAgg;

public class ArticleListDto
{
    public ulong Id { get; set; }
    public string? Title { get;  set; }
    public string? Image { get; set; }
    public string? ShortDescription { get;  set; }
    public string? CategoryTitle { get;  set; }
    public bool IsDelete { get; set; }
    public string? CreationDate { get; set; }
}

public class ArticleDto
{
    public ulong Id { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? CategoryTitle { get; set; }
    public bool IsDelete { get; set; }
    public string? CreationDate { get; set; }
}

public class CreateArticleCommand
{
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public IFormFile? Image { get; set; }
    public ulong CategoryId { get; set; }
}

public class EditArticleCommand : CreateArticleCommand
{
    public ulong Id { get; set; }
    public string? ImageName { get; set; }
}