public class AppOptions
{
    public Window Window { get; set; }
    public Connection Connection { get; set; }
    public Profile Profile { get; set; }
}

public class Window
{
    public int Height { get; set; }
    public int Width { get; set; }
}

public class Connection
{
    public string Value { get; set; }
}

public class Profile
{
    public string Machine { get; set; }
}
