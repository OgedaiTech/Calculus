namespace Calculus.Scenarios.GetById;

internal interface IGetScenarioByIdService
{
  Task<ScenarioDto?> GetScenarioByIdAsync(Guid scenarioId);
}
