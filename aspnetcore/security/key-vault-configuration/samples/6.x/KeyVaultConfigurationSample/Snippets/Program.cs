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

    public static void AddAzureKeyVaultManagedIdentityClientId(WebApplicationBuilder builder)
    {
        // <snippet_AddAzureKeyVaultManagedIdentityClientId>
        builder.Configuration.AddAzureKeyVault(
            new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
            new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = builder.Configuration["AzureADManagedIdentityClientId"]
            }));
        // </snippet_AddAzureKeyVaultManagedIdentityClientId>
    }

    public static void AddAzureKeyVaultSecretManager(WebApplicationBuilder builder)
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
