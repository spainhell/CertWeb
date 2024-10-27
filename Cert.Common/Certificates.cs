using Cert.Common.Models;

namespace Cert.Common;

public class Certificates
{
    public static Certificate GenerateCertificate(CertificateRequest request)
    {
        return new Certificate
        {
            Id = 3,
            FirstName = request.FirstName,
            LastName = request.LastName,
            CommonName = request.LastName,
            Issuer = "Certificate Authority",
            IssueDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddYears(1),
            CertData = "Certificate Data 3",
        };
    }
}