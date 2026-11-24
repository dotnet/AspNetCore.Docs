/*
#!/usr/bin/env -S dotnet --
#:sdk Microsoft.NET.Sdk.Web
#:property PublishAot=false
#:property TargetFramework=net6.0
#:package Microsoft.AspNetCore.Authentication.Certificate@6.0.23
*/

using System.Security.Cryptography.X509Certificates;

//public static class Program
//{
    //public static void Main() {}

    #region snippet_SampleCertificateValidationService
    public class SampleCertificateValidationService : ICertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            // Don't hardcode passwords in production code.
            // Use a certificate thumbprint or Azure Key Vault.
            var expectedCertificate = new X509Certificate2(
                Path.Combine("/path/to/pfx"), "1234");

            return clientCertificate.Thumbprint == expectedCertificate.Thumbprint;
        }
    }
    #endregion

    public interface ICertificateValidationService
    {
        bool ValidateCertificate(X509Certificate2 clientCertificate);
    }
//}
