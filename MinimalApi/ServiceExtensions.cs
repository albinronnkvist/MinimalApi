using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Data.Repositories;

namespace MinimalApi;

public static class ServiceExtensions
{
    public static void ConfigureOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigureDataStore(this IServiceCollection services)
    {
        services.AddDbContext<TodoDbContext>(opt => opt.UseInMemoryDatabase("TodoList"));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}
