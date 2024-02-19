using Microsoft.AspNetCore.Mvc;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Services;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Controllers;

[ApiController]
[Route("api/open-ai")]
public sealed class OpenAiController : ControllerBase
{
    private readonly ILogger<OpenAiController> _logger;
    private readonly IOpenAiService _openAiService;
    
    public OpenAiController(ILogger<OpenAiController> logger, IOpenAiService openAiService)
    {
        _logger = logger;
        _openAiService = openAiService;
    }

    [HttpPost("release-notes")]
    public async Task<IActionResult> GenerateReleaseNotes([FromBody] GenerateReleaseNotesRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("OpenAI: GenerateReleaseNotes endpoint executed");

        var result = await _openAiService.GenerateReleaseNotesAsync(request);
        
        _logger.LogInformation("OpenAI: GenerateReleaseNotes endpoint finished");

        return Ok(result);
    }
}