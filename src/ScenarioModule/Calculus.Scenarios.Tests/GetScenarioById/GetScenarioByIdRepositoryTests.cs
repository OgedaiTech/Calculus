using Calculus.Scenarios.GetById;
using Xunit;

namespace Calculus.Scenarios.Tests.GetScenarioById;

public class GetScenarioByIdRepositoryTests
{
  readonly ScenarioDbContext _context;
  readonly GetScenarioByIdRepository _repository;

  public GetScenarioByIdRepositoryTests()
  {
    _context = ContextGenerator.Generate();
    _repository = new GetScenarioByIdRepository(_context);
  }

  [Fact]
  public async Task GetScenarioByIdRepository_WithValidContext_CreatesInstanceAsync()
  {
    // Arrange
    var scenario = new Scenario(Guid.NewGuid(), "Test", "Test", DateTime.UtcNow, null, null);
    _context.Scenarios.Add(scenario);
    await _context.SaveChangesAsync();

    // Act
    var result = await _repository.GetScenarioByIdAsync(scenario.Id);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(result);
      Assert.Equal(scenario.Id, result.Id);
      Assert.Equal(scenario.Name, result.Name);
    });
  }
}
