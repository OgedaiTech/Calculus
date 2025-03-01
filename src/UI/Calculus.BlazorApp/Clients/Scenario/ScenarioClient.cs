using Calculus.BlazorApp.Models;
using Calculus.Common;

namespace Calculus.BlazorApp.Clients.Scenario;

public class ScenarioClient(HttpClient httpClient) : IScenarioClient
{
  public async Task<CreateScenarioResponse> CreateScenarioAsync(CreateScenarioDto createScenarioDto)
  {

    var response = await httpClient
      .PostAsJsonAsync($"https://{Constants.Urls.WebApiUrl}/scenarios", createScenarioDto);

    var result = await response.Content
      .ReadFromJsonAsync<CreateScenarioResponse>();
    return result!;
  }

  public async Task<List<ScenarioDto>?> ListScenariosAsync()
  {
    var response = await httpClient
      .GetFromJsonAsync<ListScenariosResponse>
      ($"https://{Constants.Urls.WebApiUrl}/scenarios");

    return response?.Scenarios;
  }
}
