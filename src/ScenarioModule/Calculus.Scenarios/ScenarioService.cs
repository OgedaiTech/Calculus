namespace Calculus.Scenarios;

internal class ScenarioService : IScenarioService
{
  private readonly IScenarioRepository _scenarioRepository;

  public ScenarioService(IScenarioRepository scenarioRepository)
  {
    _scenarioRepository = scenarioRepository;
  }

  public async Task<List<ScenarioDto>> ListScenarios()
  {
    var scenarios = (await _scenarioRepository.ListAsync())
        .Select(scenario => new ScenarioDto(scenario.Id, scenario.Name, scenario.Author))
        .ToList();

    return scenarios;
  }
}
