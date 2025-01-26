using Calculus.Scenarios.VerticalSlices.Create;
using Xunit;

namespace Calculus.Scenarios.Tests.CreateRepository;

public class GetScenarioByNameRepositoryTests
{
  readonly ScenarioDbContext _context;
  readonly CreateScenarioRepository _repository;

  public GetScenarioByNameRepositoryTests()
  {
    _context = ContextGenerator.Generate();
    _repository = new CreateScenarioRepository(_context);
  }

  [Fact]
  public async Task ReturnsScenarioByGivenNameAsync()
  {
    // Arrange
    var id = Guid.NewGuid();
    const string Name = "Test Scenario";
    DateTime dateTime = DateTime.Now;

    _context.Scenarios
      .Add(new Scenario(id: id, name: Name, author: "", createdAt: dateTime, null, null));
    await _context.SaveChangesAsync();

    // Act
    var result = await _repository.GetScenarioByNameAsync(Name, CancellationToken.None);

    // Assert
    Assert.Equal(Name, result!.Name);
    Assert.Equal(dateTime, result!.CreatedAt);
  }
}
