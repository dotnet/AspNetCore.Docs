using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
    builder.AddServiceDefaults();
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

var myKeyValue = app.Configuration["MyKey"];

app.MapGet("/", () => {
    return Results.Ok($"The value of MyKey is: {myKeyValue}");
})
.WithName("TestKey");

app.Run();
