#region snippet2
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Greet;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        #region snippet
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            // The port number(50051) must match the port of the gRPC server.
            httpClient.BaseAddress = new Uri("https://localhost:50051");
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        #endregion
    }
}
#endregion
