public class JsInteropClasses
{
    private readonly IJSRuntime jsRuntime;

    public JsInteropClasses(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime;
    }

    public ValueTask<string> TickerChanged(string data)
    {
        return jsRuntime.InvokeAsync<string>(
            "handleTickerChanged",
            stockUpdate.symbol,
            stockUpdate.price);
    }
}
