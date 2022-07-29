using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;


public class TodosRepo
{
    private ApplicationDbContext _context;

    public TodosRepo(ApplicationDbContext context)
    {
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        _context = context;


    }

    // get todo by id
    public async Task<Todo?> GetTodo(int id)
    {

        var todo = await _context.Todos.FindAsync(id);
        return todo;
    }

    // get all todos
    public async Task<List<Todo>> GetAllTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    // create todo
    public async Task<Todo> CreateTodo(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    // update todo
    public async Task<Todo?> UpdateTodo(Todo todo)
    {
        var data = await _context.Todos.FindAsync(todo.Id);
        if (data == null)
        {
            return null;
        }
        data.Description = todo.Description;
        data.Title = todo.Title;
        await _context.SaveChangesAsync();

        return data;
    }

    // delete todo
    public async Task<Todo?> DeleteTodo(int id)
    {
        var data = await _context.Todos.FindAsync(id);
        if (data == null)
        {
            return null;
        }
        _context.Todos.Remove(data);
        await _context.SaveChangesAsync();
        return data;
    }
}

class NotesRepo
{
    private ApplicationDbContext _context;

    public NotesRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    // get note by id
    public async Task<Note?> GetNote(int id)
    {

        var note = await _context.Notes.FindAsync(id);
        return note;
    }

    // get all notes
    public async Task<List<Note>> GetAllNotes()
    {
        return await _context.Notes.ToListAsync();
    }

    // create note
    public async Task<Note> CreateNote(Note note)
    {
        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();
        return note;
    }

    // update note
    public async Task<Note?> UpdateNote(Note note)
    {
        var data = await _context.Notes.FindAsync(note.Id);
        if (data == null)
        {
            return null;
        }
        data.Title = note.Title;
        await _context.SaveChangesAsync();

        return data;
    }

    // delete note
    public async Task<Note?> DeleteNote(int id)
    {
        var data = await _context.Notes.FindAsync(id);
        if (data == null)
        {
            return null;
        }
        _context.Notes.Remove(data);
        await _context.SaveChangesAsync();
        return data;
    }
}
