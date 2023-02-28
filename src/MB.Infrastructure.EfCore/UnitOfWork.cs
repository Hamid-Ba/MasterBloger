using System;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore;

public class UnitOfWorkEF : IUnitOfWork
{
    private readonly BlogContext _context;

    public UnitOfWorkEF(BlogContext context) => _context = context;

    public async void BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async void CommitTransaction()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }
}

