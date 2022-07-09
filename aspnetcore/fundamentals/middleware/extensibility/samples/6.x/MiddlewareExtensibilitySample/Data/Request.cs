namespace MiddlewareExtensibilitySample.Data;

public class Request
{
    public Request(string activation, string value)
        => (Activation, Value) = (activation, value);

    public Guid Id { get; set; } = new Guid();

    public DateTime DateTime { get; set; } = DateTime.UtcNow;

    public string Activation { get; set; }

    public string Value { get; set; }
}
