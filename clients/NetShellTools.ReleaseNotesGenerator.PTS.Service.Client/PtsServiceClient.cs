using Microsoft.Extensions.Logging;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client;

internal class PtsServiceClient : IPtsServiceClient
{
    private readonly ILogger<PtsServiceClient> _logger;
    private readonly HttpClient _httpClient;
    
    public PtsServiceClient(ILogger<PtsServiceClient> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
}