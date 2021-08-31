using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorServerSample.JsInteropClasses
{
    #region snippet1
    public class ExampleJsInterop : IDisposable
    {
        private readonly IJSRuntime js;
        private DotNetObjectReference<HelloHelper> objRef;

        public ExampleJsInterop(IJSRuntime js)
        {
            this.js = js;
        }

        public ValueTask<string> CallHelloHelperSayHello(string name)
        {
            objRef = DotNetObjectReference.Create(new HelloHelper(name));

            return js.InvokeAsync<string>(
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
