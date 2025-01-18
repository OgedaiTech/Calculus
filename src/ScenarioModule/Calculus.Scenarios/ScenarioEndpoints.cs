using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calculus.Scenarios;

internal interface IScenarioService
{
  IEnumerable<ScenarioDto> ListScenarios();
}

public record ScenarioDto(Guid Id, string Name, string Author);

public static class ScenarioEndpoints
{
  public static void MapScenarioEndpoints(this WebApplication app)
  {
    app.MapGet("/scenarios", (IScenarioService scenarioService) =>
    {
      return scenarioService.ListScenarios();
    });
  }
}

internal class ScenarioService : IScenarioService
{
  public IEnumerable<ScenarioDto> ListScenarios()
  {
    return
    [
      new ScenarioDto(Guid.NewGuid(), "Scenario 1", "Author 1"),
      new ScenarioDto(Guid.NewGuid(), "Scenario 2", "Author 2"),
      new ScenarioDto(Guid.NewGuid(), "Scenario 3", "Author 3"),
    ];
  }
}

public static class ScenarioServiceExtensions
{
  public static void AddScenarioServices(this IServiceCollection services)
  {
    services.AddScoped<IScenarioService, ScenarioService>();
  }
}
