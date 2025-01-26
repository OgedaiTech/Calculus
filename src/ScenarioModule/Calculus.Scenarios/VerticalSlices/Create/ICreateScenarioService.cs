namespace Calculus.Scenarios.VerticalSlices.Create;

internal interface ICreateScenarioService
{
  Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct);
  Task<ServiceResult<CreateScenarioResponse>> CreateScenarioAsync(string name, CancellationToken ct);
}
