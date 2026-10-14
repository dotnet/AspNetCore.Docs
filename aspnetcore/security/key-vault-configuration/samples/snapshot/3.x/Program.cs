config.AddAzureKeyVault(
    $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
    builtConfig["AzureADApplicationId"],
    certs.OfType<X509Certificate2>().Single(),
    new PrefixKeyVaultSecretManager(versionPrefix));
