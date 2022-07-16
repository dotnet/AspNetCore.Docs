using System.Threading.Channels;
using BackgroundQueueService;
var builder = WebApplication.CreateBuilder(args);
// Create a channel to send data to the background queue.
builder.Services.AddSingleton<Channel<Memory<byte>>>((_) => Channel.CreateBounded<Memory<byte>>(100));

// Create a background queue service.
builder.Services.AddHostedService<BackgroundQueue>();
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

// curl --request POST 'http://localhost:5256/register' --header 'Content-Type: application/json' --data-raw '{ "Name":"Samson", "Age": 23, "Country":"Nigeria" }'
app.MapPost("/register", async (Stream body, Channel<Memory<byte>> queue) =>
{
    // Create a rewindable stream to be able to reuse the body stream.
    var reusableStream = new MemoryStream();

    // Copy the request body to the reusable stream.
    await body.CopyToAsync(reusableStream);

    // Reset the stream to the beginning.
    reusableStream.Position = 0;

    // Send the stream to the background queue.
    await queue.Writer.WriteAsync(reusableStream.ToArray());
    
    return Results.Accepted();
});


app.Run();
