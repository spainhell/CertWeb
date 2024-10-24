using Cert.Common.Models;
using Cert.Common.Services;

namespace Cert.Data.Repositories;

public class CertificateRepository : ICertificateService
{
    public async Task<IEnumerable<Certificate>> GetAllCertificates()
    {
        var certificates = new List<Certificate>
        {
            new Certificate
            {
                Id = 1,
                CertData = "Certificate Data",
                ExpireDate = DateTime.Today,
                CommonName = "Common Name"
            }
        };
        return certificates;
    }

    public Task<Certificate> GenerateCertificate(CertificateRequest certificate)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCertificate()
    {
        throw new NotImplementedException();
    }
}