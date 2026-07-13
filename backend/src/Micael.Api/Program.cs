using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Micael.Api.ErrorHandling;
using Micael.Infrastructure;
using Micael.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
    };
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = static async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        await JsonSerializer.SerializeAsync(
            context.Response.Body,
            new { status = report.Status.ToString() },
            cancellationToken: context.RequestAborted);
    }
});

app.MapGet("/api/v1/system/info", (IHostEnvironment environment) => Results.Ok(new
{
    name = "MICAEL",
    version = "0.2.0",
    environment = environment.EnvironmentName
}))
    .WithName("GetSystemInfo")
    .WithOpenApi();

if (app.Configuration.GetValue<bool>("Database:ApplyMigrations"))
{
    await using var scope = app.Services.CreateAsyncScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MicaelDbContext>();
    await dbContext.Database.MigrateAsync();
}

await app.RunAsync();

public partial class Program;
