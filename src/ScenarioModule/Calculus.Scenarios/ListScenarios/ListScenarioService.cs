namespace Calculus.Scenarios;

internal class ListScenarioService : IListScenarioService
{
  private readonly IListScenarioRepository _scenarioRepository;

  public ListScenarioService(IListScenarioRepository scenarioRepository)
  {
    _scenarioRepository = scenarioRepository;
  }

  public async Task<List<ScenarioDto>> ListScenariosAsync()
  {
    var scenarios = (await _scenarioRepository.ListAsync())
        .Select(scenario => new ScenarioDto(scenario.Id, scenario.Name, scenario.Author))
        .ToList();

    return scenarios;
  }
}
