namespace Models;

/// <summary>
/// Represents a todo item within a project board.
/// </summary>
public class Todo
{
    /// <summary>
    /// Unique identifier for the todo item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The title or brief description of the todo.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// A detailed description of the todo item.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether the todo has been completed.
    /// </summary>
    public bool IsComplete { get; set; }

    /// <summary>
    /// The priority level of the todo item.
    /// </summary>
    public TodoPriority Priority { get; set; } = TodoPriority.Medium;

    /// <summary>
    /// The date when the todo was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The date when the todo is due to be completed.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// The ID of the project board this todo belongs to.
    /// </summary>
    public int ProjectBoardId { get; set; }
}