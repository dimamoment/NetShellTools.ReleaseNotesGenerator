using Newtonsoft.Json;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;

public record WorkItem
{
    [JsonProperty("System.Title")]
    public string Title { get; init; }
    
    [JsonProperty("System.Description")]
    public string Description { get; init; }
}
