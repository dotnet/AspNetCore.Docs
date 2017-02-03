public void Configuration(IAppBuilder app)
{
    // New code:
    app.Run(context =>
    {
        context.Response.ContentType = "text/plain";
        return context.Response.WriteAsync("Hello, world.");
    });
}