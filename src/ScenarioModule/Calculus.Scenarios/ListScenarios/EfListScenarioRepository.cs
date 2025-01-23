using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios;

public class EfListScenarioRepository : IListScenarioRepository
{
  private readonly ScenarioDbContext _context;
  public EfListScenarioRepository(ScenarioDbContext context)
  {
    _context = context;
  }

  public async Task SaveChangesAsync()
  {
    await _context.SaveChangesAsync();
  }

  Task IListScenarioRepository.AddAsync(Scenario scenario)
  {
    _context.Scenarios.Add(scenario);
    return Task.CompletedTask;
  }

  Task IListScenarioRepository.DeleteAsync(Scenario scenario)
  {
    _context.Scenarios.Remove(scenario);
    return Task.CompletedTask;
  }

  async Task<Scenario?> IReadOnlyListScenarioRepository.GetByIdAsync(Guid id)
  {
    return await _context.Scenarios.FindAsync(id);
  }

  Task<List<Scenario>> IReadOnlyListScenarioRepository.ListAsync()
  {
    return _context.Scenarios.ToListAsync();
  }
}
