#define SECOND // FIRST SECOND
#if NEVER
#elif FIRST
// <snippet_1>
var app = WebApplication.Create();

var todos = app.MapGroup("/todos")
    .ProducesProblem(StatusCodes.Status500InternalServerError);

todos.MapGet("/", () => new Todo(1, "Create sample app", false));
todos.MapPost("/", (Todo todo) => Results.Ok(todo));

app.Run();

record Todo(int Id, string Title, bool IsCompleted);
// </snippet_1>
#elif SECOND
// <snippet_2>
var app = WebApplication.Create();

app.MapGet("/", () =>
{
    var extensions = new List<KeyValuePair<string, object?>> { new("test", "value") };
    return TypedResults.Problem("This is an error with extensions",
                                                       extensions: extensions);
});
// </snippet_2>
#endif
