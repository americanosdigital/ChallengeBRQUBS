using ChallengeBRQUBS.Domain.Rules;
using ChallengeBRQUBS.Infrastructure.Repositories;
using ChallengeBRQUBS.Services.Categories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Register services
builder.Services.AddScoped<TradeCategoryService>();
builder.Services.AddSingleton<InMemoryTradeRepository>();
builder.Services.AddSingleton<ICategoryRule, LowRiskRule>();
builder.Services.AddSingleton<ICategoryRule, MediumRiskRule>();
builder.Services.AddSingleton<ICategoryRule, HighRiskRule>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
