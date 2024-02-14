namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Service;

public interface IAzureDevopsService
{
    Task<string> GetAuthTokenAsync();
}