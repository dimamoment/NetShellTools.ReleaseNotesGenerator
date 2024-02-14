using Microsoft.AspNetCore.Mvc;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Service;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Controllers;

[ApiController]
[Route("api/azure-devops")]
public sealed class AzureDevopsController : ControllerBase
{
    private readonly ILogger<AzureDevopsController> _logger;
    private readonly IAzureDevopsService _azureDevopsService;
    
    public AzureDevopsController(
        ILogger<AzureDevopsController> logger,
        IAzureDevopsService azureDevopsService)
    {
        _azureDevopsService = azureDevopsService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> GetWorkItems(CancellationToken cancellationToken)
    {
        _logger.LogInformation("AzureDevOps PTS: GetWorkItems endpoint PTS has been executed");
        
        
        
        _logger.LogInformation("AzureDevOps PTS: GetWorkItems endpoint PTS has been finished");
        return Ok();
    }
}
