#define Third // First Second Third
#if First
#region snippet1
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// WebHost
builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
builder.WebHost.UseEnvironment(Environments.Staging);

builder.WebHost.UseSetting(WebHostDefaults.ApplicationKey, "ApplicationName2");
builder.WebHost.UseSetting(WebHostDefaults.ContentRootKey, Directory.GetCurrentDirectory());
builder.WebHost.UseSetting(WebHostDefaults.EnvironmentKey, Environments.Staging);

// Host
builder.Host.UseEnvironment(Environments.Staging);
// The following line doesn't throw 
builder.Host.UseContentRoot(Directory.GetCurrentDirectory());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
#elif Second
#region snippet2
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// WebHost

try
{
    builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    builder.WebHost.UseEnvironment(Environments.Staging);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    builder.WebHost.UseSetting(WebHostDefaults.ApplicationKey, "ApplicationName2");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    builder.WebHost.UseSetting(WebHostDefaults.ContentRootKey, Directory.GetCurrentDirectory());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    builder.WebHost.UseSetting(WebHostDefaults.EnvironmentKey, Environments.Staging);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Host
try
{
    builder.Host.UseEnvironment(Environments.Staging);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    // TODO: This does not throw
    builder.Host.UseContentRoot(Directory.GetCurrentDirectory());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
#elif Third
#region snippet3
var builder = WebApplication.CreateBuilder(args);

try
{
    builder.Host.ConfigureWebHostDefaults(webHostBuilder =>
    {
        webHostBuilder.UseStartup<Startup>();
    });
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;    
}

builder.Services.AddRazorPages();

var app = builder.Build();
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endif
