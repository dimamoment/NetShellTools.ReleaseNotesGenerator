using NetShellTools.ReleaseNotesGenerator.PTS.Service.Dto;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Service;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Service.Internal;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAzureDevopsService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureDevopsClientConfig>(configuration.GetSection(AzureDevopsClientConfig.SectionName));
        var adoConfig = configuration.GetSection(AzureDevopsClientConfig.SectionName).Get<AzureDevopsClientConfig>();
        ArgumentNullException.ThrowIfNull(adoConfig?.TenantId);
        
        services.AddScoped<IAzureDevopsService, AzureDevopsService>();
        services.AddHttpClient<IAzureDevopsService, AzureDevopsService>(client =>
        {
            client.BaseAddress = new Uri(adoConfig.AzureDevopsUrlBase);
        });
        
        return services;
    }
}
