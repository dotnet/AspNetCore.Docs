using System.Security.Cryptography.X509Certificates;

namespace CertAuthSample.Snippets;

public interface ICertificateValidationService
{
    bool ValidateCertificate(X509Certificate2 clientCertificate);
}
