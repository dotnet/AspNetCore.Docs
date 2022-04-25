using Microsoft.JSInterop;

public class JsInteropClasses1
{
    private readonly IJSRuntime js;

    public JsInteropClasses1(IJSRuntime js)
    {
        this.js = js;
    }

    public async ValueTask TickerChanged(string symbol, decimal price)
    {
        await js.InvokeVoidAsync("displayTickerAlert1", symbol, price);
    }

    public void Dispose()
    {
    }
}
