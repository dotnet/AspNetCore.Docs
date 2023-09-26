#define RequestHeaders // Default CREATE P1 PM PE I1 I0 IP CERT CERT2 CERT3 RE CONFIG LOG #i REB 
// CONFIGB LOGB IWHB DEP R1 LE LF IM SM NR NR2 RP WILD PBG PBP EPB OP1 OP2 OP3 OP4
// CB BA CJSON MULTI STREAM XTN AUTH1 AUTH2 AUTH3 AUTH4 CORS CORS2 SWAG SWAG2 
// FIL2 IHB CHNGR ADDMID
#if NEVER
#elif RequestHeaders
// <snippet_RequestHeaders>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpRequest request) =>
{
    var userAgent = request.Headers.UserAgent;
    var customHeader = request.Headers["x-custom-header"];

    return Results.Ok(new { userAgent = userAgent, customHeader = customHeader });
});

app.Run();
// </snippet_RequestHeaders>
#elif RequestBody
// <snippet_RequestBody>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/uploadstream", async (IConfiguration config, HttpContext context) =>
{
    var filePath = Path.Combine(config["StoredFilesPath"], Path.GetRandomFileName());

    await using var writeStream = File.Create(filePath);
    await context.Request.Body.CopyToAsync(writeStream);
});

app.Run();
// </snippet_RequestBody>
#elif RequestBuffering
// <snippet_RequestBuffering>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await ReadRequestBody(context.Request.Body);
    context.Request.Body.Position = 0;
    
    await next.Invoke();
});

app.Run();
// </snippet_RequestBuffering>
#elif ResponseHeaders
// <snippet_ResponseHeaders>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpResponse response) =>
{
    response.Headers.CacheControl = "no-cache";
    response.Headers["x-custom-header"] = "Custom value";

    return Results.File(File.OpenRead("helloworld.txt"));
});

app.Run();
// </snippet_ResponseHeaders>
#elif ResponseTrailers
// <snippet_ResponseTrailers>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpResponse response) =>
{
    // Write body
    response.WriteAsync("Hello world");

    if (response.SupportsTrailers())
    {
        response.AppendTrailer("trailername", "TrailerValue");
    }
});

app.Run();
// </snippet_ResponseTrailers>
#elif ResposeBody
// <snippet_ResponseBody>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/downloadfile", async (IConfiguration config, HttpContext context) =>
{
    var filePath = Path.Combine(config["StoredFilesPath"], "helloworld.txt");

    await using var fileStream = File.OpenRead(filePath);
    await fileStream.CopyToAsync(context.Response.Body);
});

app.Run();
// </snippet_ResponseBody>
#elif RequestAborted
// <snippet_RequestAborted>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var httpClient = new HttpClient();
app.MapPost("/books/{bookId}", async (int bookId, HttpContext context) =>
{
    var stream = await httpClient.GetStreamAsync(
        $"http://consoto/books/{bookId}.json", context.RequestAborted);

    // Proxy the response as JSON
    return Results.Stream(stream, "application/json");
});

app.Run();
// </snippet_RequestAborted>
#elif Abort
// <snippet_Abort>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (RequestAppearsMalicious(context.Request))
    {
        // Malicious requests don't even deserve an error response (e.g. 400).
        context.Abort();
        return;
    }

    await next.Invoke();
});

app.Run();
// </snippet_Abort>
#elif User
// <snippet_User>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/user/current", [Authorize] async (HttpContext context) =>
{
    var user = await GetUserAsync(context.User.Identity.Name);
    return Results.Ok(user);
});

app.Run();
// </snippet_User>
#elif Features
// <snippet_Features>
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/long-running-stream", async (HttpContext context) =>
{
    var feature = context.Features.Get<IHttpMinRequestBodyDataRateFeature>();
    if (feature != null)
    {
        feature.MinDataRate = null;
    }

    // await and read long-running stream from request body.
    await Task.Yield();
});

app.Run();
// </snippet_Features>
#endif
