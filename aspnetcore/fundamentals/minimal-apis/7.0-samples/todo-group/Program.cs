using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add TodoRepository to the container.
builder.Services.AddScoped<ApplicationDbContext>();
// Add NoteRepository to the container.
builder.Services.AddScoped<ApplicationDbContext>();
// Add InMemoryDatabase to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(new SqliteConnection("DataSource=:memory:"));
});

builder.Services.AddSingleton<ApplicationDbContext>(sp =>
{
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
}); ;
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
}); ;
notes.MapPut("/{id}", UpdateNote).AddRouteHandlerFilter((context, next) =>
{
    if (context.HttpContext.Request.ContentLength == 0)
    {
        context.HttpContext.Response.StatusCode = 400;
        return new ValueTask<object?>(Results.BadRequest(new { Message = "Request body is empty" }));
    }
    return next(context);
}); ;
notes.MapDelete("/{id}", DeleteNote);
app.Run();


// get all todos
static async Task<IResult> GetAllTodos(ApplicationDbContext database)
{
    var todos = await database.Todos.ToListAsync();
    return TypedResults.Ok(todos);
}

// get todo by id
static async Task<IResult> GetTodo(int id, ApplicationDbContext database)
{
    var todo = await database.Todos.FindAsync(id);
    if (todo != null)
    {
        return TypedResults.Ok(todo);
    }
    else
    {
        return TypedResults.NotFound();
    }

}

// create todo
static async Task<IResult> CreateTodo(TodoDto todo, ApplicationDbContext database)
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
static async Task<IResult> UpdateTodo(Todo todo, ApplicationDbContext database)
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
static async Task<IResult> DeleteTodo(int id, ApplicationDbContext database)
{
    var todo = await database.Todos.FindAsync(id);
    if (todo != null)
    {
        database.Todos.Remove(todo);
        await database.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    else
    {
        return TypedResults.NotFound();
    }
}

// get all notes
static async Task<IResult> GetAllNotes(ApplicationDbContext database)
{
    var notes = await database.Notes.ToListAsync();
    return TypedResults.Ok(notes);
}


// get note by id
static async Task<IResult> GetNote(int id, ApplicationDbContext database)
{
    var note = await database.Notes.FindAsync(id);
    if (note != null)
    {
        return TypedResults.Ok(note);
    }
    else
    {
        return TypedResults.NotFound();
    }
}

// create note
static async Task<IResult> CreateNote(NoteDto note, ApplicationDbContext database)
{
    var newNote = new Note
    {
        Title = note.Title,
        Description = note.Description
    };
    await database.Notes.AddAsync(newNote);
    await database.SaveChangesAsync();
    return TypedResults.Created($"/public/notes/{newNote.Id}", newNote);
}

// update note
static async Task<IResult> UpdateNote(Note note, ApplicationDbContext database)
{
    var existingNote = await database.Notes.FindAsync(note.Id);
    if (existingNote != null)
    {
        existingNote.Title = note.Title;
        existingNote.Description = note.Description;
        await database.SaveChangesAsync();
        return TypedResults.Created($"/public/notes/{existingNote.Id}", existingNote);
    }

    return TypedResults.NotFound();
}

// delete note
static async Task<IResult> DeleteNote(int id, ApplicationDbContext database)
{
    var note = await database.Notes.FindAsync(id);
    if (note != null)
    {
        database.Notes.Remove(note);
        await database.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    else
    {
        return TypedResults.NotFound();
    }
}
