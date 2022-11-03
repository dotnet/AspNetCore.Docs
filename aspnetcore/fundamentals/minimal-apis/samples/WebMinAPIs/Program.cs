#define Default // Default CREATE P1 PM PE I1 I0 IP CERT CERT2 CERT3 RE CONFIG LOG #i REB 
// CONFIGB LOGB IWHB DEP R1 LE LF IM SM NR NR2 RP WILD PBG PBP EPB OP1 OP2 OP3 OP4
// CB BA CJSON MULTI STREAM XTN AUTH1 AUTH2 AUTH3 AUTH4 CORS CORS2 SWAG SWAG2 
// FIL2 IHB CHNGR ADDMID
#if NEVER
#elif Default
#region snippet_default
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif IHB
#region snippet_ihb
var builder = WebApplication.CreateBuilder(args);

// Wait 30 seconds for graceful shutdown.
builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CHNGR
#region snippet_chngr
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Look for static files in webroot
    WebRootPath = "webroot"
});

var app = builder.Build();

app.Run();
#endregion
#elif ADDMID
#region snippet_addmid
var app = WebApplication.Create(args);

// Setup the file server to serve static files.
app.UseFileServer();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CREATE
#region snippet_create
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif P1 // P for Port
#region snippet_p1
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run("http://localhost:3000");
#endregion
#elif PM // P for Port
#region snippet_pm
var app = WebApplication.Create(args);

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://localhost:4000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif PE // P for Port
#region snippet_pe
var app = WebApplication.Create(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

app.MapGet("/", () => "Hello World");

app.Run($"http://localhost:{port}");
#endregion
#elif I1
#region snippet_i1
var app = WebApplication.Create(args);

app.Urls.Add("http://*:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif IP
#region snippet_ip
var app = WebApplication.Create(args);

app.Urls.Add("http://+:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif I0
#region snippet_i0
var app = WebApplication.Create(args);

app.Urls.Add("http://0.0.0.0:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif CERT
#region snippet_cert
var app = WebApplication.Create(args);

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif CERT2
// Warning. The following code writes to the configuration system and
// sets the Cert path and key. If those values are invalid, Kestrel won't run
// for that project, even if you remove the following code. Kestrel returns
// Unhandled exception. Internal.Cryptography.CryptoThrowHelper+WindowsCryptographicException:
// The system cannot find the file specified.
#region snippet_cert2
var builder = WebApplication.CreateBuilder(args);

// Configure the cert and the key
builder.Configuration["Kestrel:Certificates:Default:Path"] = "cert.pem";
builder.Configuration["Kestrel:Certificates:Default:KeyPath"] = "key.pem";

var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif CERT3
#region snippet_cert3
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        var certPath = Path.Combine(builder.Environment.ContentRootPath, "cert.pem");
        var keyPath = Path.Combine(builder.Environment.ContentRootPath, "key.pem");

        httpsOptions.ServerCertificate = X509Certificate2.CreateFromPemFile(certPath, 
                                         keyPath);
    });
});

var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif RE
#region snippet_re
var app = WebApplication.Create(args);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/oops");
}

app.MapGet("/", () => "Hello World");
app.MapGet("/oops", () => "Oops! An error happened.");

app.Run();
#endregion
#elif CONFIG
#region snippet_config 
var app = WebApplication.Create(args);

var message = app.Configuration["HelloKey"] ?? "Hello";

app.MapGet("/", () => message);

app.Run();
#endregion
#elif LOG
#region snippet_log
var app = WebApplication.Create(args);

app.Logger.LogInformation("The app started");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif DEPS
#region snippet_dependencies

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<SampleService>();

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var sampleService = scope.ServiceProvider.GetRequiredService<SampleService>();
    sampleService.DoSomething();
}

app.Run();
#endregion
class SampleService { public void DoSomething() { } }
#elif REB  // Read Env Builder
#region snippet_reb
var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine($"Running in development.");
}

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CONFIGB
#region snippet_configb
var builder = WebApplication.CreateBuilder(args);

var message = builder.Configuration["HelloKey"] ?? "Hello";

var app = builder.Build();

app.MapGet("/", () => message);

app.Run();
#endregion
#elif LOGB
#region snippet_logb
var builder = WebApplication.CreateBuilder(args);

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

var app = builder.Build();

app.MapGet("/", () => "Hello JSON console!");

app.Run();
#endregion
#elif IWHB
#region snippet_iwhb
var builder = WebApplication.CreateBuilder(args);

// Change the HTTP server implemenation to be HTTP.sys based
builder.WebHost.UseHttpSys();

var app = builder.Build();

app.MapGet("/", () => "Hello HTTP.sys");

app.Run();
#endregion
#elif DEP
#region snippet_dep
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
{
    throw new InvalidOperationException("Oops, the '/' route has thrown an exception.");
});

app.Run();
#endregion
#elif R1 // Routing
#region snippet_r1
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "This is a GET");
app.MapPost("/", () => "This is a POST");
app.MapPut("/", () => "This is a PUT");
app.MapDelete("/", () => "This is a DELETE");

app.MapMethods("/options-or-head", new[] { "OPTIONS", "HEAD" }, 
                          () => "This is an options or head request ");

app.Run();
#endregion
#elif LE
#region snippet_le
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/inline", () => "This is an inline lambda");

var handler = () => "This is a lambda variable";

app.MapGet("/", handler);

app.Run();
#endregion
#elif LF
#region snippet_lf
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string LocalFunction() => "This is local function";

app.MapGet("/", LocalFunction);

app.Run();
#endregion

#elif IM
#region snippet_im
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var handler = new HelloHandler();

app.MapGet("/", handler.Hello);

app.Run();

class HelloHandler
{
    public string Hello()
    {
        return "Hello Instance method";
    }
}
#endregion

#elif SM
#region snippet_sm
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", HelloHandler.Hello);

app.Run();

class HelloHandler
{
    public static string Hello()
    {
        return "Hello static method";
    }
}
#endregion

#elif NR
#region snippet_nr
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => "Hello named route")
   .WithName("hi");

app.MapGet("/", (LinkGenerator linker) => 
        $"The link to the hello route is {linker.GetPathByName("hi", values: null)}");

app.Run();
#endregion

#elif RP
#region snippet_rp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/users/{userId}/books/{bookId}", 
    (int userId, int bookId) => $"The user id is {userId} and book id is {bookId}");

app.Run();
#endregion

#elif WILD
#region snippet_wild
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/posts/{*rest}", (string rest) => $"Routing to {rest}");

app.Run();
#endregion
#elif PBG
#region snippet_pbg
var builder = WebApplication.CreateBuilder(args);

// Added as service
builder.Services.AddSingleton<Service>();

var app = builder.Build();

app.MapGet("/{id}", (int id,
                     int page,
                     [FromHeader(Name = "X-CUSTOM-HEADER")] string customHeader,
                     Service service) => { });

class Service { }
#endregion

#elif PBP
#region snippet_pbp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/", (Person person) => { });

record Person(string Name, int Age);
#endregion

#elif EPB
#region snippet_epb
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Added as service
builder.Services.AddSingleton<Service>();

var app = builder.Build();


app.MapGet("/{id}", ([FromRoute] int id,
                     [FromQuery(Name = "p")] int page,
                     [FromServices] Service service,
                     [FromHeader(Name = "Content-Type")] string contentType) 
                     => {});

class Service { }

record Person(string Name, int Age);
#endregion

#elif OP1
// GET /products?pageNumber=3
#region snippet_op1
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products", (int pageNumber) => $"Requesting page {pageNumber}");

app.Run();
#endregion

#elif OP2
#region snippet_op2
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products", (int? pageNumber) => $"Requesting page {pageNumber ?? 1}");

string ListProducts(int pageNumber = 1) => $"Requesting page {pageNumber}";

app.MapGet("/products2", ListProducts);

app.Run();
#endregion

#elif OP3
#region snippet_op3
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/products", (Product? product) => { });

app.Run();

#endregion
internal class Product
{
}

#elif OP4
#region snippet_op4
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products", (int? pageNumber) => $"Requesting page {pageNumber ?? 1}");

app.Run();
#endregion

#elif CB
#region snippet_cb
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /map?Point=12.3,10.1
app.MapGet("/map", (Point point) => $"Point: {point.X}, {point.Y}");

app.Run();

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public static bool TryParse(string? value, IFormatProvider? provider,
                                out Point? point)
    {
        // Format is "(12.3,10.1)"
        var trimmedValue = value?.TrimStart('(').TrimEnd(')');
        var segments = trimmedValue?.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (segments?.Length == 2
            && double.TryParse(segments[0], out var x)
            && double.TryParse(segments[1], out var y))
        {
            point = new Point { X = x, Y = y };
            return true;
        }

        point = null;
        return false;
    }
}
#endregion

#elif BA
#region snippet_ba
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /products?SortBy=xyz&SortDir=Desc&Page=99
app.MapGet("/products", (PagingData pageData) => $"SortBy:{pageData.SortBy}, " +
       $"SortDirection:{pageData.SortDirection}, CurrentPage:{pageData.CurrentPage}");

app.Run();

public class PagingData
{
    public string? SortBy { get; init; }
    public SortDirection SortDirection { get; init; }
    public int CurrentPage { get; init; } = 1;

    public static ValueTask<PagingData?> BindAsync(HttpContext context,
                                                   ParameterInfo parameter)
    {
        const string sortByKey = "sortBy";
        const string sortDirectionKey = "sortDir";
        const string currentPageKey = "page";

        Enum.TryParse<SortDirection>(context.Request.Query[sortDirectionKey],
                                     ignoreCase: true, out var sortDirection);
        int.TryParse(context.Request.Query[currentPageKey], out var page);
        page = page == 0 ? 1 : page;

        var result = new PagingData
        {
            SortBy = context.Request.Query[sortByKey],
            SortDirection = sortDirection,
            CurrentPage = page
        };

        return ValueTask.FromResult<PagingData?>(result);
    }
}

public enum SortDirection
{
    Default,
    Asc,
    Desc
}
#endregion

#elif CJSON
#region snippet_cjson
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON options.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.IncludeFields = true;
});

var app = builder.Build();

app.MapPost("/products", (Product product) => product);

app.Run();

class Product
{
    // These are public fields, not properties.
    public int Id;
    public string? Name;
}
#endregion

#elif MULTI
#region snippet_666  // never rendered, just for testing.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
// Return HTTP 405 error
app.MapGet("/405", () => Results.StatusCode(405));
app.MapGet("/text", () => Results.Text("This is some text"));
app.MapGet("/old-path", () => Results.Redirect("/new-path"));
app.MapGet("/new-path", () => "This is the new path.");
// Returns /wwwroot/TextFile.txt
app.MapGet("/download", () => Results.File("TextFile.txt"));

app.Run();
#endregion

#elif STREAM
#region snippet_stream
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var proxyClient = new HttpClient();
app.MapGet("/pokemon", async () => 
{
    var stream = await proxyClient.GetStreamAsync("http://consoto/pokedex.json");
    // Proxy the response as JSON
    return Results.Stream(stream, "application/json");
});

app.Run();
#endregion

#elif XTN
#region snippet_xtn
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/html", () => Results.Extensions.Html(@$"<!doctype html>
<html>
    <head><title>miniHTML</title></head>
    <body>
        <h1>Hello World</h1>
        <p>The time on the server is {DateTime.Now:O}</p>
    </body>
</html>"));

app.Run();
#endregion

#elif AUTH2  // This is not a complete/valid sample
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseAuthorization();

#region snippet_auth2
app.MapGet("/auth", () => "This endpoint requires authorization")
   .RequireAuthorization();
#endregion

app.Run();
#elif AUTH4
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region snippet_auth4
app.MapGet("/login", [AllowAnonymous] () => "This endpoint is for all roles.");


app.MapGet("/login2", () => "This endpoint also for all roles.")
   .AllowAnonymous();
#endregion

app.Run();

#elif CORS
#region snippet_cors
const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});

var app = builder.Build();
app.UseCors();

app.MapGet("/",() => "Hello CORS!");

app.Run();
#endregion

#elif CORS2

#region snippet_cors2
using Microsoft.AspNetCore.Cors;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com");
                      });
});

var app = builder.Build();
app.UseCors();

app.MapGet("/cors", [EnableCors(MyAllowSpecificOrigins)] () => 
                           "This endpoint allows cross origin requests!");
app.MapGet("/cors2", () => "This endpoint allows cross origin requests!")
                     .RequireCors(MyAllowSpecificOrigins);

app.Run();
#endregion

#elif SWAG
// GET /swagger
#region snippet_swag
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName,
                               Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                    $"{builder.Environment.ApplicationName} v1"));
}

app.MapGet("/swag", () => "Hello Swagger!");

app.Run();
#endregion

#elif SWAG2
#region snippet_swag2
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/swag", () => "Hello Swagger!");
app.MapGet("/skipme", () => "Skipping Swagger.")
                    .ExcludeFromDescription();

app.Run();
#endregion

#elif FILEUPLOAD
#region snippet_fileupload
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/uploadstream", async (IConfiguration config, HttpRequest request) =>
{
    var filePath = Path.Combine(config["StoredFilesPath"], Path.GetRandomFileName());

    await using var writeStream = File.Create(filePath);
    await request.BodyReader.CopyToAsync(writeStream);
});

app.Run();
#endregion

#endif
