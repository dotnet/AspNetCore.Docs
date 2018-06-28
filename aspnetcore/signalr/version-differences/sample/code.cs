services.AddSignalR();
app.UseSignalR(routes =>
{
    routes.MapHub<ChatHub>("/hub");
});

connection = new HubConnectionBuilder()
.WithUrl("url")
.Build();