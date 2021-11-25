namespace HandleErrorsSample.Snippets;

// <snippet_Class>
public class HttpResponseException : Exception
{
    public HttpResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

    public int StatusCode { get; }

    public object? Value { get; }
}
// </snippet_Class>
