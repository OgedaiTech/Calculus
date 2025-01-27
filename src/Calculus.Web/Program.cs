using Calculus.Common;
using Calculus.Scenarios;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Calculus.Web;

public partial class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.AddServiceDefaults();

    builder.Services.AddFastEndpoints();

    builder.AddNpgsqlDbContext<ScenarioDbContext>(Constants.DbConsts.dbName,
      configureDbContextOptions:
        opt =>
          opt.UseNpgsql(builder.Configuration.GetConnectionString(Constants.DbConsts.dbName)));

    // Add Scenario Services
    builder.Services.AddScenarioServices();
    builder.Services.AddScenarioRepository();

    builder.Services.AddAuthorization();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseFastEndpoints();

    app.UseAuthorization();

    app.Run();
  }
}

public partial class Program { }
