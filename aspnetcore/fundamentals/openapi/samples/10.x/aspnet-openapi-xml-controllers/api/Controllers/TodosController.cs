using Microsoft.AspNetCore.Mvc;
using Models;
using Api.Controllers;

namespace Api.Controllers;

/// <summary>
/// API controller for managing todos within project boards.
/// </summary>
[ApiController]
[Route("api/projectboards/{boardId}/todos")]
[Tags("Todos")]
public class TodosController : ControllerBase
{
    private static int _nextTodoId = 1;
    
    /// <summary>
    /// Retrieves all todos for a specific project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <returns>A collection of todos for the specified project board.</returns>
    /// <response code="200">Returns the list of todos.</response>
    /// <response code="404">If the project board is not found.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Todo>> GetAllTodos(int boardId)
    {
        var board = ProjectBoardsController.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return NotFound("Project board not found");
        }

        return Ok(board.Todos);
    }

    /// <summary>
    /// Retrieves a specific todo by ID within a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="id">The ID of the todo to retrieve.</param>
    /// <returns>The requested todo.</returns>
    /// <response code="200">Returns the requested todo.</response>
    /// <response code="404">If the project board or todo is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Todo> GetTodoById(int boardId, int id)
    {
        var board = ProjectBoardsController.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound("Todo not found");
        }

        return Ok(todo);
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
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Todo> CreateTodo(int boardId, Todo todo)
    {
        var board = ProjectBoardsController.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return NotFound("Project board not found");
        }

        todo.Id = _nextTodoId++;
        todo.ProjectBoardId = boardId;
        todo.CreatedAt = DateTime.UtcNow;
        
        board.Todos.Add(todo);

        return CreatedAtAction(nameof(GetTodoById), new { boardId, id = todo.Id }, todo);
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
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateTodo(int boardId, int id, Todo updatedTodo)
    {
        var board = ProjectBoardsController.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound("Todo not found");
        }

        todo.Title = updatedTodo.Title;
        todo.Description = updatedTodo.Description;
        todo.IsComplete = updatedTodo.IsComplete;
        todo.Priority = updatedTodo.Priority;
        todo.DueDate = updatedTodo.DueDate;

        return NoContent();
    }

    /// <summary>
    /// Deletes a todo from a project board.
    /// </summary>
    /// <param name="boardId">The ID of the project board.</param>
    /// <param name="id">The ID of the todo to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the project board or todo is not found.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTodo(int boardId, int id)
    {
        var board = ProjectBoardsController.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board == null)
        {
            return NotFound("Project board not found");
        }

        var todo = board.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound("Todo not found");
        }

        board.Todos.Remove(todo);
        return NoContent();
    }
}
