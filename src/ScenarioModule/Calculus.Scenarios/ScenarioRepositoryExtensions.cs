using System;
using Calculus.Scenarios.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace Calculus.Scenarios;

public static class ScenarioRepositoryExtensions
{
  public static void AddScenarioRepository(this IServiceCollection services)
  {
    services.AddScoped<IListScenarioRepository, EfListScenarioRepository>();
    services.AddScoped<IGetScenarioByIdRepository, GetScenarioByIdRepository>();
  }
}
