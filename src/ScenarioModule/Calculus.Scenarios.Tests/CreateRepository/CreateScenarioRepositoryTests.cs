using Calculus.Scenarios.VerticalSlices.Create;
using Xunit;

namespace Calculus.Scenarios.Tests.CreateRepository;

public class CreateScenarioRepositoryTests
{
  readonly ScenarioDbContext _context;
  readonly CreateScenarioRepository _repository;

  public CreateScenarioRepositoryTests()
  {
    _context = ContextGenerator.Generate();
    _repository = new CreateScenarioRepository(_context);
  }

  [Fact]
  public async Task CreateRepository_WithValidContext_CreatesInstanceAsync()
  {
    // Arrange

    // Act
    var result = await _repository.CreateScenarioAsync("Test", ct: default);

    // Assert
    Assert.NotNull(result);
    var scenario = _context.Scenarios.First();
    Assert.Equal("Test", scenario.Name);
  }
}
