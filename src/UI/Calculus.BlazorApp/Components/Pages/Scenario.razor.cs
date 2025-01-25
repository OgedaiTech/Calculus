using Calculus.BlazorApp.Clients.Scenario;
using Calculus.BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace Calculus.BlazorApp.Components.Pages;

public partial class Scenario : ComponentBase
{
  private List<ScenarioDto>? _scenarios;
  private readonly IScenarioClient _scenarioClient;

  public Scenario(IScenarioClient scenarioClient)
  {
    _scenarioClient = scenarioClient;
  }

  protected override async Task OnInitializedAsync()
  {
    _scenarios = await _scenarioClient.ListScenariosAsync();
  }
}
