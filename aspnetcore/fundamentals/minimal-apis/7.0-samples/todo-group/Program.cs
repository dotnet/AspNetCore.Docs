using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Repository;
using Data;
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
    options.UseInMemoryDatabase("InMemoryDb");
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
app.MapGroup("/public/todos").MapTodosApi();
app.MapGroup("/public/notes").MapNotesApi();
app.Run();


public static class Actions
{

    public static GroupRouteBuilder MapTodosApi(this GroupRouteBuilder group)
    {
        group.MapGet("/", GetAllTodos);
        group.MapGet("/{id}", GetTodo);
        group.MapPost("/", CreateTodo);
        group.MapPut("/{id}", UpdateTodo);
        group.MapDelete("/{id}", DeleteTodo);
        return group;
    }

    public static GroupRouteBuilder MapNotesApi(this GroupRouteBuilder group)
    {
        group.MapGet("/", GetAllNotes);
        group.MapGet("/{id}", GetNote);
        group.MapPost("/", CreateNote);
        group.MapPut("/{id}", UpdateNote);
        group.MapDelete("/{id}", DeleteNote);
        return group;
    }

    // get all todos
    private static async Task<IResult> GetAllTodos(TodosRepo todosRepo)
    {
        var data = await todosRepo.GetAllTodos();
        return TypedResults.Ok(data);
    }

    // get todo by id
    private static async Task<IResult> GetTodo(int id, TodosRepo todosRepo)
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
    private static async Task<IResult> CreateTodo(TodoDto todo, TodosRepo todosRepo)
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
    private static async Task<IResult> UpdateTodo(Todo todo, TodosRepo todosRepo)
    {

        var data = await todosRepo.UpdateTodo(todo);
        if (data != null)
        {
            return TypedResults.Created($"/public/todos/{data.Id}", data);
        }
        return TypedResults.NotFound();
    }

    // delete todo
    private static async Task<IResult> DeleteTodo(int id, TodosRepo todosRepo)
    {
        var data = await todosRepo.DeleteTodo(id);
        if (data != null)
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }

    // get all notes
    private static async Task<IResult> GetAllNotes(NotesRepo notesRepo)
    {
        var data = await notesRepo.GetAllNotes();
        return TypedResults.Ok(data);
    }

    // get note by id
    private static async Task<IResult> GetNote(int id, NotesRepo notesRepo)
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
    private static async Task<IResult> CreateNote(NoteDto note, NotesRepo notesRepo)
    {
        var data = await notesRepo.CreateNote(new Note
        {
            Title = note.Title
        });
        return TypedResults.Created($"/public/notes/{data.Id}", data);
    }

    // update note
    private static async Task<IResult> UpdateNote(Note note, NotesRepo notesRepo)
    {
        var data = await notesRepo.UpdateNote(note);
        if (data != null)
        {
            return TypedResults.Created($"/public/notes/{data.Id}", data);
        }
        return TypedResults.NotFound();
    }

    // delete note
    private static async Task<IResult> DeleteNote(int id, NotesRepo notesRepo)
    {
        var data = await notesRepo.DeleteNote(id);
        if (data != null)
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }
}


