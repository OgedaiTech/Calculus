using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios;

public class ScenarioDbContext : DbContext
{
  internal DbSet<Scenario> Scenarios { get; set; }

  public ScenarioDbContext(DbContextOptions options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("Scenario");
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
