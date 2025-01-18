using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var webapi = builder.AddProject<Calculus_Web>("web");

builder
  .AddProject<Calculus_BlazorApp>("blazor")
  .WithReference(webapi);

await builder.Build().RunAsync();
