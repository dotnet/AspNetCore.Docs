using ProtoBuf.Grpc;
using Shared.Contracts;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class GreeterService : IGreeterService
    {
        public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(
                   new HelloReply
                   {
                       Message = $"Hello {request.Name}"
                   });
        }
    }
}