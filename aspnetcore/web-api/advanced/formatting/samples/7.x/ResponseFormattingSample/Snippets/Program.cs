using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json.Serialization;

namespace ResponseFormattingSample.Snippets;

public static class Program
{
    public static void RespectBrowserAcceptHeader(string[] args)
    {
        // <snippet_RespectBrowserAcceptHeader>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            options.RespectBrowserAcceptHeader = true;
        });
        // </snippet_RespectBrowserAcceptHeader>
    }

    public static void AddXmlSerializerFormatters(string[] args)
    {
        // <snippet_AddXmlSerializerFormatters>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
            .AddXmlSerializerFormatters();
        // </snippet_AddXmlSerializerFormatters>
    }

    public static void JsonSerializerOptions(string[] args)
    {
        // <snippet_JsonSerializerOptions>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        // </snippet_JsonSerializerOptions>
    }

    public static void AddNewtonsoftJson(string[] args)
    {
        // <snippet_AddNewtonsoftJson>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
            .AddNewtonsoftJson();
        // </snippet_AddNewtonsoftJson>
    }

    public static void AddNewtonsoftJsonSerializerSettings(WebApplicationBuilder builder)
    {
        // <snippet_AddNewtonsoftJsonSerializerSettings>
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        // </snippet_AddNewtonsoftJsonSerializerSettings>
    }

    public static void SystemTextJsonValidationMetadataProvider(WebApplicationBuilder builder)
    {
        // <snippet_SystemTextJsonValidationMetadataProvider>
        builder.Services.AddControllers();

        builder.Services.Configure<MvcOptions>(options =>
        {
            options.ModelMetadataDetailsProviders.Add(
                new SystemTextJsonValidationMetadataProvider());
        });
        // </snippet_SystemTextJsonValidationMetadataProvider>
    }

    public static void NewtonsoftJsonValidationMetadataProvider(WebApplicationBuilder builder)
    {
        // <snippet_NewtonsoftJsonValidationMetadataProvider>
        builder.Services.AddControllers()
            .AddNewtonsoftJson();

        builder.Services.Configure<MvcOptions>(options =>
        {
            options.ModelMetadataDetailsProviders.Add(
                new NewtonsoftJsonValidationMetadataProvider());
        });
        // </snippet_NewtonsoftJsonValidationMetadataProvider>
    }

    public static void RemoveOutputFormatters(string[] args)
    {
        // <snippet_RemoveOutputFormatters>
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers(options =>
        {
            // using Microsoft.AspNetCore.Mvc.Formatters;
            options.OutputFormatters.RemoveType<StringOutputFormatter>();
            options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
        });
        // </snippet_RemoveOutputFormatters>
    }
}
