using Calculus.BlazorApp.Models;

namespace Calculus.BlazorApp.Clients.Scenario;

public interface IScenarioClient
{
  Task<List<ScenarioDto>?> ListScenariosAsync();
}
