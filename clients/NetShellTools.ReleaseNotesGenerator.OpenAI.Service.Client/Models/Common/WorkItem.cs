namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models.Common;

public class WorkItem
{
    public string WorkItemType { get; set; }
    
    public string Title { get; init; }
    
    public string Description { get; init; }
}
