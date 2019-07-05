public class JsInteropClasses
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteropClasses(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public Task<string> TickerChanged(string data)
    {
        // The handleTickerChanged JavaScript method is implemented
        // in a JavaScript file, such as 'wwwroot/tickerJsInterop.js'.
        return _jsRuntime.InvokeAsync<object>(
            "handleTickerChanged",
            stockUpdate.symbol,
            stockUpdate.price);
    }
}
