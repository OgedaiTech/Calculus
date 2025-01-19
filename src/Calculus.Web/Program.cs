using Calculus.Scenarios;

namespace Calculus.Web;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.AddServiceDefaults();

    // Add Scenario Services
    builder.Services.AddScenarioServices();

    builder.Services.AddAuthorization();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapScenarioEndpoints();

    app.Run();
  }
}
