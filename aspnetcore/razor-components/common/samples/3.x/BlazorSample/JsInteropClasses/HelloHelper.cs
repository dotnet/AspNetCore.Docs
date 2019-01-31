using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSample.JsInteropClasses
{
    #region snippet1
    public class HelloHelper
    {
        public HelloHelper(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        [JSInvokable]
        public string SayHello() => $"Hello, {Name}!";
    }
    #endregion
}
