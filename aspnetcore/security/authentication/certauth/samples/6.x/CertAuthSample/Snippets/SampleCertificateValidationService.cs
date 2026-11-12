using System.Security.Cryptography.X509Certificates;

namespace CertAuthSample.Snippets;

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
