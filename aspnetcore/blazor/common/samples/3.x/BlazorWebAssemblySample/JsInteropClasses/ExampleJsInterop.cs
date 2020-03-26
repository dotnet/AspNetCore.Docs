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
        private readonly IJSRuntime _jsRuntime;
        private DotNetObjectReference<HelloHelper> _objRef;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask<string> CallHelloHelperSayHello(string name)
        {
            _objRef = DotNetObjectReference.Create(new HelloHelper(name));

            return _jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.sayHello",
                _objRef);
        }

        public void Dispose()
        {
            _objRef?.Dispose();
        }
    }
    #endregion
}
