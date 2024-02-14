using NetShellTools.ReleaseNotesGenerator.PTS.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAzureDevopsService(builder.Configuration);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();