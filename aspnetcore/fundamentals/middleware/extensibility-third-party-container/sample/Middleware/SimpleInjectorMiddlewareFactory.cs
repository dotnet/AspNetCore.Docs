using System;
using Microsoft.AspNetCore.Http;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    {
        private readonly SimpleInjectorActivatedMiddleware _middleware;

        public SimpleInjectorMiddlewareFactory(SimpleInjectorActivatedMiddleware middleware)
        {
            _middleware = middleware;
        }

        public IMiddleware Created { get; private set; }
        public IMiddleware Released { get; private set; }

        public IMiddleware Create(Type middlewareType)
        {
            Created = _middleware;

            return Created;
        }

        public void Release(IMiddleware middleware)
        {
            Released = middleware;
        }
    }
    #endregion
}
