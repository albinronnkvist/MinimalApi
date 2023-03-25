using Microsoft.AspNetCore.Authorization;
using MinimalApi.Data.Repositories;
using MinimalApi.Entities;

namespace MinimalApi.Routes;

// TODO: return DTOs
public static class TodosV1
{
    public static RouteGroupBuilder MapTodosV1(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllTodos);
        group.MapGet("/complete", GetCompleteTodos);
        group.MapGet("/{id}", GetTodo);
        group.MapPost("/", CreateTodo);
        group.MapPut("/{id}", UpdateTodo);
        group.MapDelete("/{id}", DeleteTodo);

        return group;
    }

    public static async Task<IResult> GetAllTodos(ITodoRepository todoRepository)
    {
        return TypedResults.Ok(await todoRepository.GetAllAsync());
    }

    public static async Task<IResult> GetCompleteTodos(ITodoRepository todoRepository)
    {
        return TypedResults.Ok(await todoRepository.FindAsync(t => t.IsComplete));
    }

    public static async Task<IResult> GetTodo(int id, ITodoRepository todoRepository)
    {
        var todo = await todoRepository.GetAsync(id);
        if (todo is null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(todo);
    }

    public static async Task<IResult> CreateTodo(Todo todo, ITodoRepository todoRepository)
    {
        todoRepository.Add(todo);
        await todoRepository.SaveAsync();

        return TypedResults.Created($"/todoitems/{todo.Id}", todo);
    }

    public static async Task<IResult> UpdateTodo(int id, Todo inputTodo, ITodoRepository todoRepository)
    {
        var todo = await todoRepository.GetAsync(id);
        if (todo is null)
        {
            return TypedResults.NotFound();
        }

        todo.Name = inputTodo.Name;
        todo.IsComplete = inputTodo.IsComplete;

        await todoRepository.SaveAsync();

        return TypedResults.NoContent();
    }

    public static async Task<IResult> DeleteTodo(int id, ITodoRepository todoRepository)
    {
        var todo = await todoRepository.GetAsync(id);
        if (todo is null)
        {
            return TypedResults.NotFound();
        }

        todoRepository.Remove(todo);
        await todoRepository.SaveAsync();
        return TypedResults.Ok(todo);
    }
}
