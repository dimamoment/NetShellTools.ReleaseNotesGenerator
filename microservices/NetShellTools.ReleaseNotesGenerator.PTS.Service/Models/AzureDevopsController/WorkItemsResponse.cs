namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;

public record WorkItemsResponse
{
    public List<WorkItem> WorkItems { get; init; }
}
