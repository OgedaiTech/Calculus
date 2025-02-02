using Calculus.Common;
using Calculus.Scenarios;
using Calculus.Users;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

namespace Calculus.Web;

public partial class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.AddServiceDefaults();

    builder.Services.AddFastEndpoints()
      .AddAuthenticationJwtBearer(
        options =>
        {
          options.SigningKey = builder.Configuration["Auth:JwtSecret"];
        })
      .AddAuthorization();

    builder.AddNpgsqlDbContext<ScenarioDbContext>(Constants.DbConsts.dbName,
      configureDbContextOptions:
        opt =>
          opt.UseNpgsql(builder.Configuration.GetConnectionString(Constants.DbConsts.dbName)));

    builder.AddUsersModule();

    // Add Scenario Services
    builder.Services.AddScenarioServices();
    builder.Services.AddScenarioRepository();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
      app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication()
      .UseAuthorization();
    app.UseFastEndpoints();



    app.Run();
  }
}

public partial class Program { }
