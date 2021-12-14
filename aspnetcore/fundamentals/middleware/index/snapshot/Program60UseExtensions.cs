var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/* 
    1. next is type of RequestDelegate which requires passing the HttpContext
    2. Use this for performance benefits
    3. Saves two per request allocations over the previous Use extension
*/

#region snippet1
app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    await next.Invoke(context);
    // Do logging or other work that doesn't write to the Response.
});
#endregion

app.Run();
