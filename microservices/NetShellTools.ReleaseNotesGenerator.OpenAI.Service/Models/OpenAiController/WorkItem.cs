using System.ComponentModel.DataAnnotations;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;

public record WorkItem
{
    [Required]
    public string Title { get; init; }

    [Required]
    public string Description { get; init; }
}
