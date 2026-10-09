public interface IHelloService
{
    public string HelloMessage { get; }
}

public class HelloService : IHelloService
{
    public string HelloMessage => "Hello World";
}