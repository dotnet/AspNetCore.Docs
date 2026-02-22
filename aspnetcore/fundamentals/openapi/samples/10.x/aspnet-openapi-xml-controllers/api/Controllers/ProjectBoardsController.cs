using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers;

/// <summary>
/// API controller for managing project boards.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Tags("Project Boards")]
public class ProjectBoardsController : ControllerBase
{
    // In-memory storage for demo purposes
    internal static readonly List<ProjectBoard> Boards = new();
    private static int _nextBoardId = 1;

    /// <summary>
    /// Retrieves all project boards.
    /// </summary>
    /// <returns>A collection of all project boards.</returns>
    /// <response code="200">Returns the list of project boards.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProjectBoard>> GetAllProjectBoards()
    {
        return Ok(Boards);
    }

    // <snippet_1>
    /// <summary>
    /// Retrieves a specific project board by ID.
    /// </summary>
    /// <param name="id">The ID of the project board to retrieve.</param>
    /// <returns>The requested project board.</returns>
    /// <response code="200">Returns the requested project board.</response>
    /// <response code="404">If the project board is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProjectBoard> GetProjectBoardById(int id)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return NotFound();
        }
        return Ok(board);
    }
    // </snippet_1>

    /// <summary>
    /// Creates a new project board.
    /// </summary>
    /// <param name="board">The project board to create.</param>
    /// <returns>The newly created project board.</returns>
    /// <response code="201">Returns the newly created project board.</response>
    /// <response code="400">If the project board data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProjectBoard> CreateProjectBoard(ProjectBoard board)
    {
        board.Id = _nextBoardId++;
        board.CreatedAt = DateTime.UtcNow;
        Boards.Add(board);

        return CreatedAtAction(nameof(GetProjectBoardById), new { id = board.Id }, board);
    }

    /// <summary>
    /// Updates an existing project board.
    /// </summary>
    /// <param name="id">The ID of the project board to update.</param>
    /// <param name="updatedBoard">The updated project board data.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the update was successful.</response>
    /// <response code="400">If the project board data is invalid.</response>
    /// <response code="404">If the project board is not found.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateProjectBoard(int id, ProjectBoard updatedBoard)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return NotFound();
        }

        board.Name = updatedBoard.Name;
        board.Description = updatedBoard.Description;

        return NoContent();
    }

    /// <summary>
    /// Deletes a project board.
    /// </summary>
    /// <param name="id">The ID of the project board to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the project board is not found.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteProjectBoard(int id)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return NotFound();
        }

        Boards.Remove(board);
        return NoContent();
    }
}
