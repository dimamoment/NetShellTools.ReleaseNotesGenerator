using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Models.OpenAiController;
using OpenAI_API;

namespace NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Services.Internal;

internal sealed class OpenAiService : IOpenAiService
{
    private readonly ILogger<OpenAiService> _logger;
    private readonly IOpenAIAPI _openAiApi;
    
    public OpenAiService(ILogger<OpenAiService> logger, IOpenAIAPI openAiApi)
    {
        _logger = logger;
        _openAiApi = openAiApi;
    }

    public async Task<string> GenerateReleaseNotesAsync(GenerateReleaseNotesRequest request)
    {
        _logger.LogInformation("GenerateReleaseNotesAsync executed.");
        
        var chat = _openAiApi.Chat.CreateConversation();

        var systemPrompt = "You are a release engineer in a software company." +
                           "Your task is to create release notes based on the work item title and description." +
                           "You will be given a collection of objects that represent a work item." +
                           "An object has two fields: title and description." +
                           "Based on those values, you should create release notes. Please keep each note short, 1-line sentences.";

        if (!string.IsNullOrEmpty(request.ReleaseName))
        {
            systemPrompt = $" Also add a {request.ReleaseName} as a title/summary of release notes.";
        }

        chat.AppendSystemMessage(systemPrompt);
        request.WorkItems.ForEach(item =>
        {
            chat.AppendUserInput($"Title: {item.Title}; Description: {item.Description}");
        });
        
        _logger.LogInformation("GenerateReleaseNotesAsync finished.");
        
        return await chat.GetResponseFromChatbotAsync();
    }
}