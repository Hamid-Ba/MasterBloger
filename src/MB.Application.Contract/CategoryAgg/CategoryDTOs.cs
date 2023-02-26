using System;
namespace MB.Application.Contract.CategoryAgg;

public class CategoryListDto
{
    public ulong Id { get; set; }
    public string? Title { get; set; }
    public bool IsDelete { get; set; }
    public string? CreationDate { get; set; }    
}

public class CreateCategoryCommand
{
    public string? Title { get; set; } 
}

public class EditCategoryCommand : CreateCategoryCommand
{
    public ulong Id { get; set; }
}