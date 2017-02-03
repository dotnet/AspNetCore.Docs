var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableCrossDomain = true;
hubConfiguration.EnableDetailedErrors = true;
hubConfiguration.EnableJavaScriptProxies = false;
RouteTable.Routes.MapHubs("/signalr", hubConfiguration);