var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableJavaScriptProxies = false;
app.MapSignalR(hubConfiguration);