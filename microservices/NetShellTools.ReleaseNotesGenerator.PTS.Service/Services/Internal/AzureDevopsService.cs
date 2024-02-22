using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using NetShellTools.ReleaseNotesGenerator.Common.Helpers;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Dto;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Services.Internal;

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

    public async Task<WorkItemsResponse> GetWorkItemsAsync(WorkItemsRequest request)
    {
        _logger.LogInformation("Get-work-items for AzureDevOps PTS has been executed");
        
        var requestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri($"{_httpClient.BaseAddress}/_apis/wit/workitemsbatch?api-version={request.ApiVersion}"),
            Method = HttpMethod.Post,
        };
        
        var accessToken = await this.GetAuthTokenAsync();
        HttpRequestMessageHelper.AddApplicationJsonHttpContent(requestMessage, request);
        HttpRequestMessageHelper.AddBearerAuthorization(requestMessage, accessToken);
        
        var response = await _httpClient.SendAsync(requestMessage);
        
        // TODO: Move to shared class
        var responseContent = await response.Content.ReadAsStringAsync();
        var jsonObject = JObject.Parse(responseContent);
        var fieldsArray = new JArray(jsonObject["value"]?.Select(item => item["fields"]));
        var result = JsonConvert.DeserializeObject<List<WorkItem>>(fieldsArray.ToString());
        return new WorkItemsResponse { WorkItems = result };
    }
}