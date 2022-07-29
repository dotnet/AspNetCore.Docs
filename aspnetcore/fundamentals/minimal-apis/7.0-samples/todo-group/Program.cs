using Data;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add TodoRepository to the container.
builder.Services.AddScoped<TodosRepo>();
// Add NoteRepository to the container.
builder.Services.AddScoped<NotesRepo>();
// Add InMemoryDatabase to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(new SqliteConnection("DataSource=:memory:"));
});

builder.Services.AddSingleton<ApplicationDbContext>(sp=>{
    var context = sp.GetRequiredService<ApplicationDbContext>();
    context.Database.OpenConnection();
    context.Database.EnsureCreated();
    return context;
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
    if (context.HttpContext.Request.ContentLength == 0)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is too empty" }));
    }
    return next(context);
});
todos.MapPut("/{id}", UpdateTodo).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength == 0)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is too empty" }));
    }
    return next(context);
});;
todos.MapDelete("/{id}", DeleteTodo);

// note endpoints
var notes = app.MapGroup("/notes").WithTags("Note Endpoints");
notes.MapGet("/", GetAllNotes);
notes.MapGet("/{id}", GetNote);
notes.MapPost("/", CreateNote).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength == 0)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is empty" }));
    }
    return next(context);
});;
notes.MapPut("/{id}", UpdateNote).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength == 0)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is empty" }));
    }
    return next(context);
});;
notes.MapDelete("/{id}", DeleteNote);
app.Run();


// get all todos
static async Task<IResult> GetAllTodos(TodosRepo todosRepo)
{
    var data = await todosRepo.GetAllTodos();
    return TypedResults.Ok(data);
}

// get todo by id
static async Task<IResult> GetTodo(int id, TodosRepo todosRepo)
{
    var data = await todosRepo.GetTodo(id);
    if (data != null)
    {
        return TypedResults.Ok(data);
    }
    else
    {
        return TypedResults.NotFound();
    }

}

// create todo
static async Task<IResult> CreateTodo(TodoDto todo, TodosRepo todosRepo)
{
    var data = await todosRepo.CreateTodo(new Todo
    {
        Title = todo.Title,
        Description = todo.Description,
        IsDone = todo.IsDone
    });
    return TypedResults.Created($"/public/todos/{data.Id}", data);
}

// update todo
static async Task<IResult> UpdateTodo(Todo todo, TodosRepo todosRepo)
{

    var data = await todosRepo.UpdateTodo(todo);
    if (data != null)
    {
        return TypedResults.Created($"/public/todos/{data.Id}", data);
    }
    return TypedResults.NotFound();
}

// delete todo
static async Task<IResult> DeleteTodo(int id, TodosRepo todosRepo)
{
    var data = await todosRepo.DeleteTodo(id);
    if (data != null)
    {
        return TypedResults.NoContent();
    }
    return TypedResults.NotFound();
}

// get all notes
static async Task<IResult> GetAllNotes(NotesRepo notesRepo)
{
    var data = await notesRepo.GetAllNotes();
    return TypedResults.Ok(data);
}

// get note by id
static async Task<IResult> GetNote(int id, NotesRepo notesRepo)
{
    var data = await notesRepo.GetNote(id);
    if (data != null)
    {
        return TypedResults.Ok(data);
    }
    else
    {
        return TypedResults.NotFound();
    }
}

// create note
static async Task<IResult> CreateNote(NoteDto note, NotesRepo notesRepo)
{
    var data = await notesRepo.CreateNote(new Note
    {
        Title = note.Title
    });
    return TypedResults.Created($"/public/notes/{data.Id}", data);
}

// update note
static async Task<IResult> UpdateNote(Note note, NotesRepo notesRepo)
{
    var data = await notesRepo.UpdateNote(note);
    if (data != null)
    {
        return TypedResults.Created($"/public/notes/{data.Id}", data);
    }
    return TypedResults.NotFound();
}

// delete note
static async Task<IResult> DeleteNote(int id, NotesRepo notesRepo)
{
    var data = await notesRepo.DeleteNote(id);
    if (data != null)
    {
        return TypedResults.NoContent();
    }
    return TypedResults.NotFound();
}


