using Calculus.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;
using Xunit;

namespace Calculus.Scenarios.Tests.Endpoints.Abstractions;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
  private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
    .WithImage("postgres:latest")
    .WithDatabase("calculus")
    .WithUsername("postgres")
    .WithPassword("postgres")
    .Build();

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureTestServices(services =>
    {
      services.RemoveAll(typeof(DbContextOptions<ScenarioDbContext>));
      services.AddDbContextPool<ScenarioDbContext>(options =>
        options.UseNpgsql(_dbContainer.GetConnectionString()));

      // services.AddDbContext<ScenarioDbContext>(options =>
      //   options
      //     .UseNpgsql(_dbContainer.GetConnectionString())
      //     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
    });
  }
  public async Task InitializeAsync()
  {
    await _dbContainer.StartAsync();
  }

  async Task IAsyncLifetime.DisposeAsync()
  {
    await _dbContainer.StopAsync();
  }
}
