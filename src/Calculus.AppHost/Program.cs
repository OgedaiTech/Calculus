using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Calculus_Web>("web");

await builder.Build().RunAsync();
