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
                FirstName = "Jan",
                LastName = "Spanhel",
                CommonName = "Common Name",
                Issuer = "Let's Encrypt",
                IssueDate = DateTime.Parse("2024-01-01"),
                ExpireDate = DateTime.Parse("2024-12-31"),
                CertData = "Certificate Data 1",
            },
            new Certificate
            {
                Id = 2,
                FirstName = "Pavlina",
                LastName = "Spanhelova",
                CommonName = "Common Name",
                Issuer = "Let's Encrypt",
                IssueDate = DateTime.Parse("2024-01-02"),
                ExpireDate = DateTime.Parse("2025-01-01"),
                CertData = "Certificate Data 2",
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