using System.Threading.Channels;
using BackgroundQueueService;
var builder = WebApplication.CreateBuilder(args);
// Create a channel to send data to the background queue.
builder.Services.AddSingleton<Channel<Stream>>((_) => Channel.CreateUnbounded<Stream>());

// Create a background queue service.
builder.Services.AddHostedService<BackgroundQueue>();
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    var reader = new StreamReader(context.Request.Body);
    app.Logger.LogInformation("Reading the stream from the request body.");
});

app.MapGet("/", () => "Hello World!");

// curl --request POST 'http://localhost:5256/register' --header 'Content-Type: application/json' --data-raw '{ "Name":"Samson", "Age": 23, "Country":"Nigeria" }'
app.MapPost("/register", async (Stream body, HttpRequest req, Channel<Stream> queue) =>
{
    // Create a rewindable stream to be able to reuse the body stream.
    var reusableStream = new MemoryStream();

    // Copy the request body to the reusable stream.
    await body.CopyToAsync(reusableStream);

    // Reset the stream to the beginning.
    reusableStream.Position = 0;

    // Send the stream to the background queue.
    await queue.Writer.WriteAsync(reusableStream);

    // Reset the stream to the beginning.
    reusableStream.Position = 0;

    // Set the response body to the reusable stream.
    req.Body = new MemoryStream(reusableStream.ToArray());

    return "registered";
});


app.Run();


