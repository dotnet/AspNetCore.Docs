using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;

namespace ViewCompilationSample.Snippets;

public static class Program
{
    public static void AddRazorRuntimeCompilation(string[] args)
    {
        // <snippet_AddRazorRuntimeCompilation>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages()
            .AddRazorRuntimeCompilation();
        // </snippet_AddRazorRuntimeCompilation>
    }

    public static void AddRazorRuntimeCompilationDevelopment(string[] args)
    {
        // <snippet_AddRazorRuntimeCompilationDevelopment>
        var builder = WebApplication.CreateBuilder(args);

        var mvcBuilder = builder.Services.AddRazorPages();

        if (builder.Environment.IsDevelopment())
        {
            mvcBuilder.AddRazorRuntimeCompilation();
        }
        // </snippet_AddRazorRuntimeCompilationDevelopment>
    }

    public static void ConfigureMvcRazorRuntimeCompilationOptions(string[] args)
    {
        // <snippet_ConfigureMvcRazorRuntimeCompilationOptions>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
        {
            var libraryPath = Path.GetFullPath(
                Path.Combine(builder.Environment.ContentRootPath, "..", "MyClassLib"));

            options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
        });
        // </snippet_ConfigureMvcRazorRuntimeCompilationOptions>
    }
}
