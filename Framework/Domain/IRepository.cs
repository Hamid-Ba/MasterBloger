using System.Linq.Expressions;
using Microsoft.AspNetCore.JsonPatch;

namespace Framework.Domain;

public interface IRepository<TEntity>
{
    // Read ALL
    IEnumerable<TEntity> GetAllEntities();
    Task<IEnumerable<TEntity>> GetAllEntitiesAsync();

    // Read ONE
    TEntity GetEntityById(object id);
    Task<TEntity> GetEntityByIdAsync(object id);

    // Create One&Range
    object AddEntity(TEntity entity);
    void AddRangeOfEntities(IEnumerable<TEntity> entities);
    Task<object> AddEntityAsync(TEntity entity);
    Task AddRangeOfEntitiesAsync(IEnumerable<TEntity> entities);

    // Update One&Range
    bool UpdateEntity(TEntity entity);
    void UpdateRangeOfEntities(IEnumerable<TEntity> entities);

    // Delete One&Range
    bool DeleteEntity(TEntity entity);
    void DeleteRangeOfEntities(IEnumerable<TEntity> entities);

    bool Exists(Expression<Func<TEntity, bool>> expression);
    void SaveChanges();
    Task SaveChangesAsync();

    int GetCountOfEntity();
    IEnumerable<TEntity> PaginationOfEntity(int currentPage, int pageSize);
}