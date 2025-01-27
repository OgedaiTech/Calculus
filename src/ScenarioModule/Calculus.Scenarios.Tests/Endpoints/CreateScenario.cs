using Calculus.Scenarios.Tests.Endpoints.Abstractions;
using Calculus.Scenarios.VerticalSlices.Create;
using Xunit;
using System.Net.Http.Json;

namespace Calculus.Scenarios.Tests.Endpoints;

public class CreateScenario : BaseIntegrationTest
{
  public CreateScenario(IntegrationTestWebAppFactory factory)
    : base(factory)
  {

  }

  [Fact]
  public async Task Handle_ShouldCreateScenario_WhenParametersAreValidAsync()
  {
    // Arrange
    await ResetDatabaseAsync();
    var request = new CreateScenarioRequest(Name: "TestScenario");
    var content = JsonContent.Create(request);

    // Act
    var response = await Client.PostAsync("/scenarios", content);
    var createdScenario = await response.Content.ReadFromJsonAsync<CreateScenarioResponse>();

    // Assert
    response.EnsureSuccessStatusCode(); // Ensure the response status code is 2xx
    Assert.NotNull(createdScenario);
    Assert.True(createdScenario.Id != Guid.Empty); // Assuming Id is a Guid
  }

}
