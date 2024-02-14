using NetShellTools.ReleaseNotesGenerator.PTS.Service.Models.AzureDevopsController;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Service;

public interface IAzureDevopsService
{
    Task<string> GetAuthTokenAsync();
    
    Task<WorkItemsResponse> GetWorkItemsAsync(WorkItemsRequest request);
}