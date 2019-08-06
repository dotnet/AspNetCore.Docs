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

        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri($"https://{Address}") };
            var client = GrpcClient.Create<Ticketer.TicketerClient>(httpClient);

            Console.WriteLine("gRPC Ticketer");
            Console.WriteLine();
            Console.WriteLine("Press a key:");
            Console.WriteLine("1: Get available tickets");
            Console.WriteLine("2: Purchase ticket");
            Console.WriteLine("3: Authenticate");
            Console.WriteLine("4: Exit");
            Console.WriteLine();

            string token = null;

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
                        await PurchaseTicket(client, token);
                        break;
                    case '3':
                        token = await Authenticate();
                        break;
                    case '4':
                        exiting = true;
                        break;
                }
            }

            Console.WriteLine("Exiting");
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

        private static async Task PurchaseTicket(Ticketer.TicketerClient client, string token)
        {
            Console.WriteLine("Purchasing ticket...");
            try
            {
                Metadata? headers = null;
                if (token != null)
                {
                    headers = new Metadata();
                    headers.Add("Authorization", $"Bearer {token}");
                }

                var response = await client.BuyTicketsAsync(new BuyTicketsRequest { Count = 1 }, headers);
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