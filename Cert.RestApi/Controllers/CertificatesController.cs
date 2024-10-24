using Cert.Common.Models;
using Cert.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cert.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : Controller
{
    private readonly ILogger<CertificatesController> _logger;
    private readonly ICertificateService _certificateService;

    public CertificatesController(ILogger<CertificatesController> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    
    // GET: api/certificates
    /// <summary>
    /// Returns all certificates list
    /// </summary>
    /// <returns>A response with certificates list</returns>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Certificate>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCertificates()
    {
        _logger?.LogDebug($"Method '{nameof(GetAllCertificates)}' called.");
        try
        {
            //var certificates = await _certificateService.GetAllCertificates();
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
            _logger?.LogInformation($"Method '{nameof(GetAllCertificates)}' successfully done.");
            return Ok(certificates);
        }
        catch (Exception ex)
        {
            _logger?.LogCritical($"Method '{nameof(GetAllCertificates)}' error: {ex.Message}.");
            throw;
        }
    }
    
}