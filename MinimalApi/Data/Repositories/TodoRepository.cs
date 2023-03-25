using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Entities;

namespace MinimalApi.Data.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Todo?> GetAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext.Todos.FindAsync(id);

    public async Task<IEnumerable<Todo>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.Todos.ToListAsync(cancellationToken);

    public async Task<IEnumerable<Todo>> FindAsync(Expression<Func<Todo, bool>> expression,
        CancellationToken cancellationToken = default) =>
        await _dbContext.Todos.Where(expression).ToListAsync(cancellationToken);

    public void Add(Todo entity) =>
        _dbContext.Todos.Add(entity);

    public void AddRange(IEnumerable<Todo> entities) =>
        _dbContext.Todos.AddRange(entities);

    public void Remove(Todo entity) =>
        _dbContext.Todos.Remove(entity);

    public void RemoveRange(IEnumerable<Todo> entities) =>
        _dbContext.Todos.RemoveRange(entities);

    public async Task SaveAsync(CancellationToken cancellationToken = default) =>
        await _dbContext.SaveChangesAsync(cancellationToken);

}
