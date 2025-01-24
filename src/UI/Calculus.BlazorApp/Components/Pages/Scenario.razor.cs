using Calculus.Common;

namespace Calculus.BlazorApp.Components.Pages;

public partial class Scenario
{
  private List<ScenarioDto>? _scenarios;

  override protected async Task OnInitializedAsync()
  {
    var response = await Http.GetFromJsonAsync<ListScenariosResponse>($"https://{Constants.Urls.WebApiUrl}/scenarios");
    _scenarios = response?.Scenarios;
  }
}

public record ScenarioDto(Guid Id, string Name, string Author);

public class ListScenariosResponse
{
  public List<ScenarioDto> Scenarios { get; set; } = default!;
}
