using System.Text;
using Newtonsoft.Json;

namespace NetShellTools.ReleaseNotesGenerator.Common.Helpers;

public static class HttpRequestMessageHelper
{
    private const string ApplicationJsonMediaType = "application/json";
    private const string AuthorizationHeaderKey = "Authorization";
    private const string BearerTokenType = "Bearer";
    
    public static void AddApplicationJsonHttpContent(HttpRequestMessage httpRequestMessage, object content)
    {
        httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, ApplicationJsonMediaType);
    }
    
    public static void AddRequestHeaders(HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers)
    {
        if (headers != null && headers.Count > 0)
        {
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }
    }
    
    public static void AddRequestHeader(HttpRequestMessage httpRequestMessage, KeyValuePair<string, string> header)
    {
        httpRequestMessage.Headers.Add(header.Key, header.Value);
    }

    public static void AddBearerAuthorization(HttpRequestMessage httpRequestMessage, string accessToken)
    {
        httpRequestMessage.Headers.Add(AuthorizationHeaderKey, $"{BearerTokenType} {accessToken}");
    }
}
