using System.ComponentModel.DataAnnotations;

namespace Cert.Common.Models;

public class CertificateRequest
{
    [Key] [Required] public int Id { get; set; } = 0;
    
    [Required] public CertificateType? Type { get; set; } = null;

    [Required] public string FirstName { get; set; } = "";
    
    [Required] public string LastName { get; set; } = "";
    
    [Required] public DateTime BirthDate { get; set; } = DateTime.Today;
}