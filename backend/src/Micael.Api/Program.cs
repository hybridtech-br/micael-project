using System.Reflection;
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

static Task WriteHealthResponse(HttpContext context, Microsoft.Extensions.Diagnostics.HealthChecks.HealthReport report)
{
    context.Response.ContentType = "application/json";
    return JsonSerializer.SerializeAsync(
        context.Response.Body,
        new
        {
            status = report.Status.ToString(),
            timestampUtc = DateTimeOffset.UtcNow
        },
        cancellationToken: context.RequestAborted);
}

var healthOptions = new HealthCheckOptions
{
    ResponseWriter = WriteHealthResponse
};

app.MapHealthChecks("/health", healthOptions)
    .WithName("GetHealth")
    .WithOpenApi();

app.MapHealthChecks("/health/live", healthOptions)
    .WithName("GetLiveness")
    .WithOpenApi();

app.MapGet("/health/ready", async (MicaelDbContext dbContext, CancellationToken cancellationToken) =>
{
    var canConnect = await dbContext.Database.CanConnectAsync(cancellationToken);

    return canConnect
        ? Results.Ok(new { status = "Ready", timestampUtc = DateTimeOffset.UtcNow })
        : Results.Json(
            new { status = "NotReady", timestampUtc = DateTimeOffset.UtcNow },
            statusCode: StatusCodes.Status503ServiceUnavailable);
})
    .WithName("GetReadiness")
    .WithOpenApi();

app.MapGet("/api/v1/system/version", () =>
{
    var assembly = Assembly.GetExecutingAssembly();
    var informationalVersion = assembly
        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
        .InformationalVersion;

    return Results.Ok(new
    {
        name = "MICAEL",
        version = informationalVersion ?? assembly.GetName().Version?.ToString() ?? "unknown"
    });
})
    .WithName("GetSystemVersion")
    .WithOpenApi();

app.MapGet("/api/v1/system/info", (IHostEnvironment environment) => Results.Ok(new
{
    name = "MICAEL",
    product = "MICAEL Platform",
    version = "0.2.0",
    environment = environment.EnvironmentName,
    timestampUtc = DateTimeOffset.UtcNow
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
