using Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Api;

/// <summary>
/// Extension methods for mapping ProjectBoard-related API endpoints.
/// </summary>
public static class ProjectBoardApis
{
    // In-memory storage for demo purposes
    internal static readonly List<ProjectBoard> Boards = new();
    private static int _nextBoardId = 1;

    /// <summary>
    /// Maps all ProjectBoard related API endpoints to the application.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public static void MapProjectBoardApis(this IEndpointRouteBuilder app)
    {
        var boardGroup = app.MapGroup("/api/projectboards")
            .WithTags("Project Boards")
            .WithOpenApi();

        // Project Board endpoints
        boardGroup.MapGet("/", GetAllProjectBoards);
        boardGroup.MapGet("/{id}", GetProjectBoardById);
        boardGroup.MapPost("/", CreateProjectBoard);
        boardGroup.MapPut("/{id}", UpdateProjectBoard);
        boardGroup.MapDelete("/{id}", DeleteProjectBoard);
    }

    /// <summary>
    /// Retrieves all project boards.
    /// </summary>
    /// <returns>A collection of all project boards.</returns>
    /// <response code="200">Returns the list of project boards.</response>
    public static IResult GetAllProjectBoards()
    {
        return Results.Ok(Boards);
    }

    /// <summary>
    /// Retrieves a specific project board by ID.
    /// </summary>
    /// <param name="id">The ID of the project board to retrieve.</param>
    /// <returns>The requested project board.</returns>
    /// <response code="200">Returns the requested project board.</response>
    /// <response code="404">If the project board is not found.</response>
    public static IResult GetProjectBoardById(int id)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(board);
    }

    /// <summary>
    /// Creates a new project board.
    /// </summary>
    /// <param name="board">The project board to create.</param>
    /// <returns>The newly created project board.</returns>
    /// <response code="201">Returns the newly created project board.</response>
    /// <response code="400">If the project board data is invalid.</response>
    public static IResult CreateProjectBoard(ProjectBoard board)
    {
        board.Id = _nextBoardId++;
        board.CreatedAt = DateTime.UtcNow;
        Boards.Add(board);

        return Results.Created($"/api/projectboards/{board.Id}", board);
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
    public static IResult UpdateProjectBoard(int id, ProjectBoard updatedBoard)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return Results.NotFound();
        }

        board.Name = updatedBoard.Name;
        board.Description = updatedBoard.Description;

        return Results.NoContent();
    }

    /// <summary>
    /// Deletes a project board.
    /// </summary>
    /// <param name="id">The ID of the project board to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the deletion was successful.</response>
    /// <response code="404">If the project board is not found.</response>
    public static IResult DeleteProjectBoard(int id)
    {
        var board = Boards.FirstOrDefault(b => b.Id == id);
        if (board == null)
        {
            return Results.NotFound();
        }

        Boards.Remove(board);
        return Results.NoContent();
    }
}