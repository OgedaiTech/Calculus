namespace Calculus.Scenarios.VerticalSlices.Create;

internal interface ICreateScenarioService
{
  Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct);
  Task<CreateScenarioResponse> CreateScenarioAsync(string name, CancellationToken ct);
}
