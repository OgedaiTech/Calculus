using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace Calculus.Users.UserEndpoints;

internal class Login : Endpoint<UserLoginRequest>
{
  private readonly UserManager<ApplicationUser> _userManager;

  public Login(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public override void Configure()
  {
    Post("/users/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UserLoginRequest req, CancellationToken ct)
  {
    var user = await _userManager.FindByEmailAsync(req.Email);
    if (user is null)
    {
      await SendUnauthorizedAsync();
      return;
    }

    var loginSuccessful = await _userManager.CheckPasswordAsync(user!, req.Password);

    if (!loginSuccessful)
    {
      await SendUnauthorizedAsync();
      return;
    }

    var jwtToken = Config["Auth:JwtSecret"]!;
    var token = JwtBearer.CreateToken(
      options =>
      {
        options.SigningKey = jwtToken;
        options.User["EmailAddress"] = user.Email!;
      });

    await SendOkAsync(new { Token = token }, ct);
  }
}
