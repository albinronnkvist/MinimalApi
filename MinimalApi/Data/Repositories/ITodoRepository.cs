using System.Linq.Expressions;
using MinimalApi.Entities;

namespace MinimalApi.Data.Repositories;

public interface ITodoRepository
{
    ValueTask<Todo?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Todo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Todo>> FindAsync(Expression<Func<Todo, bool>> expression, CancellationToken cancellationToken = default);
    void Add(Todo entity);
    void AddRange(IEnumerable<Todo> entities);
    void Remove(Todo entity);
    void RemoveRange(IEnumerable<Todo> entities);
    Task SaveAsync(CancellationToken cancellationToken = default);
}
