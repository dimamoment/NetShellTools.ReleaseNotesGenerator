using NetShellTools.ReleaseNotesGenerator.PTS.Service.Dto;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Services;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Services.Internal;

namespace NetShellTools.ReleaseNotesGenerator.PTS.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAzureDevopsService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureDevopsClientConfig>(configuration.GetSection(AzureDevopsClientConfig.SectionName));
        var adoConfig = configuration.GetSection(AzureDevopsClientConfig.SectionName).Get<AzureDevopsClientConfig>();
        
        ArgumentException.ThrowIfNullOrEmpty(adoConfig?.TenantId);
        ArgumentException.ThrowIfNullOrEmpty(adoConfig?.ClientId);
        ArgumentException.ThrowIfNullOrEmpty(adoConfig?.Secret);
        ArgumentException.ThrowIfNullOrEmpty(adoConfig?.Organization);
        
        services.AddScoped<IAzureDevopsService, AzureDevopsService>();
        services.AddHttpClient<IAzureDevopsService, AzureDevopsService>(client =>
        {
            var baseUri = $"{adoConfig.AzureDevopsUrlBase}{adoConfig.Organization}";
            client.BaseAddress = new Uri(baseUri);
        });
        
        return services;
    }
}
