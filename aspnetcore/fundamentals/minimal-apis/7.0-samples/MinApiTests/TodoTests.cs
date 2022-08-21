using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using todo_group;
using todo_group.Data;
using todo_group.Services;

namespace MinApiTests;

public class TodoTests
{
    [Fact]
    public async Task GetTodoReturnsTodoFromDatabase()
    {
        // Arrange
        var mock = new Mock<ITodoService>();

        mock.Setup(m => m.Find(It.Is<int>(id => id == 1)))
            .ReturnsAsync(new Todo
            {
                Id = 1,
                Title = "Test title",
                IsDone = false
            });

        mock.Setup(m => m.Find(It.Is<int>(id => id == 2)))
            .ReturnsAsync((Todo?)null);

        // Act
        var okResult = (Ok<Todo>)await TodoEndpoints.GetTodo(1, mock.Object);
        var notFoundResult = (NotFound)await TodoEndpoints.GetTodo(404, mock.Object);

        //Assert
        Assert.Equal(200, okResult.StatusCode);
        var foundTodo = Assert.IsAssignableFrom<Todo>(okResult.Value);
        Assert.Equal(1, foundTodo.Id);

        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task CreateTodoCreatesTodoInDatabase()
    {
        //Arrange
        var todos = new List<Todo>();

        var newTodo = new TodoDto
        {
            Title = "Test title",
            Description = "Test description",
            IsDone = false
        };

        var mock = new Mock<ITodoService>();

        mock.Setup(m => m.Add(It.Is<Todo>(t => t.Title == newTodo.Title && t.Description == newTodo.Description && t.IsDone == newTodo.IsDone)))
            .Callback<Todo>(todo => todos.Add(todo))
            .Returns(Task.CompletedTask);

        //Act
        var createdResult = (Created<Todo>)await TodoEndpoints.CreateTodo(newTodo, mock.Object);

        //Assert
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);

        Assert.NotEmpty(todos);
        Assert.Collection(todos, todo =>
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
        var existingTodo = new Todo
        {
            Id = 1,
            Title = "Exiting test title",
            IsDone = false
        };

        var updatedTodo = new Todo
        {
            Id = 1,
            Title = "Updated test title",
            IsDone = true
        };

        var mock = new Mock<ITodoService>();

        mock.Setup(m => m.Find(It.Is<int>(id => id == 1)))
            .ReturnsAsync(existingTodo);

        mock.Setup(m => m.Find(It.Is<int>(id => id == 2)))
            .ReturnsAsync((Todo?)null);

        mock.Setup(m => m.Update(It.Is<Todo>(t => t.Id == updatedTodo.Id && t.Description == updatedTodo.Description && t.IsDone == updatedTodo.IsDone)))
            .Callback<Todo>((todo) => existingTodo = todo)
            .Returns(Task.CompletedTask);

        //Act
        var createdResult = (Created<Todo>)await TodoEndpoints.UpdateTodo(updatedTodo, mock.Object);
        var notFoundResult = (NotFound)await TodoEndpoints.UpdateTodo(new Todo { Id = 2, Title = "Invalid Title" }, mock.Object);

        //Assert
        Assert.Equal(201, createdResult.StatusCode);
        Assert.NotNull(createdResult.Location);
        Assert.IsAssignableFrom<Todo>(createdResult.Value);

        Assert.Equal("Updated test title", existingTodo.Title);
        Assert.True(existingTodo.IsDone);

        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task DeleteTodoDeletesTodoInDatabase()
    {
        //Arrange
        var existingTodo = new Todo
        {
            Id = 1,
            Title = "Test title 1",
            IsDone = false
        };

        var todos = new List<Todo> { existingTodo };

        var mock = new Mock<ITodoService>();

        mock.Setup(m => m.Find(It.Is<int>(id => id == existingTodo.Id)))
            .ReturnsAsync(existingTodo);

        mock.Setup(m => m.Find(It.Is<int>(id => id == 2)))
            .ReturnsAsync((Todo?)null);

        mock.Setup(m => m.Remove(It.Is<Todo>(t => t.Id == 1)))
            .Callback<Todo>(t => todos.Remove(t))
            .Returns(Task.CompletedTask);

        //Act
        var noContentResult = (NoContent)await TodoEndpoints.DeleteTodo(existingTodo.Id, mock.Object);
        var notFoundResult = (NotFound)await TodoEndpoints.DeleteTodo(2, mock.Object);

        //Assert
        Assert.Equal(204, noContentResult.StatusCode);
        Assert.Empty(todos);

        Assert.Equal(404, notFoundResult.StatusCode);
    }
}
