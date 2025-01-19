using Microsoft.AspNetCore.Builder;

namespace Calculus.Scenarios;

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
