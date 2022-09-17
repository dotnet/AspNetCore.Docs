using Microsoft.AspNetCore.Http.HttpResults;
using MinApiTests.UnitTests.Helpers;
using WebMinRouteGroup;
using WebMinRouteGroup.Data;

namespace MinApiTests.UnitTests;

public class TodoInMemoryTests
{
    [Fact]
    public async Task GetTodoReturnsNotFoundIfNotExists()
    {
        // Arrange
        await using var context = new MockDb().CreateDbContext();

        // Act
        var notFoundResult = (NotFound)await TodoEndpointsV1.GetTodo(404, context);

        //Assert
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task GetAllReturnsTodosFromDatabase()
    {
        // Arrange
        await using var context = new MockDb().CreateDbContext();

        context.Todos.Add(new Todo
        {
            Id = 1,
            Title = "Test title 1",
            Description = "Test description 1",
            IsDone = false
        });

        context.Todos.Add(new Todo
        {
            Id = 2,
            Title = "Test title 2",
            Description = "Test description 2",
            IsDone = true
        });

        await context.SaveChangesAsync();

        // Act
        var okResult = (Ok<List<Todo>>)await TodoEndpointsV1.GetAllTodos(context);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundTodos = Assert.IsAssignableFrom<List<Todo>>(okResult.Value);

        Assert.NotEmpty(foundTodos);
        Assert.Collection(foundTodos, todo1 =>
        {
            Assert.Equal("Test title 1", todo1.Title);
            Assert.Equal("Test description 1", todo1.Description);
            Assert.False(todo1.IsDone);
        }, todo2 =>
        {
            Assert.Equal("Test title 2", todo2.Title);
            Assert.Equal("Test description 2", todo2.Description);
            Assert.True(todo2.IsDone);
        });
    }

    [Fact]
    public async Task GetTodoReturnsTodoFromDatabase()
    {
        // Arrange
        await using var context = new MockDb().CreateDbContext();

        context.Todos.Add(new Todo
        {
            Id = 1,
            Title = "Test title",
            Description = "Test description",
            IsDone = false
        });

        await context.SaveChangesAsync();

        // Act
        var okResult = (Ok<Todo>)await TodoEndpointsV1.GetTodo(1, context);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundTodo = Assert.IsAssignableFrom<Todo>(okResult.Value);
        Assert.Equal(1, foundTodo.Id);
    }

    [Fact]
    public async Task CreateTodoCreatesTodoInDatabase()
    {
        //Arrange
        await using var context = new MockDb().CreateDbContext();

        var newTodo = new TodoDto
        {
            Title = "Test title",
            Description = "Test description",
            IsDone = false
        };

        //Act
        var createdResult = (Created<Todo>)await TodoEndpointsV1.CreateTodo(newTodo, context);

        //Assert
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);

        Assert.NotEmpty(context.Todos);
        Assert.Collection(context.Todos, todo =>
        {
            Assert.Equal("Test title", todo.Title);
            Assert.Equal("Test description", todo.Description);
            Assert.False(todo.IsDone);
        });
    }

    [Fact]
    public async Task UpdateTodoUpdatesTodoInDatabase()
    {
        //Arrange
        await using var context = new MockDb().CreateDbContext();

        context.Todos.Add(new Todo
        {
            Id = 1,
            Title = "Exiting test title",
            IsDone = false
        });

        await context.SaveChangesAsync();

        var updatedTodo = new Todo
        {
            Id = 1,
            Title = "Updated test title",
            IsDone = true
        };

        //Act
        var createdResult = (Created<Todo>)await TodoEndpointsV1.UpdateTodo(updatedTodo, context);

        //Assert
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);

        var todoInDb = await context.Todos.FindAsync(1);

        Assert.NotNull(todoInDb);
        Assert.Equal("Updated test title", todoInDb!.Title);
        Assert.True(todoInDb.IsDone);
    }

    [Fact]
    public async Task DeleteTodoDeletesTodoInDatabase()
    {
        //Arrange
        await using var context = new MockDb().CreateDbContext();

        var existingTodo = new Todo
        {
            Id = 1,
            Title = "Exiting test title",
            IsDone = false
        };

        context.Todos.Add(existingTodo);

        await context.SaveChangesAsync();

        //Act
        var noContentResult = (NoContent)await TodoEndpointsV1.DeleteTodo(existingTodo.Id, context);

        //Assert
        Assert.Equal(204, noContentResult.StatusCode);
        Assert.Empty(context.Todos);
    }
}
