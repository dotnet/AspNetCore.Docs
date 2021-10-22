using Microsoft.JSInterop;

public class HelloHelper
{
    public HelloHelper(string? name)
    {
        Name = name ?? "No Name";
    }

    public string? Name { get; set; }

    [JSInvokable]
    public string GetHelloMessage() => $"Hello, {Name}!";
}
