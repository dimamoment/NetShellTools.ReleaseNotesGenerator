using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Response;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client;

public interface IPtsServiceClient
{
    Task<WorkItemsResponse> GetWorkItemsAsync(WorkItemsRequest workItemsRequest);
}
