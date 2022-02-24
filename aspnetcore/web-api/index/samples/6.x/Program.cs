#define D400 // FIRST GLOBAL L400 D400
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
#elif GLOBAL
#region snippet_global
using Microsoft.AspNetCore.Mvc;
[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
#elif L400
#region snippet_l400
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // To preserve the default behavior, capture the original delegate to call later.
        var builtInFactory = options.InvalidModelStateResponseFactory;

        options.InvalidModelStateResponseFactory = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();

            // Perform logging here.
            // ...

            // Invoke the default behavior, which produces a ValidationProblemDetails response.
            // To produce a custom response, return a different implementation of IActionResult instead.
            return builtInFactory(context);
        };
    });

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
#elif D400
#region snippet_d400
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressConsumesConstraintForFormFileParameters = true;
        options.SuppressInferBindingSourcesForParameters = true;
        options.SuppressModelStateInvalidFilter = true;
        options.SuppressMapClientErrors = true;
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
            "https://httpstatuses.com/404";
   //'ApiBehaviorOptions' does not contain a definition for 'DisableImplicitFromServicesParameters'
   //and no accessible extension method 'DisableImplicitFromServicesParameters' accepting a first
   //argument of type 'ApiBehaviorOptions' could be found(are you missing a using directive or an assembly reference ?)  WebApiSample C:\GH\aspnet\docs\3\AspNetCore.Docs\aspnetcore\web - api\index\samples\6.x\Program.cs 86  Active

    //options.DisableImplicitFromServicesParameters = true;
    });


builder.Services.Configure<ApiBehaviorOptions>(options => {
  //'ApiBehaviorOptions' does not contain a definition for 'DisableImplicitFromServicesParameters' and no accessible extension method 'DisableImplicitFromServicesParameters' accepting a first argument of type 'ApiBehaviorOptions' could be found(are you missing a using directive or an assembly reference ?)  WebApiSample C:\GH\aspnet\docs\3\AspNetCore.Docs\aspnetcore\web - api\index\samples\6.x\Program.cs 91  Active
  // options.DisableImplicitFromServicesParameters = true;
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
#endif