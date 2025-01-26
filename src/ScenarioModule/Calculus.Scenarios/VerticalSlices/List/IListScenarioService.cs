namespace Calculus.Scenarios;

internal interface IListScenarioService
{
  Task<List<ScenarioDto>> ListScenariosAsync();
}
