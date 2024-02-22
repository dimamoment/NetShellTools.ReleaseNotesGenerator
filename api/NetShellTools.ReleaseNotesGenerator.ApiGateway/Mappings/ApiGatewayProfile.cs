using AutoMapper;
using NetShellTools.ReleaseNotesGenerator.ApiGateway.Models.ReleaseNotesController;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models.Request;
using PtsServiceClientModels = NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Models;
using OpenAiServiceClientModels = NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Models;

namespace NetShellTools.ReleaseNotesGenerator.ApiGateway.Mappings;

internal sealed class ApiGatewayProfile : Profile
{
    public ApiGatewayProfile()
    {
        CreateMap<GenerateReleaseNotesRequest, WorkItemsRequest>();
        CreateMap<PtsServiceClientModels.Common.WorkItem, OpenAiServiceClientModels.Common.WorkItem>();
    }
}
