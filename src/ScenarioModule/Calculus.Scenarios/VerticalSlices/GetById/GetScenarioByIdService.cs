namespace Calculus.Scenarios.GetById;

public class GetScenarioByIdService : IGetScenarioByIdService
{
  private readonly IGetScenarioByIdRepository _repository;
  public GetScenarioByIdService(IGetScenarioByIdRepository repository)
  {
    _repository = repository;
  }
  public Task<ScenarioDto?> GetScenarioByIdAsync(Guid scenarioId)
  {
    return _repository.GetScenarioByIdAsync(scenarioId);
  }
}
