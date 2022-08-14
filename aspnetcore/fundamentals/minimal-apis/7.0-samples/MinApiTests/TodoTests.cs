using todo_group;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinApiTests;

public class TodoTests
{
    [Fact]
    public async Task GetTodoReturnsTodoFromDatabase()
    {
        var todo = new Todo { Id = 42, Title = "Improve Results testability!" };

        await using var mockDb = new MockTodoDb().CreateDbContext();
        await mockDb.Todos.AddAsync(todo);
        await mockDb.SaveChangesAsync();

        var result = (Ok)await TodoEndpoints.GetTodo(todo.Id, mockDb);
        //Assert
        Assert.Equal(200, result.StatusCode);

        var foundTodo = Assert.IsAssignableFrom<Todo>(result);
        Assert.Equal(42, foundTodo.Id);
    }
}

public class MockTodoDb : IDbContextFactory<TodoGroupDbContext>
{
    public TodoGroupDbContext CreateDbContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<TodoGroupDbContext>()
            .UseSqlite(connection)
            .Options;

        var dbContext = new TodoGroupDbContext(options);
        return dbContext;
    }
}
