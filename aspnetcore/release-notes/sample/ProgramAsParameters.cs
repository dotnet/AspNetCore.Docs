using System.Text.Json.Serialization;
using MyFirstAotWebApi;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapPost("/todos", ([AsParameters] CreateTodoArgs payload) =>
{
    if (payload.TodoToCreate is not null)
    {
        return payload.TodoToCreate;
    }
    return new Todo(0, "New todo", DateTime.Now, false);
});

app.Run();

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}

record CreateTodoArgs(int ProjectId, Todo? TodoToCreate);
record Todo(int Id, string Name, DateTime CreatedAt, bool IsCompleted);