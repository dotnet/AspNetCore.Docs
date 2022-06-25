#define MIN // FIRST DIS MIN
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDateTime, SystemDateTime>();

var app = builder.Build();

app.MapControllers();

app.Run();
#endregion
#elif DIS
#region snippet_dis
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDateTime, SystemDateTime>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});

var app = builder.Build();

app.MapControllers();

app.Run();
#endregion
#elif MIN
#region snippet_min
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDateTime, SystemDateTime>();

var app = builder.Build();

app.MapGet("/", (IDateTime dateTime) => dateTime.Now);
app.MapGet("/x", ([FromServices] IDateTime dateTime) => dateTime.Now);
app.Run();
#endregion
#endif
