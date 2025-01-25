using Calculus.BlazorApp.Models;
using Calculus.Common;
using Microsoft.AspNetCore.Components;

namespace Calculus.BlazorApp.Components.Pages;

public partial class Scenario : ComponentBase
{
  private List<ScenarioDto>? _scenarios;

  [Inject]
  public required IHttpClientFactory HttpClientFactory { get; set; }

  protected override async Task OnInitializedAsync()
  {
    var httpClient = HttpClientFactory.CreateClient();
    var response = await httpClient
      .GetFromJsonAsync<ListScenariosResponse>
      ($"https://{Constants.Urls.WebApiUrl}/scenarios");

    _scenarios = response?.Scenarios;
  }
}
