using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Common;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Request;

public record GenerateReleaseNotesRequest
{
    public string ReleaseName { get; set; }
    
    public List<WorkItem> WorkItems { get; set; }
}
