using Build;
using MiddlewareExtensibilitySample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareExtensibilitySample.Middleware
{
    public class Lazy<T>
    {
        public Lazy(Func<T> func) => Func = func;

        Func<T> Func { get; }

        public T GetInstance() => Func();
    }
}