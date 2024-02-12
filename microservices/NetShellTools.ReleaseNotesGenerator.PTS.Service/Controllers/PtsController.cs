using Microsoft.AspNetCore.Mvc;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Controllers;

[ApiController]
[Route("api/pts")]
internal sealed class PtsController : ControllerBase
{
    private readonly ILogger<PtsController> _logger;
    
    public PtsController(ILogger<PtsController> logger)
    {
        _logger = logger;
    }
}
