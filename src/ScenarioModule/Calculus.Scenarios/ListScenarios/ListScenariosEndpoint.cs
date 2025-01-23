using FastEndpoints;

namespace Calculus.Scenarios;

internal class ListScenariosEndpoint : EndpointWithoutRequest<ListScenariosResponse>
{
  private readonly IListScenarioService _scenarioService;

  public ListScenariosEndpoint(IListScenarioService scenarioService)
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
    var scenarios = await _scenarioService.ListScenarios();

    await SendAsync(new ListScenariosResponse
    {
      Scenarios = scenarios
    }, cancellation: ct);
  }
}
