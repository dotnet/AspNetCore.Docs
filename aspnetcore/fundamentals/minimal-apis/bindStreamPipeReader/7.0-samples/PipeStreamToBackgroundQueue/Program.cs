using System.Threading.Channels;
using BackGroundQueueService;
var builder = WebApplication.CreateBuilder(args);
// create a channel to send data to the background queue
builder.Services.AddSingleton<Channel<Stream>>((_)=>Channel.CreateUnbounded<Stream>());

// create a background queue service
builder.Services.AddHostedService<BackGroundQueue>();
var app = builder.Build();

app.Use(async (context, next) =>
{
 await next();
 // read the stream from the request body
 var reader = new StreamReader(context.Request.Body);

 //.. you could decide to do some logging here
 
});

app.MapGet("/", () => "Hello World!");

// curl --request POST https://localhost:{port}/register --header "Content-Type: application/json" --data-raw "{ \"Name\":\"Samson\", \"Age\": 23, \"Country\":\"Nigeria\" }"
app.MapPost("/register", async (Stream body, HttpRequest req, Channel<Stream> queue) =>
{
    // create a rewindable stream to be able to reuse the body stream
    var reusableStream = new MemoryStream();
    
    // copy the request body to the reusable stream
    await body.CopyToAsync(reusableStream);

    // reset the stream to the beginning
   reusableStream.Position = 0;

   // send the stream to the background queue
   await queue.Writer.WriteAsync(reusableStream);

   // reset the stream to the beginning
   reusableStream.Position = 0;

   // set the response body to the reusable stream
    req.Body = new MemoryStream(reusableStream.ToArray());

   return "registered";
});


app.Run();

