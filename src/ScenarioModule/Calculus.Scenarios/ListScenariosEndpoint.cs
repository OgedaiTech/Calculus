using FastEndpoints;

namespace Calculus.Scenarios;

internal class ListScenariosEndpoint : EndpointWithoutRequest<ListScenariosResponse>
{
  private readonly IScenarioService _scenarioService;

  public ListScenariosEndpoint(IScenarioService scenarioService)
  {
    _scenarioService = scenarioService;
  }

  public override void Configure()
  {
    Get("/scenarios");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var scenarios = _scenarioService.ListScenarios();

    await SendAsync(new ListScenariosResponse
    {
      Scenarios = scenarios.ToList()
    });
  }
}
