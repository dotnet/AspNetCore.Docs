using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace GrpcGreeterClient
{
    class Program
    {
        #region snippet
        static async Task Main(string[] args)
        {
            var channel = new Channel("localhost:5001", ChannelCredentials.Insecure, new[]{
                  new ChannelOption(ChannelOptions.MaxSendMessageLength , 2*1024*1024),
                  new ChannelOption(ChannelOptions.MaxReceiveMessageLength , 5 *1024*1024)
            });
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        #endregion
    }
}
