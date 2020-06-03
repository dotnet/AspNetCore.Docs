using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSample.JsInteropClasses
{
    #region snippet1
    public class ExampleJsInterop : IDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<HelloHelper> objRef;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask<string> CallHelloHelperSayHello(string name)
        {
            objRef = DotNetObjectReference.Create(new HelloHelper(name));

            return jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.sayHello",
                objRef);
        }

        public void Dispose()
        {
            objRef?.Dispose();
        }
    }
    #endregion
}
