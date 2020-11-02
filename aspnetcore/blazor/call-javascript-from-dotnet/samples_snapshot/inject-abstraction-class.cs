public class JsInteropClasses
{
    private readonly IJSRuntime js;

    public JsInteropClasses(IJSRuntime js)
    {
        this.js = js;
    }

    public ValueTask<string> TickerChanged(string data)
    {
        return js.InvokeAsync<string>(
            "handleTickerChanged",
            stockUpdate.symbol,
            stockUpdate.price);
    }
}
