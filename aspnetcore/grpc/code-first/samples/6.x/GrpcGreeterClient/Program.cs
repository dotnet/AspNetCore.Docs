using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Shared.Contracts;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            #region snippet
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = channel.CreateGrpcService<IGreeterService>();

            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine($"Greeting: {reply.Message}");
            #endregion
        }
    }
}
