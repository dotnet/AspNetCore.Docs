using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcGreeter
{
    #region snippet
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(
            HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
    #endregion
}
