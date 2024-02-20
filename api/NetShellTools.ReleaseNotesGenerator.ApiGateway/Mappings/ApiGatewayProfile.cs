using AutoMapper;
using NetShellTools.ReleaseNotesGenerator.ApiGateway.Models.ReleaseNotesController;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;

namespace NetShellTools.ReleaseNotesGenerator.ApiGateway.Mappings;

internal sealed class ApiGatewayProfile : Profile
{
    public ApiGatewayProfile()
    {
        CreateMap<GenerateReleaseNotesRequest, WorkItemsRequest>();
        CreateMap<PTS.Service.Client.Models.Common.WorkItem, OpenAI.Service.Client.Models.Common.WorkItem>();
    }
}
