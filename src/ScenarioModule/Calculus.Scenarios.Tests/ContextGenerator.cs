using Microsoft.EntityFrameworkCore;

namespace Calculus.Scenarios.Tests;

public static class ContextGenerator
{
  public static ScenarioDbContext Generate()
  {
    var optionsBuilder = new DbContextOptionsBuilder<ScenarioDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid()
        .ToString());

    return new ScenarioDbContext(optionsBuilder.Options);
  }
}
