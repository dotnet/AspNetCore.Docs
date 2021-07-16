using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

public class JsInteropClasses3 : IDisposable
{
    private readonly IJSRuntime js;
    private DotNetObjectReference<HelloHelper> objRef;

    public JsInteropClasses3(IJSRuntime js)
    {
        this.js = js;
    }

    public ValueTask<string> CallHelloHelperGetHelloMessage(string name)
    {
        objRef = DotNetObjectReference.Create(new HelloHelper(name));

        return js.InvokeAsync<string>("sayHello1", objRef);
    }

    public void Dispose()
    {
        objRef?.Dispose();
    }
}
