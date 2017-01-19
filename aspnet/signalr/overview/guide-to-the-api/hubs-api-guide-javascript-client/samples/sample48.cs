var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableDetailedErrors = true;
app.MapSignalR(hubConfiguration);