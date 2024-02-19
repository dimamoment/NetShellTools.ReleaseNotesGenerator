using System.ComponentModel.DataAnnotations;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;

public record GenerateReleaseNotesRequest
{
    public string ReleaseName { get; set; }
    
    [Required]
    [Length(minimumLength: 1, maximumLength: 200)]
    public List<WorkItem> WorkItems { get; set; }
}
