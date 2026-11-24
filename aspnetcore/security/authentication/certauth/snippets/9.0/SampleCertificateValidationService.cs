#!/usr/bin/env -S dotnet --
#:sdk Microsoft.NET.Sdk.Web
#:property PublishAot=false
#:property TargetFramework=net9.0
#:package Microsoft.AspNetCore.Authentication.Certificate@9.0.23

using System.Security.Cryptography.X509Certificates;

public static class Program
{
    public static void Main() {}

    #region snippet_SampleCertificateValidationService
    public class SampleCertificateValidationService : ICertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            // Don't hardcode passwords in production code.
            // Use a certificate thumbprint or Azure Key Vault.
            var expectedCertificate = X509CertificateLoader.LoadPkcs12FromFile(
                Path.Combine("/path/to/pfx"), password: null);

            return clientCertificate.Thumbprint == expectedCertificate.Thumbprint;
        }
    }
    #endregion

    public interface ICertificateValidationService
    {
        bool ValidateCertificate(X509Certificate2 clientCertificate);
    }
}
