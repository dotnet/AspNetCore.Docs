#define Certificate // Managed

#if Certificate
// <snippet_Certificate>

using System.Security.Cryptography.X509Certificates;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    using var x509Store = new X509Store(StoreLocation.CurrentUser);

    x509Store.Open(OpenFlags.ReadOnly);

    var x509Certificate = x509Store.Certificates
        .Find(
            X509FindType.FindByThumbprint,
            builder.Configuration["AzureADCertThumbprint"],
            validOnly: false)
        .OfType<X509Certificate2>()
        .Single();

    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new ClientCertificateCredential(
            builder.Configuration["AzureADDirectoryId"],
            builder.Configuration["AzureADApplicationId"],
            x509Certificate));
}

var app = builder.Build();
// </snippet_Certificate>
#endif

#if Managed
// <snippet_Managed>
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential());
}
// </snippet_Managed>

var app = builder.Build();
#endif

app.MapGet("/", (IConfiguration config) =>
    string.Join(
        Environment.NewLine,
        "SecretName (Name in Key Vault: 'SecretName')",
        @"Obtained from configuration with config[""SecretName""]",
        $"Value: {config["SecretName"]}",
        "",
        "Section:SecretName (Name in Key Vault: 'Section--SecretName')",
        @"Obtained from configuration with config[""Section:SecretName""]",
        $"Value: {config["Section:SecretName"]}",
        "",
        "Section:SecretName (Name in Key Vault: 'Section--SecretName')",
        @"Obtained from configuration with config.GetSection(""Section"")[""SecretName""]",
        $"Value: {config.GetSection("Section")["SecretName"]}"));

app.Run();
