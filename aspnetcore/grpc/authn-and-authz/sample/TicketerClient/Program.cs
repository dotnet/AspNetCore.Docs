using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Ticket;

namespace GrpcGreeterClient
{
    class Program
    {
        // The port number(5001) must match the port of the gRPC server.
        private const string Address = "localhost:5001";

        private static string _token;

        static async Task Main(string[] args)
        {
            var channel = CreateAuthenticatedChannel($"https://{Address}");
            var client = new Ticketer.TicketerClient(channel);

            Console.WriteLine("gRPC Ticketer");
            Console.WriteLine();
            Console.WriteLine("Press a key:");
            Console.WriteLine("1: Get available tickets");
            Console.WriteLine("2: Purchase ticket");
            Console.WriteLine("3: Authenticate");
            Console.WriteLine("4: Exit");
            Console.WriteLine();

            var exiting = false;
            while (!exiting)
            {
                var consoleKeyInfo = Console.ReadKey(intercept: true);
                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        await GetAvailableTickets(client);
                        break;
                    case '2':
                        await PurchaseTicket(client);
                        break;
                    case '3':
                        _token = await Authenticate();
                        break;
                    case '4':
                        exiting = true;
                        break;
                }
            }

            Console.WriteLine("Exiting");
        }

        private static GrpcChannel CreateAuthenticatedChannel(string address)
        {
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    metadata.Add("Authorization", $"Bearer {_token}");
                }
                return Task.CompletedTask;
            });

            // SslCredentials is used here because this channel is using TLS.
            // Channels that aren't using TLS should use ChannelCredentials.Insecure instead.
            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });
            return channel;
        }

        private static async Task<string> Authenticate()
        {
            Console.WriteLine($"Authenticating as {Environment.UserName}...");
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"https://{Address}/generateJwtToken?name={HttpUtility.UrlEncode(Environment.UserName)}"),
                Method = HttpMethod.Get,
                Version = new Version(2, 0)
            };
            var tokenResponse = await httpClient.SendAsync(request);
            tokenResponse.EnsureSuccessStatusCode();

            var token = await tokenResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Successfully authenticated.");

            return token;
        }

        private static async Task PurchaseTicket(Ticketer.TicketerClient client)
        {
            Console.WriteLine("Purchasing ticket...");
            try
            {
                var response = await client.BuyTicketsAsync(new BuyTicketsRequest { Count = 1 });
                if (response.Success)
                {
                    Console.WriteLine("Purchase successful.");
                }
                else
                {
                    Console.WriteLine("Purchase failed. No tickets available.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error purchasing ticket." + Environment.NewLine + ex.ToString());
            }
        }

        private static async Task GetAvailableTickets(Ticketer.TicketerClient client)
        {
            Console.WriteLine("Getting available ticket count...");
            var response = await client.GetAvailableTicketsAsync(new Empty());
            Console.WriteLine("Available ticket count: " + response.Count);
        }
    }
}