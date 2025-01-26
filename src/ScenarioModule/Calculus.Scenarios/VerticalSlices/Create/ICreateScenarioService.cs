namespace Calculus.Scenarios.VerticalSlices.Create;

internal interface ICreateScenarioService
{
  Task<ServiceResult<Scenario?>> GetScenarioByNameAsync(string name, CancellationToken ct);
  Task<ServiceResult<CreateScenarioResponse>> CreateScenarioAsync(string name, CancellationToken ct);
}
