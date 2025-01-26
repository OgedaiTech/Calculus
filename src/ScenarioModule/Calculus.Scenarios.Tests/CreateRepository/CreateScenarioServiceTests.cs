using Calculus.Scenarios.VerticalSlices.Create;
using Moq;
using Xunit;

namespace Calculus.Scenarios.Tests.CreateRepository;

public class CreateScenarioServiceTests
{
  readonly ICreateScenarioRepository _repository;
  readonly CreateScenarioService _service;

  public CreateScenarioServiceTests()
  {
    _repository = Mock.Of<ICreateScenarioRepository>();
    _service = new CreateScenarioService(_repository);
  }

  [Fact]
  public async Task CreateScenarioAsync_WhenCalled_ShouldReturnScenarioAsync()
  {
    // Arrange
    var name = "Test Scenario";
    var id = Guid.NewGuid();
    Mock.Get(_repository)
      .Setup(repo => repo.CreateScenarioAsync(name, It.IsAny<CancellationToken>()))
      .ReturnsAsync(new CreateScenarioResponse { Id = id });

    // Act
    var result = await _service.CreateScenarioAsync(name, ct: CancellationToken.None);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(result);
      Assert.Equal(result.Data!.Id, id);
    });
  }

  [Fact]
  public async Task ReturnsExpectedMessageWhenNameIsMoreThan256CharactersAsync()
  {
    // Arrange
    var request = new CreateScenarioRequest(Name: new string('a', 257));
    var expectedMessage = "Name is too long";

    // Act
    var result = await _service.CreateScenarioAsync(request.Name, ct: CancellationToken.None);

    // Assert
    Assert.Multiple
    (() =>
    {
      Assert.NotNull(result);
      Assert.Equal(expectedMessage, result.Message);
    });
  }

  [Theory]
  [InlineData("")]
  [InlineData(" ")]
  [InlineData(null!)]
  public async Task ReturnsExpectedMessageWhenNameIsNullOrWhiteSpaceAsync(string? name)
  {
    // Arrange
    var expectedMessage = "Scenario Name is required";

    // Act
    var result = await _service.CreateScenarioAsync(name!, ct: CancellationToken.None);

    // Assert
    Assert.Multiple
    (() =>
    {
      Assert.NotNull(result);
      Assert.Equal(expectedMessage, result.Message);
    });
  }

  [Fact]
  public async Task CallsWithTrimmedNameAsync()
  {
    // Arrange
    var name = " Test Scenario ";
    var id = Guid.NewGuid();
    Mock.Get(_repository)
      .Setup(repo => repo.CreateScenarioAsync(name.Trim(), It.IsAny<CancellationToken>()))
      .ReturnsAsync(new CreateScenarioResponse { Id = id });

    // Act
    var result = await _service.CreateScenarioAsync(name, ct: CancellationToken.None);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(result);
      Assert.Equal(result.Data!.Id, id);
    });
  }
}
