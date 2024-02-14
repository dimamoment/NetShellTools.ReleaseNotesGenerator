using NetShellTools.ReleaseNotesGenerator.PTS.Service.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPtsServiceClient(builder.Configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();

app.Run();