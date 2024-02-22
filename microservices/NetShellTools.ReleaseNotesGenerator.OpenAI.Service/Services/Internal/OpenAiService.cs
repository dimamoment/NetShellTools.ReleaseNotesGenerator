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
                           "An object has two fields: title, description and type of the work item. (The description field is optional)" +
                           "Based on those values, you should create release notes. Please keep each note short, 1-line sentences " +
                           "and don't include work item type to generated result.";

        if (!string.IsNullOrEmpty(request.ReleaseName))
        {
            systemPrompt = $" Also add: '{request.ReleaseName}' as a title/summary of release notes.";
        }

        chat.AppendSystemMessage(systemPrompt);
        request.WorkItems.ForEach(item =>
        {
            var workItemDescription = !string.IsNullOrEmpty(item.Description) ? $"; Description: {item.Description}" : "";
            chat.AppendUserInput($"Title: {item.Title}{workItemDescription}; Work item type: {item.WorkItemType}");
        });
        
        _logger.LogInformation("GenerateReleaseNotesAsync finished.");
        
        return await chat.GetResponseFromChatbotAsync();
    }
}