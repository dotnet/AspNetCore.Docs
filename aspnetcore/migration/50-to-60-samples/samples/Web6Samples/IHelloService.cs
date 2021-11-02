public interface IHelloService
{
    public string? HelloMessage {  get; set; }
}

public class HelloService : IHelloService
{
    public string? HelloMessage { get; set; } = "Hello World";
}