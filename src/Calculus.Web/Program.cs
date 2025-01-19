using Calculus.Scenarios;
using FastEndpoints;

namespace Calculus.Web;

public static class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.AddServiceDefaults();

    builder.Services.AddFastEndpoints();

    builder.AddNpgsqlDbContext<ScenarioDbContext>("calculus");
    // Add Scenario Services
    builder.Services.AddScenarioServices();
    builder.Services.AddScenarioRepository();

    builder.Services.AddAuthorization();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseFastEndpoints();

    app.UseAuthorization();

    app.Run();
  }
}
