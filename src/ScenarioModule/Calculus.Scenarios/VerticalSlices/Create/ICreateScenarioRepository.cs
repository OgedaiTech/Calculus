namespace Calculus.Scenarios.VerticalSlices.Create;

internal interface ICreateScenarioRepository
{
  Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct);
  Task<CreateScenarioResponse> CreateScenarioAsync(string name, CancellationToken ct);
}
