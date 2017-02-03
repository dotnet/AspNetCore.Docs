public void Configuration(IAppBuilder app)
{
    app.Use((context, next) =>
    {
        PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
        return next.Invoke();
    });
    app.Use((context, next) =>
    {
        PrintCurrentIntegratedPipelineStage(context, "2nd MW");
        return next.Invoke();
    });
    app.UseStageMarker(PipelineStage.Authenticate);
    app.Run(context =>
    {
        PrintCurrentIntegratedPipelineStage(context, "3rd MW");
        return context.Response.WriteAsync("Hello world");
    });
    app.UseStageMarker(PipelineStage.ResolveCache);
}