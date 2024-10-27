using Cert.Common.Models;
using Cert.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cert.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificateController : Controller
{
    private readonly ILogger<CertificateController> _logger;
    private readonly ICertificateService _certificateService;

    public CertificateController(ILogger<CertificateController> logger, ICertificateService certificateService)
    {
        _logger = logger;
        _certificateService = certificateService;
    }
    
    // GET: api/certificate
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
            var certificates = await _certificateService.GetAllCertificates();
            _logger?.LogInformation($"Method '{nameof(GetAllCertificates)}' successfully done.");
            return Ok(certificates);
        }
        catch (Exception ex)
        {
            _logger?.LogCritical($"Method '{nameof(GetAllCertificates)}' error: {ex.Message}.");
            throw;
        }
    }
    
    // GET: api/certificate/1
    /// <summary>
    /// Returns a certificate details
    /// </summary>
    /// <returns>A response with certificate details</returns>
    [HttpGet("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Certificate))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCertificate(int id)
    {
        _logger?.LogDebug($"Method '{nameof(GetCertificate)}' called.");
        try
        {
            var certificate = await _certificateService.GetCertificate(id);
            _logger?.LogInformation($"Method '{nameof(GetCertificate)}' successfully done.");
            return Ok(certificate);
        }
        catch (Exception ex)
        {
            _logger?.LogCritical($"Method '{nameof(GetCertificate)}' error: {ex.Message}.");
            throw;
        }
    }
    
    // POST: api/certificate
    /// <summary>
    /// Generates a new certificate
    /// </summary>
    /// <returns>A response with the certificate</returns>
    [HttpPost("")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Certificate>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GenerateCertificate(CertificateRequest request)
    {
        _logger?.LogDebug($"Method '{nameof(GenerateCertificate)}' called.");
        try
        {
            var certificate = await _certificateService.GenerateCertificate(request);
            _logger?.LogInformation($"Method '{nameof(GenerateCertificate)}' successfully done.");
            return Ok(certificate);
        }
        catch (Exception ex)
        {
            _logger?.LogCritical($"Method '{nameof(GenerateCertificate)}' error: {ex.Message}.");
            throw;
        }
    }
    
    // POST: api/certificate
    /// <summary>
    /// Generates a new certificate
    /// </summary>
    /// <returns>A response with the certificate</returns>
    [HttpPost("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCertificate(int id)
    {
        _logger?.LogDebug($"Method '{nameof(DeleteCertificate)}' called.");
        try
        {
            await _certificateService.DeleteCertificate(id);
            _logger?.LogInformation($"Method '{nameof(DeleteCertificate)}' successfully done.");
            return Ok(204);
        }
        catch (Exception ex)
        {
            _logger?.LogCritical($"Method '{nameof(DeleteCertificate)}' error: {ex.Message}.");
            throw;
        }
    }
    
}