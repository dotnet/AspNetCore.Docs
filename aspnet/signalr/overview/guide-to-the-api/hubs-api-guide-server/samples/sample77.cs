public void Configuration(IAppBuilder app) 
{ 
    GlobalHost.HubPipeline.AddModule(new LoggingPipelineModule()); 
    app.MapSignalR();
}