using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;


public class TodosRepo
{
    private ApplicationDbContext database;

    public TodosRepo(ApplicationDbContext context)
    {
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        database = context;


    }

    // get todo by id
    public async Task<Todo?> GetTodo(int id)
    {

        var todo = await database.Todos.FindAsync(id);
        return todo;
    }

    // get all todos
    public async Task<List<Todo>> GetAllTodos()
    {
        return await database.Todos.ToListAsync();
    }

    // create todo
    public async Task<Todo> CreateTodo(Todo todo)
    {
        await database.Todos.AddAsync(todo);
        await database.SaveChangesAsync();
        return todo;
    }

    // update todo
    public async Task<Todo?> UpdateTodo(Todo todo)
    {
        var data = await database.Todos.FindAsync(todo.Id);
        if (data == null)
        {
            return null;
        }
        data.Description = todo.Description;
        data.Title = todo.Title;
        await database.SaveChangesAsync();

        return data;
    }

    // delete todo
    public async Task<Todo?> DeleteTodo(int id)
    {
        var data = await database.Todos.FindAsync(id);
        if (data == null)
        {
            return null;
        }
        database.Todos.Remove(data);
        await database.SaveChangesAsync();
        return data;
    }
}

class NotesRepo
{
    private ApplicationDbContext database;

    public NotesRepo(ApplicationDbContext context)
    {
        database = context;
    }

    // get note by id
    public async Task<Note?> GetNote(int id)
    {

        var note = await database.Notes.FindAsync(id);
        return note;
    }

    // get all notes
    public async Task<List<Note>> GetAllNotes()
    {
        return await database.Notes.ToListAsync();
    }

    // create note
    public async Task<Note> CreateNote(Note note)
    {
        await database.Notes.AddAsync(note);
        await database.SaveChangesAsync();
        return note;
    }

    // update note
    public async Task<Note?> UpdateNote(Note note)
    {
        var data = await database.Notes.FindAsync(note.Id);
        if (data == null)
        {
            return null;
        }
        data.Title = note.Title;
        await database.SaveChangesAsync();

        return data;
    }

    // delete note
    public async Task<Note?> DeleteNote(int id)
    {
        var data = await database.Notes.FindAsync(id);
        if (data == null)
        {
            return null;
        }
        database.Notes.Remove(data);
        await database.SaveChangesAsync();
        return data;
    }
}
