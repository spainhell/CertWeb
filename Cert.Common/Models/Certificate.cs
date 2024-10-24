using System.ComponentModel.DataAnnotations;

namespace Cert.Common.Models;

public class Certificate
{
    [Key] [Required] public int Id { get; set; } = 0;

    [Required] public string CertData { get; set; } = "";

    [Required] public DateTime ExpireDate { get; set; } = DateTime.Today;

    [Required] public string CommonName { get; set; } = "";
}