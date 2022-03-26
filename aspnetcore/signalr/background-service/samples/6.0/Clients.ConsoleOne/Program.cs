using HubServiceInterfaces;
using Microsoft.AspNetCore.SignalR.Client;

#region Program
var connection = new HubConnectionBuilder()
    .WithUrl(Strings.HubUrl)
    .Build();

connection.On<DateTime>(Strings.Events.TimeSent, dateTime =>
{
    Console.WriteLine(dateTime.ToString());
});

// Loop is here to wait until the server is running
while (true)
{
    try
    {
        await connection.StartAsync();

        break;
    }
    catch
    {
        await Task.Delay(1000);
    }
}

Console.WriteLine("Client One listening. Hit Ctrl-C to quit.");
Console.ReadLine();
#endregion
