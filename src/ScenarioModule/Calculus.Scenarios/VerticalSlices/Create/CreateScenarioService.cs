namespace Calculus.Scenarios.VerticalSlices.Create;

internal class CreateScenarioService : ICreateScenarioService
{
  private readonly ICreateScenarioRepository _repository;

  public CreateScenarioService(ICreateScenarioRepository repository)
  {
    _repository = repository;
  }
  public async Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct)
  {
    return await _repository.GetScenarioByNameAsync(name, ct);
  }

  public async Task<CreateScenarioResponse> CreateScenarioAsync(string name, CancellationToken ct)
  {
    return await _repository.CreateScenarioAsync(name, ct);
  }
}
