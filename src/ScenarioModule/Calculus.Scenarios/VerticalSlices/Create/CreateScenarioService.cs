namespace Calculus.Scenarios.VerticalSlices.Create;

public class CreateScenarioService : ICreateScenarioService
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

  public async Task<ServiceResult<CreateScenarioResponse>> CreateScenarioAsync(string name, CancellationToken ct)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      return new ServiceResult<CreateScenarioResponse>(message: "Scenario Name is required");
    }

    if (name.Length > 256)
    {
      return new ServiceResult<CreateScenarioResponse>(message: "Name is too long");
    }

    return new ServiceResult<CreateScenarioResponse>(data: await _repository.CreateScenarioAsync(name.Trim(), ct));
  }
}
