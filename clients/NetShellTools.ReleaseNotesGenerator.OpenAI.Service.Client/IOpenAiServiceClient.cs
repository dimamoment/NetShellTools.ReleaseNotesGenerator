using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Request;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client;

public interface IOpenAiServiceClient
{
    Task<string> GenerateReleaseNotesAsync(GenerateReleaseNotesRequest generateReleaseNotesRequest);
}
