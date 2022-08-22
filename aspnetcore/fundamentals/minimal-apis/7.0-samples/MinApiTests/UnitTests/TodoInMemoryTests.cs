using Microsoft.AspNetCore.Http.HttpResults;
using todo_group;
using todo_group.Data;

namespace MinApiTests.UnitTests
{
    public class TodoInMemoryTests
    {
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
            var notFoundResult = (NotFound)await TodoEndpointsV1.GetTodo(404, context);

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
            var notFoundResult = (NotFound)await TodoEndpointsV1.UpdateTodo(new Todo { Id = 2, Title = "Invalid Title" }, context);

            //Assert
            Assert.Equal(201, createdResult.StatusCode);
            Assert.NotNull(createdResult.Location);
            Assert.IsAssignableFrom<Todo>(createdResult.Value);

            Assert.Equal(404, notFoundResult.StatusCode);

            var todoInDb = await context.Todos.FindAsync(1);

            Assert.NotNull(todoInDb);
            Assert.Equal("Updated test title", todoInDb!.Title);
            Assert.True(todoInDb.IsDone);
        }

        [Fact]
        public async Task DeleteTodoDeletesTodoInDatabase()
        {
            //Arrange
            var existingTodo = new Todo()
            {
                Id = 1,
                Title = "Exiting test title",
                IsDone = false
            };

            await using var context = new MockDb().CreateDbContext();

            context.Todos.Add(existingTodo);

            await context.SaveChangesAsync();

            //Act
            var noContentResult = (NoContent)await TodoEndpointsV1.DeleteTodo(existingTodo.Id, context);
            var notFoundResult = (NotFound)await TodoEndpointsV1.DeleteTodo(2, context);

            //Assert
            Assert.Equal(204, noContentResult.StatusCode);
            Assert.Empty(context.Todos);

            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
