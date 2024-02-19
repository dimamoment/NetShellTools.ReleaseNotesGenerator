using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddOpenAiService(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();