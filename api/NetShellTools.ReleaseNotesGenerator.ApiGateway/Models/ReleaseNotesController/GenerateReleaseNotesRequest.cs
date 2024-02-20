using System.ComponentModel.DataAnnotations;

namespace NetShellTools.ReleaseNotesGenerator.ApiGateway.Models.ReleaseNotesController;

public record GenerateReleaseNotesRequest
{
    [Required]
    public string Organization { get; init; }
    
    [Required]
    public string ApiVersion { get; init; }
    
    [Required]
    [Length(minimumLength: 1, maximumLength: 200)]
    public List<string> Ids { get; init; }
    
    public string ReleaseName { get; set; }
}
