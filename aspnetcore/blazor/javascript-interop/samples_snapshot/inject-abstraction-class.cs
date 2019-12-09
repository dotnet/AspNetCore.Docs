public class JsInteropClasses
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteropClasses(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask<string> TickerChanged(string data)
    {
        return _jsRuntime.InvokeAsync<string>(
            "handleTickerChanged",
            stockUpdate.symbol,
            stockUpdate.price);
    }
}
