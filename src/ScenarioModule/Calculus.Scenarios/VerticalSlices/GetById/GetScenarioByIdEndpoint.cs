using FastEndpoints;

namespace Calculus.Scenarios.GetById;

internal class GetScenarioByIdEndpoint : Endpoint<GetScenarioByIdRequest, ScenarioDto>
{
  private readonly IGetScenarioByIdService _service;

  public GetScenarioByIdEndpoint(IGetScenarioByIdService service)
  {
    _service = service;
  }

  public override void Configure()
  {
    Get("/scenarios/{ScenarioId}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetScenarioByIdRequest req, CancellationToken ct)
  {
    var scenario = await _service.GetScenarioByIdAsync(req.ScenarioId);
    if (scenario == null)
    {
      await SendNotFoundAsync();
      return;
    }

    await SendAsync(scenario!, cancellation: ct);
  }
}
