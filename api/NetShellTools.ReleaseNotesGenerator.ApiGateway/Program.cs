using NetShellTools.ReleaseNotesGenerator.ApiGateway.Mappings;
using NetShellTools.ReleaseNotesGenerator.OpenAI.Service.Client.Extensions;
using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ApiGatewayProfile));
builder.Services.AddPtsServiceClient(builder.Configuration);
builder.Services.AddOpenAiServiceClient(builder.Configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();

app.Run();