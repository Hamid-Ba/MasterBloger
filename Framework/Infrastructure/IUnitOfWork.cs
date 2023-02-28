using System;
namespace Framework.Infrastructure;

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitTransaction();
}