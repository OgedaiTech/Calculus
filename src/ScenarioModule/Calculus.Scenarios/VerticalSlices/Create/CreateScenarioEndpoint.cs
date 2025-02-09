using System.Net;
using FastEndpoints;

namespace Calculus.Scenarios.VerticalSlices.Create;

internal class CreateScenarioEndpoint : Endpoint<CreateScenarioRequest, CreateScenarioResponse>
{
  private readonly ICreateScenarioService _service;

  public CreateScenarioEndpoint(ICreateScenarioService service)
  {
    _service = service;
  }

  public override void Configure()
  {
    Post("/scenarios");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateScenarioRequest req, CancellationToken ct)
  {
    var scenario = await _service.GetScenarioByNameAsync(req.Name, ct);
    if (scenario.Data is not null)
    {
      await SendAsync(new CreateScenarioResponse
      {
        Id = scenario.Data!.Id,
        Message = "There is a scenario already created with that name"
      },
        statusCode: (int)HttpStatusCode.Conflict, cancellation: ct);
      return;
    }

    var createdScenario = await _service.CreateScenarioAsync(req.Name, ct);

    await SendCreatedAtAsync<CreateScenarioEndpoint>(routeValues: new { id = createdScenario.Data!.Id }, responseBody: createdScenario.Data);
  }
}
