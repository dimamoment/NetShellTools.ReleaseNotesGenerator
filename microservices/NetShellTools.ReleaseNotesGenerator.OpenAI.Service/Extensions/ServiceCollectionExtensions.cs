using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Dto;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Services;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Services.Internal;
using OpenAI_API;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenAiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenAiClientConfig>(configuration.GetSection(OpenAiClientConfig.SectionName));
        var openAiConfig = configuration.GetSection(OpenAiClientConfig.SectionName).Get<OpenAiClientConfig>();
        
        ArgumentException.ThrowIfNullOrEmpty(openAiConfig?.ApiKey);

        services.AddScoped<IOpenAIAPI, OpenAIAPI>(provider => new OpenAIAPI(openAiConfig.ApiKey));
        services.AddScoped<IOpenAiService, OpenAiService>();

        return services;
    }
}
