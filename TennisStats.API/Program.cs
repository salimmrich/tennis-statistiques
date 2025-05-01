using TennisStats.Application.Interfaces;
using TennisStats.Application.Services;
using TennisStats.Domain.Interfaces;
using TennisStats.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Ajouter HttpClient
builder.Services.AddHttpClient();

// Ajouter les services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
