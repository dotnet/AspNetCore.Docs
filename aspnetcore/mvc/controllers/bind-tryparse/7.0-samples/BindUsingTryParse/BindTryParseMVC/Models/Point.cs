namespace BindTryParseMVC.Models;
/*
public class Point : IParseable<Point>
{
    public double X { get; set; }

    public double Y { get; set; }

    public override string ToString() => $"({X},{Y})";

    public static Point Parse(string value, IFormatProvider? provider)
    {
        if (!TryParse(value, provider, out var result) || result is null)
        {
            throw new ArgumentException("Could not parse supplied value.", nameof(value));
        }

        return result;
    }

    public static bool TryParse(string? value, IFormatProvider? provider, out Point point)
    {
        // Format is "(12.3,10.1)"
        var trimmedValue = value?.TrimStart('(').TrimEnd(')');
        var segments = trimmedValue?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (segments?.Length == 2
            && double.TryParse(segments[0], out var x)
            && double.TryParse(segments[1], out var y))
        {
            point = new Point { X = x, Y = y };
            return true;
        }

        point = new Point();
        return false;
    }
}
*/
