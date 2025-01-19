using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("Username", "postgres");
var password = builder.AddParameter("password", "G{hnBG_(.pQtJHN{-dB1d4");

var postgresDbServer = builder
  .AddPostgres(name: "db", userName: userName, password: password, port: 59330)
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
