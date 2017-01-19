public class Window
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Shape Shape { get; set; }
}

public abstract class Shape
{
    public bool HasBorder { get; set; }
    public Color Color { get; set; }
}

public class Rectangle : Shape
{
    public Point P1 { get; set; }
    public Point P2 { get; set; }
    public Point P3 { get; set; }
}

public class RoundRectangle : Rectangle
{
    public double Round { get; set; }
}

public class Triangle : Shape
{
    public Point LeftTop { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}

public class Circle : Shape
{
    public Point Center { get; set; }
    public int Radius { get; set; }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public enum Color
{
    Red,
    Blue,
    Green,
    Yellow
}