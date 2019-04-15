public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddServerSideBlazor<App.Startup>();

        services.AddResponseCompression(options =>
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
            {
                MediaTypeNames.Application.Octet,
                WasmMediaTypeNames.Application.Wasm,
            });
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseResponseCompression();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Use component registrations and static files from the app project.
        app.UseServerSideBlazor<App.Startup>();
    }
}
