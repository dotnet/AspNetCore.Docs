using WebMinRouteGroup.Data;

namespace WebMinRouteGroup;

public static class Utilities
{
    public static Dictionary<string, string[]> IsValid(TodoDto td)
    {
        Dictionary<string, string[]> errors = new();

        if (string.IsNullOrEmpty(td.Title))
        {
            errors.TryAdd("todo.name.errors", new[] { "Name is empty" });
        }

        if (td.Title.Length < 3)
        {
            errors.TryAdd("todo.name.errors", new[] { "Name length < 3" });
        }

        return errors;
    }
}
