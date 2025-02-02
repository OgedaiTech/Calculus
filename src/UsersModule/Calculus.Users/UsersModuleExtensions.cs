using Calculus.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calculus.Users;

public static class UsersModuleExtensions
{
  public static void AddUsersModule(this IHostApplicationBuilder builder)
  {
    builder.AddNpgsqlDbContext<UsersDbContext>(Constants.DbConsts.dbName,
      configureDbContextOptions:
        opt =>
          opt.UseNpgsql(builder.Configuration.GetConnectionString(Constants.DbConsts.dbName)));

    builder.Services.AddIdentityCore<ApplicationUser>()
        .AddEntityFrameworkStores<UsersDbContext>();
  }
}
