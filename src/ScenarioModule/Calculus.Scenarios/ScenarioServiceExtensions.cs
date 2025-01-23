using Microsoft.Extensions.DependencyInjection;

namespace Calculus.Scenarios;

public static class ScenarioServiceExtensions
{
    public static void AddScenarioServices(this IServiceCollection services)
    {
        services.AddScoped<IListScenarioService, ListScenarioService>();
    }
}
