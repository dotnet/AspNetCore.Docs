// <snippet_HubsNamespace>
using SignalRWebpack.Hubs;
// </snippet_HubsNamespace>

// <snippet_AddSignalR>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
// </snippet_AddSignalR>

// <snippet_FilesMiddleware>
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
// </snippet_FilesMiddleware>

// <snippet_MapHub>
app.MapHub<ChatHub>("/hub");
// </snippet_MapHub>

app.Run();
