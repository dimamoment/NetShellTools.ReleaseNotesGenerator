namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Common;

public record WorkItem
{
    public string WorkItemType { get; set; }
    
    public string Title { get; init; }
    
    public string Description { get; init; }
}
