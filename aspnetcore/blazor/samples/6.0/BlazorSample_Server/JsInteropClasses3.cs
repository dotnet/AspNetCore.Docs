using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class JsInteropClasses3 : IDisposable
{
    private readonly IJSRuntime js;
    private DotNetObjectReference<HelloHelper>? dotNetHelper;

    public JsInteropClasses3(IJSRuntime js)
    {
        this.js = js;
    }

    public ValueTask<string> CallHelloHelperGetHelloMessage(string? name)
    {
        dotNetHelper = DotNetObjectReference.Create(new HelloHelper(name));

        return js.InvokeAsync<string>("sayHello1", dotNetHelper);
    }

    public void Dispose()
    {
        dotNetHelper?.Dispose();
    }
}
