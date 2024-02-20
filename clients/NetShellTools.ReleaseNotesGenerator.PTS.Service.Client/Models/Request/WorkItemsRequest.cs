namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;

public record WorkItemsRequest
{
    public string Organization { get; init; }
    
    public string ApiVersion { get; init; }

    public List<string> Ids { get; init; }
}
