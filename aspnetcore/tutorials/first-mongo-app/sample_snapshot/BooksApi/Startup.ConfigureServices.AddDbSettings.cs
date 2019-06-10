public void ConfigureServices(IServiceCollection services)
{
    services.Configure<BookstoreDatabaseSettings>(
        Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

    services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

    services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}
