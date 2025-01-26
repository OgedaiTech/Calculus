using Calculus.Scenarios.VerticalSlices.Create;
using Moq;
using Xunit;

namespace Calculus.Scenarios.Tests.CreateRepository;

public class GetScenarioByNameTests
{
  readonly ICreateScenarioRepository _repository;
  readonly CreateScenarioService _service;

  public GetScenarioByNameTests()
  {
    _repository = Mock.Of<ICreateScenarioRepository>();
    _service = new CreateScenarioService(_repository);
  }

  [Fact]
  public async Task CallsWithTrimmedNameAsync()
  {
    // Arrange
    var name = " Test Scenario ";
    var id = Guid.NewGuid();
    var author = "author";

    Mock.Get(_repository)
      .Setup(repo => repo.GetScenarioByNameAsync(name.Trim(), It.IsAny<CancellationToken>()))
      .ReturnsAsync(new Scenario(id, name.Trim(), author: author, createdAt: DateTime.Now, null, null));

    // Act
    var result = await _service.GetScenarioByNameAsync(name, ct: CancellationToken.None);

    // Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(result);
      Assert.Equal(result.Data!.Id, id);
      Assert.Equal(result.Data.Author, author);
    });
  }

  [Fact]
  public async Task ReturnsExpectedMessageWhenNameIsMoreThan256CharactersAsync()
  {
    // Arrange
    var name = new string('a', 257);
    var expectedMessage = "Name is too long";

    // Act
    var result = await _service.GetScenarioByNameAsync(name, ct: CancellationToken.None);

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
    var result = await _service.GetScenarioByNameAsync(name!, ct: CancellationToken.None);

    // Assert
    Assert.Multiple
    (() =>
    {
      Assert.NotNull(result);
      Assert.Equal(expectedMessage, result.Message);
    });
  }
}
