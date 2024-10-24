using Microsoft.AspNetCore.Mvc;

namespace Cert.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MyController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}