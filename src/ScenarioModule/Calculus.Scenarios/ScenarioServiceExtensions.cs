using Calculus.Scenarios.GetById;
using Calculus.Scenarios.VerticalSlices.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Calculus.Scenarios;

public static class ScenarioServiceExtensions
{
  public static void AddScenarioServices(this IServiceCollection services)
  {
    services.AddScoped<IListScenarioService, ListScenarioService>();
    services.AddScoped<IGetScenarioByIdService, GetScenarioByIdService>();
    services.AddScoped<ICreateScenarioService, CreateScenarioService>();
  }
}
