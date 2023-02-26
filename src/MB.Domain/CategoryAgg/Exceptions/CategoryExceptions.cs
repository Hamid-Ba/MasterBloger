using System;
namespace MB.Domain.CategoryAgg.Exceptions;

public class CategoryTitleExistsException : Exception
{
    public CategoryTitleExistsException() { }

    public CategoryTitleExistsException(string? message) : base(message) { }
}