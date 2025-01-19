namespace Calculus.Scenarios;

internal interface IReadOnlyScenarioRepository
{
  Task<List<Scenario>> ListAsync();
  Task<Scenario?> GetByIdAsync(Guid id);
}
