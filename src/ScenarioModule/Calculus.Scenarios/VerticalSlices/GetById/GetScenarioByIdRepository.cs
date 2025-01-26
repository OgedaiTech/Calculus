using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios.GetById;

public class GetScenarioByIdRepository : IGetScenarioByIdRepository
{
  private readonly ScenarioDbContext _dbContext;

  public GetScenarioByIdRepository(ScenarioDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ScenarioDto?> GetScenarioByIdAsync(Guid scenarioId)
  {
    return await _dbContext.Scenarios
      .Where(s => s.Id == scenarioId)
      .Select(s => new ScenarioDto(s.Id, s.Name, s.Author))
      .SingleOrDefaultAsync();
  }
}
