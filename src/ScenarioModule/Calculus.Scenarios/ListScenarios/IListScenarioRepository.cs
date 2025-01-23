namespace Calculus.Scenarios;

internal interface IListScenarioRepository : IReadOnlyListScenarioRepository
{
  Task AddAsync(Scenario scenario);
  Task DeleteAsync(Scenario scenario);
  Task SaveChangesAsync();
}
