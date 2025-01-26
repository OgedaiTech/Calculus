using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios.VerticalSlices.Create;

public class CreateScenarioRepository : ICreateScenarioRepository
{
  private readonly ScenarioDbContext _dbContext;

  public CreateScenarioRepository(ScenarioDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<CreateScenarioResponse> CreateScenarioAsync(string name, CancellationToken ct)
  {
    var scenario = new Scenario(id: Guid.NewGuid(), name: name, author: "author", createdAt: DateTime.UtcNow, updatedAt: null, deletedAt: null);
    await _dbContext.Scenarios.AddAsync(scenario);

    await _dbContext.SaveChangesAsync(ct);

    return new CreateScenarioResponse { Id = scenario.Id };
  }

  public async Task<Scenario?> GetScenarioByNameAsync(string name, CancellationToken ct)
  {
    return await _dbContext.Scenarios.SingleOrDefaultAsync(s => s.Name == name, ct);
  }
}
