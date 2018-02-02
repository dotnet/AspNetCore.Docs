using System;
using Microsoft.AspNetCore.Http;
using MiddlewareExtensibilitySample.Data;

namespace MiddlewareExtensibilitySample.Middleware
{
    #region snippet1
    public class SimpleInjectorMiddlewareFactory : IMiddlewareFactory
    {
        private readonly AppDbContext _db;
        private readonly SimpleInjectorActivatedMiddleware _middleware;

        public SimpleInjectorMiddlewareFactory(AppDbContext db, SimpleInjectorActivatedMiddleware middleware)
        {
            _db = db;
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
