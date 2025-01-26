namespace Calculus.Scenarios.VerticalSlices.Create;

public interface ICreateScenarioRepository
{
  Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct);
  Task<CreateScenarioResponse> CreateScenarioAsync(string name, CancellationToken ct);
}
