using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Create and open an in-memory SQLite connection.
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure TodoGroupDbContext to use the in-memory SQLite connection and register it as a service.
builder.Services.AddDbContext<TodoGroupDbContext>(options =>
{
    options.UseSqlite(connection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // localhost:{port}/swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

// todo endpoints
var todos = app.MapGroup("/todos").WithTags("Todo Endpoints");
todos.MapGet("/", GetAllTodos);
todos.MapGet("/{id}", GetTodo);
todos.MapPost("/", CreateTodo).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength > 80)
    {
        context.HttpContext.Response.StatusCode = 400;
        IDictionary<string, string[]> errors = new Dictionary<string, string[]>()
        {
            { "Error", new[] { "The size of the payload is above 80 characters" } },
        };
        return new ValueTask<object?>(Results.ValidationProblem(errors));
    }
    return next(context);
});
todos.MapPut("/{id}", UpdateTodo).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength > 80)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is too empty" }));
    }
    return next(context);
});
todos.MapDelete("/{id}", DeleteTodo);


app.Run();


// get all todos
static async Task<IResult> GetAllTodos(TodoGroupDbContext database)
{
    var todos = await database.Todos.ToListAsync();
    return TypedResults.Ok(todos);
}

// get todo by id
static async Task<IResult> GetTodo(int id, TodoGroupDbContext database)
{
    var todo = await database.Todos.FindAsync(id);
    if (todo != null)
    {
        return TypedResults.Ok(todo);
    }
    return TypedResults.NotFound();
}

// create todo
static async Task<IResult> CreateTodo(TodoDto todo, TodoGroupDbContext database)
{
    var newTodo = new Todo
    {
        Title = todo.Title,
        Description = todo.Description,
        IsDone = todo.IsDone
    };
    await database.Todos.AddAsync(newTodo);
    await database.SaveChangesAsync();
    return TypedResults.Created($"/public/todos/{newTodo.Id}", newTodo);
}

// update todo
static async Task<IResult> UpdateTodo(Todo todo, TodoGroupDbContext database)
{
    var existingTodo = await database.Todos.FindAsync(todo.Id);
    if (existingTodo != null)
    {
        existingTodo.Title = todo.Title;
        existingTodo.Description = todo.Description;
        existingTodo.IsDone = todo.IsDone;
        await database.SaveChangesAsync();
        return TypedResults.Created($"/public/todos/{existingTodo.Id}", existingTodo);
    }

    return TypedResults.NotFound();
}

// delete todo
static async Task<IResult> DeleteTodo(int id, TodoGroupDbContext database)
{
    var todo = await database.Todos.FindAsync(id);
    if (todo != null)
    {
        database.Todos.Remove(todo);
        await database.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    return TypedResults.NotFound();

}
