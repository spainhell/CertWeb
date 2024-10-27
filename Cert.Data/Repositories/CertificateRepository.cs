using Cert.Common.Models;
using Cert.Common.Services;

namespace Cert.Data.Repositories;

public class CertificateRepository : ICertificateService
{
    private static readonly List<Certificate> Certificates =
    [
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
    ];
    
    public async Task<IEnumerable<Certificate>?> GetAllCertificates()
    {
        return Certificates;
    }

    public Task<Certificate?> GetCertificate(int id)
    {
        var certificate = Certificates.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(certificate);
    }

    public async Task<Certificate?> GenerateCertificate(CertificateRequest certificate)
    {
        var newCertificate = Cert.Common.Certificates.GenerateCertificate(certificate);
        Certificates.Add(newCertificate);
        return newCertificate;
    }

    public async Task<Task> DeleteCertificate(int id)
    {
        var certificate = Certificates.FirstOrDefault(c => c.Id == id);
        if (certificate != null)
        {
            Certificates.Remove(certificate);
        }
        return Task.CompletedTask;
    }
}