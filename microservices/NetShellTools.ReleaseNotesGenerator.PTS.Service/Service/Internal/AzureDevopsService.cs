using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Dto;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Service.Internal;

internal sealed class AzureDevopsService : IAzureDevopsService
{
    private readonly ILogger<AzureDevopsService> _logger;
    private readonly HttpClient _httpClient;
    private readonly AzureDevopsClientConfig _azureDevopsClientConfig;
    
    public AzureDevopsService(
        ILogger<AzureDevopsService> logger,
        HttpClient httpClient,
        IOptions<AzureDevopsClientConfig> azureDevopsClientConfigMetadata)
    {
        _logger = logger;
        _httpClient = httpClient;
        _azureDevopsClientConfig = azureDevopsClientConfigMetadata.Value;
    }

    public async Task<string> GetAuthTokenAsync()
    {
        _logger.LogInformation("Get-auth-token for AzureDevOps PTS has been executed");
        
        var clientAppAuthBuilder = ConfidentialClientApplicationBuilder.Create(_azureDevopsClientConfig.ClientId)
            .WithClientSecret(_azureDevopsClientConfig.Secret)
            .WithAuthority(new Uri(string.Concat(_azureDevopsClientConfig.AuthUrlBase, _azureDevopsClientConfig.TenantId)))
            .Build();
        
        var result = await clientAppAuthBuilder.AcquireTokenForClient(new[] { _azureDevopsClientConfig.Scope }).ExecuteAsync();
        
        _logger.LogInformation("Get-auth-token for AzureDevOps PTS has been finished");

        return result.AccessToken;
    }
}