var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableDetailedErrors = true;
RouteTable.Routes.MapHubs(hubConfiguration);