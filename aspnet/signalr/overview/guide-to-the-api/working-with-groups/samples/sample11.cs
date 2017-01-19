public partial class Startup {
    public void Configuration(IAppBuilder app) {
        app.MapSignalR();
        GlobalHost.HubPipeline.AddModule(new RejoingGroupPipelineModule());
    }
}