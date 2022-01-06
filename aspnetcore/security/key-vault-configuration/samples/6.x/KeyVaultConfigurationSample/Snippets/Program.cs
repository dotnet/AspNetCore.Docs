using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;

namespace KeyVaultConfigurationSample.Snippets;

public static class Program
{
    public static void AddAzureKeyVaultConfigurationOptions(WebApplicationBuilder builder)
    {
        // <snippet_AddAzureKeyVaultConfigurationOptions>
        // using Azure.Extensions.AspNetCore.Configuration.Secrets;

        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
            new DefaultAzureCredential(),
            new AzureKeyVaultConfigurationOptions
            {
                // ...
            });
        // </snippet_AddAzureKeyVaultConfigurationOptions>
    }

    public static void AddAzureKeyVaultSecretManager(WebApplicationBuilder builder, string versionPrefix)
    {
        // <snippet_AddAzureKeyVaultSecretManager>
        // using Azure.Extensions.AspNetCore.Configuration.Secrets;

        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
            new DefaultAzureCredential(),
            new SamplePrefixKeyVaultSecretManager("5000"));
        // </snippet_AddAzureKeyVaultSecretManager>
    }
}
