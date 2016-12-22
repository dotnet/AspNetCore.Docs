public abstract class Shape
{
    public bool HasBorder { get; set; }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Circle : Shape
{
    public Point Center { get; set; }
    public int Radius { get; set; }

    public override string ToString()
    {
        return "{" + Center.X + "," + Center.Y + "," + Radius + "}";
    }
}

public class Polygon : Shape
{
    public IList<Point> Vertexes { get; set; }
    public Polygon()
    {
        Vertexes = new List<Point>();
    }
}