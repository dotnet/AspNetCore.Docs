//#define ServerCallContext_ONLY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcGreeter
{
#if ServerCallContext_ONLY
    #region snippet
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply>
            SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
    #endregion
#else
    #region snippet1
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply>
            SayHello(HelloRequest request, ServerCallContext context)
        {
            var httpContext = context.GetHttpContext();

            return Task.FromResult(new HelloReply
            {
                Message = "Using https: " + httpContext.Request.IsHttps
            });
        }
    }
    #endregion
#endif
}
