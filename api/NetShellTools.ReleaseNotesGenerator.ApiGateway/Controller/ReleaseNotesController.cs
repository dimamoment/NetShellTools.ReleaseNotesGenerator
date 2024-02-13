using Microsoft.AspNetCore.Mvc;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client;

namespace NetShellTools.ReleaseNotesGenerator.ApiGateway.Controller;

[ApiController]
[Route("api/release-notes")]
public sealed class ReleaseNotesController : ControllerBase
{
    private readonly ILogger<ReleaseNotesController> _logger;
    private readonly IPtsServiceClient _ptsServiceClient;
    
    public ReleaseNotesController(
        ILogger<ReleaseNotesController> logger,
        IPtsServiceClient ptsServiceClient)
    {
        _logger = logger;
        _ptsServiceClient = ptsServiceClient;
    }

    [HttpGet("azure")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok();
    }
}
