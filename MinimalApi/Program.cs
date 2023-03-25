using MinimalApi;
using MinimalApi.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureOpenApi();
builder.Services.ConfigureDataStore();
var app = builder.Build();

app.MapGroup("/todos/v1")
    .MapTodosV1()
    .WithTags("TodosV1");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();