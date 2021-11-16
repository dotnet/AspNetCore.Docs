using RoutingSample.Routing;

var builder = WebApplication.CreateBuilder(args);

// <snippet_AddRouting>
builder.Services.AddRouting(options =>
    options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer));
// </snippet_AddRouting>

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
