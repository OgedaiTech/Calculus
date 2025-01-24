namespace Calculus.Scenarios;

internal interface IReadOnlyListScenarioRepository
{
  Task<List<Scenario>> ListAsync();
  Task<Scenario?> GetByIdAsync(Guid id);
}
