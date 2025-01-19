namespace Calculus.Scenarios;

internal interface IScenarioService
{
  Task<List<ScenarioDto>> ListScenarios();
}
