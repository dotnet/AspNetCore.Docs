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
        public static Task<string> Prompt(string text)
        {
            // showPrompt is implemented in wwwroot/exampleJsInterop.js
            return JSRuntime.Current.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                text);
        }

        public static Task<string> Display(string welcomeMessage)
        {
            // displayWelcome is implemented in wwwroot/exampleJsInterop.js
            return JSRuntime.Current.InvokeAsync<string>(
                "exampleJsFunctions.displayWelcome",
                welcomeMessage);
        }
        
        public static Task CallHelloHelperSayHello(string name)
        {
            // sayHello is implemented in wwwroot/exampleJsInterop.js
            return JSRuntime.Current.InvokeAsync<object>(
                "exampleJsFunctions.sayHello",
                new DotNetObjectRef(new HelloHelper(name)));
        }
    }
    #endregion
}
