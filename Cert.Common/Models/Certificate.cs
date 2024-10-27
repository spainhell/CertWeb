using System.ComponentModel.DataAnnotations;

namespace Cert.Common.Models;

public class Certificate
{
    [Key] [Required] public int Id { get; set; } = 0;
    [Required] public string FirstName { get; set; } = "";
    [Required] public string LastName { get; set; } = "";
    [Required] public string CommonName { get; set; } = "";
    [Required] public string Issuer { get; set; } = "";
    [Required] public DateTime IssueDate { get; set; } = DateTime.Today;
    [Required] public DateTime ExpireDate { get; set; } = DateTime.Today.AddDays(365);
    [Required] public string CertData { get; set; } = "";
}