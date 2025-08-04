// <snippet7>

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.Duration;
});

builder.Services.AddRedaction();
builder.Services.AddHttpLoggingRedaction(op => { });
// </snippet7>
