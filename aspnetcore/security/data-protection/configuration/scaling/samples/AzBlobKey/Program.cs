using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;

var hostBuilder = new HostApplicationBuilder();

// hostBuilder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

var blobStorageUri = hostBuilder.Configuration["AzureURIs:BlobStorage"]!;
var keyVaultURI = hostBuilder.Configuration["AzureURIs:KeyVault"]!;

// Use the same persistence and protection mechanisms as your app.
hostBuilder.Services
    .AddDataProtection()
    .PersistKeysToAzureBlobStorage(new Uri(blobStorageUri), new DefaultAzureCredential())
    .ProtectKeysWithAzureKeyVault(new Uri(keyVaultURI), new DefaultAzureCredential());

using var host = hostBuilder.Build();

// Perform a dummy operation to force key creation or rotation, if needed.
var dataProtector = host.Services.GetDataProtector("Default");
dataProtector.Protect([]);
