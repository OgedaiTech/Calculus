namespace Calculus.Scenarios.GetById;

public interface IGetScenarioByIdRepository
{
  Task<ScenarioDto?> GetScenarioByIdAsync(Guid scenarioId);
}
