using Calculus.Common;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("Username", Constants.DbConsts.dbUsername);
var password = builder.AddParameter("password", Constants.DbConsts.dbPassword);

var postgresDbServer = builder
  .AddPostgres(name: "db", userName: userName, password: password, port: Constants.DbConsts.dbPort)
  .WithDataVolume()
  .WithPgAdmin();

var db = postgresDbServer.AddDatabase(Constants.DbConsts.dbName);

var webapi = builder
  .AddProject<Calculus_Web>(Constants.Urls.WebApiUrl)
  .WithReference(db);

builder
  .AddProject<Calculus_BlazorApp>("blazor")
  .WithReference(webapi);

await builder.Build().RunAsync();
