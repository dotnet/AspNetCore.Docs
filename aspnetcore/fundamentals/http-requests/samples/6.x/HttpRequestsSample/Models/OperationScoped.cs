namespace HttpRequestsSample.Models;

// <snippet_Types>
public interface IOperationScoped
{
    string OperationId { get; }
}

public class OperationScoped : IOperationScoped
{
    public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
}
// </snippet_Types>
