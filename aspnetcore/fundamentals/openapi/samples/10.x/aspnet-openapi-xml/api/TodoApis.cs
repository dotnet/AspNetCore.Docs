using Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Api;

/// <summary>
/// Extension methods for mapping Todo-related API endpoints.
/// </summary>
public static class TodoApis
{
    private static int _nextTodoId = 1;
    
    /// <summary>
    /// Maps all ProjectBoard related API endpoints to the application.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public static void MapTodoApis(this IEndpointRouteBuilder app)
    {
        // Todo endpoints
        var todoGroup = app.MapGroup("/api/projectboards/{boardId}/todos")
            .WithTags("Todos");

        todoGroup.MapGet("/", GetAllTodos);
        todoGroup.MapGet("/{id}", GetTodoById);
        todoGroup.MapPost("/", CreateTodo);
        todoGroup.MapPut("/{id}", UpdateTodo);
        todoGroup.MapDelete("/{id}", DeleteTodo);
    }

    /// <summary>
    /// Retrieves all todos for a specific project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <returns>A collection of todos for the specified project board.</returns>
    /// <response code="200">Returns the list of todos.</response>
    /// <response code="404">If the project board is not found.</response>
    public static IResult GetAllTodos(int boardId)
    {
        var board = ProjectBoardApis.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return Results.NotFound("Project board not found");
        }

        return Results.Ok(board.Todos);
    }

    /// <summary>
    /// Retrieves a specific todo by ID within a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="id">The ID of the todo to retrieve.</param>
    /// <returns>The requested todo.</returns>
    /// <response code="200">Returns the requested todo.</response>
    /// <response code="404">If the project board or todo is not found.</response>
    public static IResult GetTodoById(int boardId, int id)
    {
        var board = ProjectBoardApis.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return Results.NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return Results.NotFound("Todo not found");
        }

        return Results.Ok(todo);
    }

    /// <summary>
    /// Creates a new todo within a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="todo">The todo to create.</param>
    /// <returns>The newly created todo.</returns>
    /// <response code="201">Returns the newly created todo.</response>
    /// <response code="400">If the todo data is invalid.</response>
    /// <response code="404">If the project board is not found.</response>
    public static IResult CreateTodo(int boardId, Todo todo)
    {
        var board = ProjectBoardApis.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return Results.NotFound("Project board not found");
        }

        todo.Id = _nextTodoId++;
        todo.ProjectBoardId = boardId;
        todo.CreatedAt = DateTime.UtcNow;
        
        board.Todos.Add(todo);

        return Results.Created($"/api/projectboards/{boardId}/todos/{todo.Id}", todo);
    }

    /// <summary>
    /// Updates an existing todo within a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="id">The ID of the todo to update.</param>
    /// <param name="updatedTodo">The updated todo data.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the todo data is invalid.</response>
    /// <response code="404">If the project board or todo is not found.</response>
    public static IResult UpdateTodo(int boardId, int id, Todo updatedTodo)
    {
        var board = ProjectBoardApis.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return Results.NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return Results.NotFound("Todo not found");
        }

        todo.Title = updatedTodo.Title;
        todo.Description = updatedTodo.Description;
        todo.IsComplete = updatedTodo.IsComplete;
        todo.Priority = updatedTodo.Priority;
        todo.DueDate = updatedTodo.DueDate;

        return Results.NoContent();
    }

    /// <summary>
    /// Deletes a todo from a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="id">The ID of the todo to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the project board or todo is not found.</response>
    public static IResult DeleteTodo(int boardId, int id)
    {
        var board = ProjectBoardApis.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return Results.NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return Results.NotFound("Todo not found");
        }

        board.Todos.Remove(todo);
        return Results.NoContent();
    }
}