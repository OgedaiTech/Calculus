namespace Calculus.Scenarios;

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
