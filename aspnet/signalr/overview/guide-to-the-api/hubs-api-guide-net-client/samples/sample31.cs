var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableDetailedErrors = true;
App.MapSignalR(hubConfiguration);