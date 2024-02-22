using System.ComponentModel.DataAnnotations;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;

public record WorkItemsRequest
{
    [Required]
    public string ApiVersion { get; init; }
    
    [Required]
    [Length(minimumLength: 1, maximumLength: 200)]
    public List<string> Ids { get; init; }
}
