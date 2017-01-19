protected void Application_Start(object sender, EventArgs e) 
{ 
    GlobalHost.HubPipeline.AddModule(new LoggingPipelineModule()); 
    RouteTable.Routes.MapHubs();
}