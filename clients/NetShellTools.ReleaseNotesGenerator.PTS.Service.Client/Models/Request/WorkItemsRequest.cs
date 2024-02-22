namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;

public record WorkItemsRequest
{
    public string ApiVersion { get; init; }

    public List<string> Ids { get; init; }
}
