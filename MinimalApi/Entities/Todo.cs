using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Entities;

public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
