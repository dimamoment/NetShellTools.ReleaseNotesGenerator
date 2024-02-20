using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Dto;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenAiServiceClient(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceConfig = configuration.GetSection(OpenAiServiceConfiguration.SectionName).Get<OpenAiServiceConfiguration>();
        
        ArgumentNullException.ThrowIfNull(serviceConfig?.ServiceUrl);

        services.AddScoped<IOpenAiServiceClient, OpenAiServiceClient>();
        services.AddHttpClient<IOpenAiServiceClient, OpenAiServiceClient>(client =>
        {
            client.BaseAddress = new Uri(serviceConfig.ServiceUrl);
        });
        
        return services;
    }
}
