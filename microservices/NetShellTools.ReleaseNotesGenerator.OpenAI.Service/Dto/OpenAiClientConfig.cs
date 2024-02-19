namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Dto;

public sealed record OpenAiClientConfig
{
    public const string SectionName = "OpenAiClientConfig";
    
    public string ApiKey { get; init; }
}
