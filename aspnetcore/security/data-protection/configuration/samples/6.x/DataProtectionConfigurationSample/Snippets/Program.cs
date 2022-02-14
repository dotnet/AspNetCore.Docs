using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace DataProtectionConfigurationSample.Snippets;

public static class Program
{
    public static void AddDataProtectionProtectKeysWithAzureKeyVault(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionProtectKeysWithAzureKeyVault>
        builder.Services.AddDataProtection()
            .PersistKeysToAzureBlobStorage(new Uri("<blobUriWithSasToken>"))
            .ProtectKeysWithAzureKeyVault(new Uri("<keyIdentifier>"), new DefaultAzureCredential());
        // </snippet_AddDataProtectionProtectKeysWithAzureKeyVault>
    }

    public static void AddDataProtectionProtectKeysWithAzureKeyVaultConnectionString(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionProtectKeysWithAzureKeyVaultConnectionString>
        builder.Services.AddDataProtection()
            // This blob must already exist before the application is run
            .PersistKeysToAzureBlobStorage("<storageAccountConnectionString", "<containerName>", "<blobName>")
            // Removing this line below for an initial run will ensure the file is created correctly
            .ProtectKeysWithAzureKeyVault(new Uri("<keyIdentifier>"), new DefaultAzureCredential());
        // </snippet_AddDataProtectionProtectKeysWithAzureKeyVaultConnectionString>
    }

    public static void AddDataProtectionPersistKeysToFileSystem(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionPersistKeysToFileSystem>
        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
        // </snippet_AddDataProtectionPersistKeysToFileSystem>
    }

    public static void AddDataProtectionPersistKeysToDbContext(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionPersistKeysToDbContext>
        builder.Services.AddDataProtection()
            .PersistKeysToDbContext<SampleDbContext>();
        // </snippet_AddDataProtectionPersistKeysToDbContext>
    }

    public static void AddDataProtectionProtectKeysWithCertificate(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionProtectKeysWithCertificate>
        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
            .ProtectKeysWithCertificate(builder.Configuration["CertificateThumbprint"]);
        // </snippet_AddDataProtectionProtectKeysWithCertificate>
    }

    public static void AddDataProtectionProtectKeysWithCertificateX509Certificate2(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionProtectKeysWithCertificateX509Certificate2>
        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
            .ProtectKeysWithCertificate(
                new X509Certificate2("certificate.pfx", builder.Configuration["CertificatePassword"]));
        // </snippet_AddDataProtectionProtectKeysWithCertificateX509Certificate2>
    }

    public static void AddDataProtectionUnprotectKeysWithAnyCertificate(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionUnprotectKeysWithAnyCertificate>
        builder.Services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"))
            .ProtectKeysWithCertificate(
                new X509Certificate2("certificate.pfx", builder.Configuration["CertificatePassword"]))
            .UnprotectKeysWithAnyCertificate(
                new X509Certificate2("certificate_1.pfx", builder.Configuration["CertificatePassword_1"]),
                new X509Certificate2("certificate_2.pfx", builder.Configuration["CertificatePassword_2"]));
        // </snippet_AddDataProtectionUnprotectKeysWithAnyCertificate>
    }

    public static void AddDataProtectionSetDefaultKeyLifetime(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionSetDefaultKeyLifetime>
        builder.Services.AddDataProtection()
            .SetDefaultKeyLifetime(TimeSpan.FromDays(14));
        // </snippet_AddDataProtectionSetDefaultKeyLifetime>
    }

    public static void AddDataProtectionSetApplicationName(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionSetApplicationName>
        builder.Services.AddDataProtection()
            .SetApplicationName("<sharedApplicationName>");
        // </snippet_AddDataProtectionSetApplicationName>
    }

    public static void AddDataProtectionDisableAutomaticKeyGeneration(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionDisableAutomaticKeyGeneration>
        builder.Services.AddDataProtection()
            .DisableAutomaticKeyGeneration();
        // </snippet_AddDataProtectionDisableAutomaticKeyGeneration>
    }

    public static void AddDataProtectionUseCryptographicAlgorithms(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionUseCryptographicAlgorithms>
        builder.Services.AddDataProtection()
            .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            });
        // </snippet_AddDataProtectionUseCryptographicAlgorithms>
    }

    public static void AddDataProtectionUseCustomCryptographicAlgorithms(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionUseCustomCryptographicAlgorithms>
        builder.Services.AddDataProtection()
            .UseCustomCryptographicAlgorithms(new ManagedAuthenticatedEncryptorConfiguration
            {
                // A type that subclasses SymmetricAlgorithm
                EncryptionAlgorithmType = typeof(Aes),

                // Specified in bits
                EncryptionAlgorithmKeySize = 256,

                // A type that subclasses KeyedHashAlgorithm
                ValidationAlgorithmType = typeof(HMACSHA256)
            });
        // </snippet_AddDataProtectionUseCustomCryptographicAlgorithms>
    }

#pragma warning disable CA1416 // Validate platform compatibility
    public static void AddDataProtectionUseCustomCryptographicAlgorithmsCngCbc(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngCbc>
        builder.Services.AddDataProtection()
            .UseCustomCryptographicAlgorithms(new CngCbcAuthenticatedEncryptorConfiguration
            {
                // Passed to BCryptOpenAlgorithmProvider
                EncryptionAlgorithm = "AES",
                EncryptionAlgorithmProvider = null,

                // Specified in bits
                EncryptionAlgorithmKeySize = 256,

                // Passed to BCryptOpenAlgorithmProvider
                HashAlgorithm = "SHA256",
                HashAlgorithmProvider = null
            });
        // </snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngCbc>
    }

    public static void AddDataProtectionUseCustomCryptographicAlgorithmsCngGcm(WebApplicationBuilder builder)
    {
        // <snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngGcm>
        builder.Services.AddDataProtection()
            .UseCustomCryptographicAlgorithms(new CngGcmAuthenticatedEncryptorConfiguration
            {
                // Passed to BCryptOpenAlgorithmProvider
                EncryptionAlgorithm = "AES",
                EncryptionAlgorithmProvider = null,

                // Specified in bits
                EncryptionAlgorithmKeySize = 256
            });
        // </snippet_AddDataProtectionUseCustomCryptographicAlgorithmsCngGcm>
    }
#pragma warning restore CA1416 // Validate platform compatibility
}
