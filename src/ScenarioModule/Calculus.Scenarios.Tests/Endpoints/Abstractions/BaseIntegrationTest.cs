using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Calculus.Scenarios.Tests.Endpoints.Abstractions;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
{
  private readonly IServiceScope _scope;
  protected ScenarioDbContext DbContext;
  protected HttpClient Client;
  private bool _disposed = false;

  protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
  {
    _scope = factory.Services.CreateScope();
    Client = factory.CreateClient();
    DbContext = _scope.ServiceProvider.GetRequiredService<ScenarioDbContext>();
  }

  protected async Task ResetDatabaseAsync()
  {
    await DbContext.Database.EnsureDeletedAsync();
    await DbContext.Database.MigrateAsync();
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!_disposed)
    {
      if (disposing)
      {
        // Dispose managed resources
        _scope.Dispose();
      }

      // Dispose unmanaged resources

      _disposed = true;
    }
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  ~BaseIntegrationTest()
  {
    Dispose(false);
  }
}
