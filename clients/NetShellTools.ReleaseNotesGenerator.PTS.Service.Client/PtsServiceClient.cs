using NetShellTools.ReleaseNotesGenerator.Common.Helpers;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Response;
using Newtonsoft.Json;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client;

internal sealed class PtsServiceClient : IPtsServiceClient
{
    private readonly HttpClient _httpClient;

    public PtsServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WorkItemsResponse> GetWorkItemsAsync(WorkItemsRequest workItemsRequest)
    {
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_httpClient.BaseAddress}api/azure-devops/work-items"),
        };
        HttpRequestMessageHelper.AddApplicationJsonHttpContent(requestMessage, workItemsRequest);

        var response = await _httpClient.SendAsync(requestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<WorkItemsResponse>(responseContent);
    }
}
