namespace Models;

/// <summary>
/// Represents the priority level of a todo item.
/// </summary>
public enum TodoPriority
{
    /// <summary>
    /// Low priority items that can be addressed later.
    /// </summary>
    Low = 0,

    /// <summary>
    /// Medium priority items that should be addressed in a reasonable timeframe.
    /// </summary>
    Medium = 1,

    /// <summary>
    /// High priority items that should be addressed soon.
    /// </summary>
    High = 2,

    /// <summary>
    /// Critical items that require immediate attention.
    /// </summary>
    Critical = 3
}