using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Services;

public interface IOpenAiService
{
    Task<string> GenerateReleaseNotesAsync(GenerateReleaseNotesRequest request);
}
