using Microsoft.EntityFrameworkCore;
using MinimalApi.Entities;

namespace MinimalApi.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
}
