using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using StepsLeaderboard.API.Middleware;
using StepsLeaderboard.Application.Features.Counters.Commands;
using StepsLeaderboard.Application.Interfaces;
using StepsLeaderboard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/stepsleaderboard.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCounterCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<CreateCounterCommand>();

builder.Services.AddSingleton<ICounterRepository, InMemoryCounterRepository>();
builder.Services.AddSingleton<ITeamRepository, InMemoryTeamRepository>();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();
