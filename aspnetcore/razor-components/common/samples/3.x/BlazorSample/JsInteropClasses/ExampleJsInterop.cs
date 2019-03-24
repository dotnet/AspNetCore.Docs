using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSample.JsInteropClasses
{
    #region snippet1
    public class ExampleJsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public Task<string> Prompt(string text)
        {
            // showPrompt is implemented in wwwroot/exampleJsInterop.js
            return _jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                text);
        }

        public Task<string> Display(string welcomeMessage)
        {
            // displayWelcome is implemented in wwwroot/exampleJsInterop.js
            return _jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.displayWelcome",
                welcomeMessage);
        }
        
        public Task CallHelloHelperSayHello(string name)
        {
            // sayHello is implemented in wwwroot/exampleJsInterop.js
            return _jsRuntime.InvokeAsync<object>(
                "exampleJsFunctions.sayHello",
                new DotNetObjectRef(new HelloHelper(name)));
        }
    }
    #endregion
}
