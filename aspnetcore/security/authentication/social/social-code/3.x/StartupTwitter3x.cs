public void ConfigureServices(IServiceCollection services)
#region snippet
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
    services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
    services.AddRazorPages();

    services.AddAuthentication().AddTwitter(twitterOptions =>
    {
        twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
        twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
		
		// Request the email address from users
		twitterOptions.RetrieveUserDetails = true;
    });

}
#endregion