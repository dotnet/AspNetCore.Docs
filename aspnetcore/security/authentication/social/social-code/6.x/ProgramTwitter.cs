var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddTwitter(twitterOptions =>
    {
        twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerAPIKey"];
        twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
    });
