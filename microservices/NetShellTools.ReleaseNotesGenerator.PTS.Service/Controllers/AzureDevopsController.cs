using Microsoft.AspNetCore.Mvc;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Controllers;

[ApiController]
[Route("api/azure-devops")]
public sealed class AzureDevopsController
{
    private readonly ILogger<AzureDevopsController> _logger;
    
    public AzureDevopsController(ILogger<AzureDevopsController> logger)
    {
        _logger = logger;
    }
}
