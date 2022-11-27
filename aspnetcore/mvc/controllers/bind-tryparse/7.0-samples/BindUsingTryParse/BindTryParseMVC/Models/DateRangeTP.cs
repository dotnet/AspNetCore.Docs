namespace BindTryParseMVC.Models;

// <snippet>
public class DateRangeTP
{
    public DateOnly? From { get; }
    public DateOnly? To { get; }

    public DateRangeTP(string from, string to)
    {
        if (string.IsNullOrEmpty(from))
            throw new ArgumentNullException(nameof(from));
        if (string.IsNullOrEmpty(to))
            throw new ArgumentNullException(nameof(to));

        From = DateOnly.Parse(from);
        To = DateOnly.Parse(to);
    }

    public static bool TryParse(string? value, out DateRangeTP? result)
    {
        var range = value?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (range?.Length != 2)
        {
            result = default;
            return false;
        }

        result = new DateRangeTP(range[0], range[1]);
        return true;
    }
}
// </snippet>
