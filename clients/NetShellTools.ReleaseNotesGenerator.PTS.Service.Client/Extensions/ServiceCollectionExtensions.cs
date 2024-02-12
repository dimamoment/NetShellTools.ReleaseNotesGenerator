using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Dto;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPtsServiceClient(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceConfig = configuration.GetSection(PtsServiceConfiguration.SectionName).Get<PtsServiceConfiguration>();
        ArgumentNullException.ThrowIfNull(serviceConfig);

        services.AddScoped<IPtsServiceClient, PtsServiceClient>();
        services.AddHttpClient<IPtsServiceClient, PtsServiceClient>(client =>
        {
            client.BaseAddress = new Uri(serviceConfig.ServiceUrl);
        });
        
        return services;
    }
}
