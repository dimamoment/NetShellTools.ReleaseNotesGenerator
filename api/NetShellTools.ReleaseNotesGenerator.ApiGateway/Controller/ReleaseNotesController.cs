using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetShellTools.ReleaseNotesGenerator.ApiGateway.Models.ReleaseNotesController;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Common;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;

namespace NetShellTools.ReleaseNotesGenerator.ApiGateway.Controller;

[ApiController]
[Route("api/release-notes")]
public sealed class ReleaseNotesController : ControllerBase
{
    private readonly ILogger<ReleaseNotesController> _logger;
    private readonly IPtsServiceClient _ptsServiceClient;
    private readonly IOpenAiServiceClient _openAiServiceClient;
    private readonly IMapper _mapper;

    public ReleaseNotesController(
        ILogger<ReleaseNotesController> logger,
        IPtsServiceClient ptsServiceClient,
        IOpenAiServiceClient openAiServiceClient,
        IMapper mapper)
    {
        _logger = logger;
        _ptsServiceClient = ptsServiceClient;
        _openAiServiceClient = openAiServiceClient;
        _mapper = mapper;
    }

    [HttpPost("azure")]
    public async Task<IActionResult> GenerateReleaseNotes([FromBody] GenerateReleaseNotesRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GenerateReleaseNotes (azure devops) endpoint executed");

        var workItemsRequest = _mapper.Map<WorkItemsRequest>(request);
        var workItemsResponse = await _ptsServiceClient.GetWorkItemsAsync(workItemsRequest);

        var generateReleaseNotesRequest = new OpenAI.Service.Client.Models.Request.GenerateReleaseNotesRequest
        {
            ReleaseName = request.ReleaseName,
            WorkItems = _mapper.Map<List<WorkItem>>(workItemsResponse.WorkItems),
        };
        var releaseNotesResponse = await _openAiServiceClient.GenerateReleaseNotesAsync(generateReleaseNotesRequest);
        
        _logger.LogInformation("GenerateReleaseNotes (azure devops) endpoint finished");
        
        return Ok(releaseNotesResponse);
    }
}
