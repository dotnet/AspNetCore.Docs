using System;
using Microsoft.AspNetCore.Http;
using SimpleInjector;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    {
        private readonly Container _container;

        public SimpleInjectorMiddlewareFactory(Container container)
        {
            _container = container;
        }

        public IMiddleware Created { get; private set; }
        public IMiddleware Released { get; private set; }

        public IMiddleware Create(Type middlewareType)
        {
            Created = _container.GetInstance(middlewareType) as IMiddleware;

            return Created;
        }

        public void Release(IMiddleware middleware)
        {
            Released = middleware;
        }
    }
    #endregion
}
