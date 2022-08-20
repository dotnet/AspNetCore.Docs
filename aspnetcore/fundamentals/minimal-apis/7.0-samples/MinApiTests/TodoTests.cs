using todo_group;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinApiTests;

public class TodoTests : IClassFixture<MockTodoDb>
{
    private TodoGroupDbContext _context;

    public TodoTests(MockTodoDb mockTodo)
    {
        _context = mockTodo.CreateDbContext();
    }
    
    [Fact]
    public async Task GetTodoReturnsTodoFromDatabase()
    {
        // Arrange
        var todo = new Todo { Id = 42, Title = "Improve Results testability!", IsDone = false };

        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();

        // Act
        var okResult = (Ok<Todo>) await TodoEndpoints.GetTodo(todo.Id, _context);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundTodo = Assert.IsAssignableFrom<Todo>(okResult.Value);
        Assert.Equal(42, foundTodo.Id);
    }

    [Fact]
    public async Task CreateTodoCreatesTodoInDatabase()
    {
        //Arrange
        var newTodo = new TodoDto
        {
            Title = "Test title",
            Description = "Test description",
            IsDone = false
        };

        //Act
        var createdResult = (Created<Todo>) await TodoEndpoints.CreateTodo(newTodo, _context);

        //Assert        
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);
    }

    [Fact]
    public async Task UpdateTodoUpdatesTodoInDatabase()
    {   
        //Arrange
        var todo = new Todo { Id = 1, Title = "Test title", IsDone = false };

        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();

        _context.ChangeTracker.Clear();

        //Act
        var createdResult = (Created<Todo>) await TodoEndpoints.UpdateTodo(new Todo() { Id = 1, IsDone = true }, _context);
        var notFoundResult = (NotFound) await TodoEndpoints.UpdateTodo(new Todo() { Id = 2 }, _context);

        //Assert        
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);

        Assert.Equal(400, notFoundResult.StatusCode);
    }
}

public class MockTodoDb : IDbContextFactory<TodoGroupDbContext>
{
    public TodoGroupDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TodoGroupDbContext>()
            .UseInMemoryDatabase("TodoUnitTestsDb")
            .Options;

        return new TodoGroupDbContext(options);
    }
}
