// <snippet7>
// <snippet4>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.Duration;
});
// </snippet4>
builder.Services.AddRedaction();
builder.Services.AddHttpLoggingRedaction(op => { });
// </snippet7>
