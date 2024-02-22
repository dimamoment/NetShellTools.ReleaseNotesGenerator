using System.ComponentModel.DataAnnotations;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;

public record WorkItem
{
    [Required]
    public string WorkItemType { get; set; }
    
    [Required]
    public string Title { get; init; }
    
    public string Description { get; init; }
}
