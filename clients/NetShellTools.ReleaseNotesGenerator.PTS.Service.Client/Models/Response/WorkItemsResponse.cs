using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Common;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Response;

public record WorkItemsResponse
{
    public List<WorkItem> WorkItems { get; init; }
}
