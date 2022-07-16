using System.Threading.Channels;
using BackgroundQueueService;
var builder = WebApplication.CreateBuilder(args);
// Create a channel to send data to the background queue.
builder.Services.AddSingleton<Channel<ReadOnlyMemory<byte>>>((_) => Channel.CreateBounded<ReadOnlyMemory<byte>>(100));

// Create a background queue service.
builder.Services.AddHostedService<BackgroundQueue>();
var app = builder.Build();

// curl --request POST 'http://localhost:5256/register' --header 'Content-Type: application/json' --data-raw '{ "Name":"Samson", "Age": 23, "Country":"Nigeria" }'
app.MapPost("/register", async (Stream body, Channel<ReadOnlyMemory<byte>> queue) =>
{
    // Create a rewindable stream to be able to reuse the body stream.
    var reusableStream = new MemoryStream();

    // Copy the request body to the reusable stream.
    await body.CopyToAsync(reusableStream);

    // get buffer to avoid double allocation
    reusableStream.TryGetBuffer(out var buffer);

    // Send the buffer to the background queue.
    await queue.Writer.WriteAsync(buffer);
    
    return Results.Accepted();
});


app.Run();
