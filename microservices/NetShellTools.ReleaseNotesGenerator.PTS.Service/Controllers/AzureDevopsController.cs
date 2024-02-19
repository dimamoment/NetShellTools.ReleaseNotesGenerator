using Microsoft.AspNetCore.Mvc;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Services;

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

    [HttpPost("work-items")]
    public async Task<IActionResult> GetWorkItems([FromBody] WorkItemsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("AzureDevOps PTS: GetWorkItems endpoint executed");

        var result = await _azureDevopsService.GetWorkItemsAsync(request);
        
        _logger.LogInformation("AzureDevOps PTS: GetWorkItems endpoint finished");

        return Ok(result);
    }
}
