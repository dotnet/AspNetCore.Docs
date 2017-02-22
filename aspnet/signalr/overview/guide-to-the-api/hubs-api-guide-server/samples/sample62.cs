public void Configuration(IAppBuilder app)
{
    // Any connection or hub wire up and configuration should go here
    GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule()); 
    app.MapSignalR();
}