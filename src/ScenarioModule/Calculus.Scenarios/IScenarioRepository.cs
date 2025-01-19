namespace Calculus.Scenarios;

internal interface IScenarioRepository : IReadOnlyScenarioRepository
{
  Task AddAsync(Scenario scenario);
  Task DeleteAsync(Scenario scenario);
  Task SaveChangesAsync();
}
