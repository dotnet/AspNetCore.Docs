#if Never
#region snippet_1
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => options.Conventions.Add(
        new NamespaceRoutingConvention("WebApplication1")));
}
#endregion
#endif