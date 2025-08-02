// <snippet7>
// <snippet4>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.Duration;
});
builder.Services.AddHttpLoggingInterceptor<SampleHttpLoggingInterceptor>();
// </snippet4>
builder.Services.AddRedaction();
builder.Services.AddHttpLoggingRedaction(op => { });
// </snippet7>
