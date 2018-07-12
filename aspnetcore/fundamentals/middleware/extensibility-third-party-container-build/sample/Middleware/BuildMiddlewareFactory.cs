using System;
using Microsoft.AspNetCore.Http;
using Build;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1

    public class BuildMiddlewareFactory : IMiddlewareFactory
    {
        readonly Container _container;

        public BuildMiddlewareFactory(Container container)
        {
            _container = container;
        }

        public IMiddleware Create(Type middlewareType)
        {
            return _container.GetInstance(middlewareType.ToString()) as IMiddleware;
        }

        public void Release(IMiddleware middleware)
        {
            // The container is responsible for releasing resources.
        }
    }

    #endregion snippet1
}