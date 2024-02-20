using NetShellTools.ReleaseNotesGenerator.Common.Helpers;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Request;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client;

internal sealed class OpenAiServiceClient : IOpenAiServiceClient
{
    private readonly HttpClient _httpClient;
    
    public OpenAiServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateReleaseNotesAsync(GenerateReleaseNotesRequest generateReleaseNotesRequest)
    {
        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri($"{_httpClient.BaseAddress}api/open-ai/release-notes"),
        };
        HttpRequestMessageHelper.AddApplicationJsonHttpContent(requestMessage, generateReleaseNotesRequest);

        var response = await _httpClient.SendAsync(requestMessage);
        return await response.Content.ReadAsStringAsync();
    }
}
