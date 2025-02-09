using Calculus.BlazorApp.Models;
using Calculus.Common;

namespace Calculus.BlazorApp.Clients.Scenario;

public class ScenarioClient : IScenarioClient
{
  private readonly IHttpClientFactory _httpClientFactory;

  public ScenarioClient(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory;
  }

  public async Task<CreateScenarioResponse> CreateScenarioAsync(CreateScenarioDto createScenarioDto)
  {
    var httpClient = _httpClientFactory.CreateClient();
    var response = await httpClient
      .PostAsJsonAsync($"https://{Constants.Urls.WebApiUrl}/scenarios", createScenarioDto);

    var result = await response.Content
      .ReadFromJsonAsync<CreateScenarioResponse>();
    return result!;
  }

  public async Task<List<ScenarioDto>?> ListScenariosAsync()
  {
    var httpClient = _httpClientFactory.CreateClient();
    var response = await httpClient
      .GetFromJsonAsync<ListScenariosResponse>
      ($"https://{Constants.Urls.WebApiUrl}/scenarios");

    return response?.Scenarios;
  }
}
