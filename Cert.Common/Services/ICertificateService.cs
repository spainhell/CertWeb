using Cert.Common.Models;

namespace Cert.Common.Services;

public interface ICertificateService
{
    Task<IEnumerable<Certificate>> GetAllCertificates();
    Task<Certificate> GenerateCertificate(CertificateRequest certificate);
    Task DeleteCertificate();
}