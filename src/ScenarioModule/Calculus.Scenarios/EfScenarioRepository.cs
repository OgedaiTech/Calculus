using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios;

public class EfScenarioRepository : IScenarioRepository
{
  private readonly ScenarioDbContext _context;
  public EfScenarioRepository(ScenarioDbContext context)
  {
    _context = context;
  }

  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }

  Task IScenarioRepository.AddAsync(Scenario scenario)
  {
    _context.Scenarios.Add(scenario);
    return Task.CompletedTask;
  }

  Task IScenarioRepository.DeleteAsync(Scenario scenario)
  {
    _context.Scenarios.Remove(scenario);
    return Task.CompletedTask;
  }

  async Task<Scenario?> IReadOnlyScenarioRepository.GetByIdAsync(Guid id)
  {
    return await _context.Scenarios.FindAsync(id);
  }

  Task<List<Scenario>> IReadOnlyScenarioRepository.ListAsync()
  {
    return _context.Scenarios.ToListAsync();
  }
}
