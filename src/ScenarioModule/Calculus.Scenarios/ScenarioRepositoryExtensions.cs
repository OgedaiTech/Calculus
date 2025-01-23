using System;
using Microsoft.Extensions.DependencyInjection;

namespace Calculus.Scenarios;

public static class ScenarioRepositoryExtensions
{
  public static void AddScenarioRepository(this IServiceCollection services)
  {
    services.AddScoped<IListScenarioRepository, EfListScenarioRepository>();
  }
}
