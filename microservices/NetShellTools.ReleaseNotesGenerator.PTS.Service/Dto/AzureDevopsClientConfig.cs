namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Dto;

public sealed record AzureDevopsClientConfig
{
    public const string SectionName = "AzureDevopsClientConfig";
    
    public string ClientId { get; init; }
    
    public string TenantId { get; init; }
    
    public string Scope { get; init; }
    
    public string Secret { get; init; }
    
    public string Organization { get; init; }
    
    public string AuthUrlBase { get; init; }
    
    public string AzureDevopsUrlBase { get; init; }
}
