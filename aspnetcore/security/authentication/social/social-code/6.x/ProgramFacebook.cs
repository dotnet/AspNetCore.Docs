var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
        facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
    });
