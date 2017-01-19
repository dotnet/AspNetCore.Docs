var hubConfiguration = new HubConfiguration();
hubConfiguration.EnableCrossDomain = true;
RouteTable.Routes.MapHubs(hubConfiguration);