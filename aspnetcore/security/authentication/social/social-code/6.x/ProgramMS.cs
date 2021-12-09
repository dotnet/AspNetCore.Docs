var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
        microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
    });
