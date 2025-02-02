using FastEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Calculus.Users.UserEndpoints;

internal class Create : Endpoint<CreateUserRequest>
{
  private readonly UserManager<ApplicationUser> _userManager;

  public Create(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public override void Configure()
  {
    Post("/users");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
  {
    var newUser = new ApplicationUser()
    {
      Email = req.Email,
      UserName = req.Email
    };
    var passwordValidationResult = await _userManager.PasswordValidators[0].ValidateAsync(_userManager, newUser, req.Password);
    if (!passwordValidationResult.Succeeded)
    {
      await SendResultAsync(TypedResults.BadRequest(new
      {
        error = "InvalidPassword",
        message = "The password does not meet the requirements."
      }));
      return;
    }

    await _userManager.CreateAsync(newUser, req.Password);
    await SendOkAsync();
  }
}
