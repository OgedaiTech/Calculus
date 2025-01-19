using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgresDbServer = builder
  .AddPostgres("db")
  .WithDataVolume()
  .WithPgAdmin();

var db = postgresDbServer.AddDatabase("calculus");

var webapi = builder
  .AddProject<Calculus_Web>("web")
  .WithReference(db);

builder
  .AddProject<Calculus_BlazorApp>("blazor")
  .WithReference(webapi);

builder.Build().Run();
