// <snippet>
using System.Threading.Channels;
using BackgroundQueueService;

var builder = WebApplication.CreateBuilder(args);
// The max memory to use for the upload endpoint on this instance.
var maxMemory = 500 * 1024 * 1024;

// The max size of a single message, staying below the default LOH size of 85K.
var maxMessageSize = 80 * 1024;

// The max size of the queue based on those restrictions
var maxQueueSize = maxMemory / maxMessageSize;

// Create a channel to send data to the background queue.
builder.Services.AddSingleton<Channel<ReadOnlyMemory<byte>>>((_) =>
                     Channel.CreateBounded<ReadOnlyMemory<byte>>(maxQueueSize));

// Create a background queue service.
builder.Services.AddHostedService<BackgroundQueue>();
var app = builder.Build();

// curl --request POST 'https://localhost:<port>/register' --header 'Content-Type: application/json' --data-raw '{ "Name":"Samson", "Age": 23, "Country":"Nigeria" }'
// curl --request POST "https://localhost:<port>/register" --header "Content-Type: application/json" --data-raw "{ \"Name\":\"Samson\", \"Age\": 23, \"Country\":\"Nigeria\" }"
// <snippet_1>
app.MapPost("/register", async (HttpRequest req, Stream body,
                                 Channel<ReadOnlyMemory<byte>> queue) =>
{
    if (req.ContentLength is not null && req.ContentLength > maxMessageSize)
    {
        return Results.BadRequest();
    }

    // We're not above the message size and we have a content length, or
    // we're a chunked request and we're going to read up to the maxMessageSize + 1. 
    // We add one to the message size so that we can detect when a chunked request body
    // is bigger than our configured max.
    var readSize = (int?)req.ContentLength ?? (maxMessageSize + 1);

    var buffer = new byte[readSize];

    // Read at least that many bytes from the body.
    var read = await body.ReadAtLeastAsync(buffer, readSize, throwOnEndOfStream: false);

    // We read more than the max, so this is a bad request.
    if (read > maxMessageSize)
    {
        return Results.BadRequest();
    }

    // Attempt to send the buffer to the background queue.
    if (queue.Writer.TryWrite(buffer.AsMemory(0..read)))
    {
        return Results.Accepted();
    }

    // We couldn't accept the message since we're overloaded.
    return Results.StatusCode(StatusCodes.Status429TooManyRequests);
});
// </snippet_1>

app.Run();
// </snippet>
