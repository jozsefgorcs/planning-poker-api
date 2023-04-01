using Microsoft.AspNetCore.Mvc;
using PlanningPoker.Api.Contracts;
using PlanningPoker.Api.Models.Users;

namespace PlanningPoker.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthManager _authManager;

    public AccountController(IAuthManager authManager)
    {
        _authManager = authManager;
    }

    [HttpPost]
    public async Task<ActionResult> Register(ApiUserDto apiUserDto)
    {
        var errors = await _authManager.Register(apiUserDto);
        if (errors.Any())
        {
            foreach (var error in errors) ModelState.AddModelError(error.Code, error.Description);

            return BadRequest(ModelState);
        }

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var authResponse = await _authManager.Login(loginDto);
        if (authResponse == null) return Unauthorized();

        return Ok(authResponse);
    }

    [HttpPost]
    public async Task<ActionResult> RefreshToken(AuthResponseDto request)
    {
        var authResponse = await _authManager.VerifyRefreshToken(request);
        if (authResponse == null) return Unauthorized();

        return Ok(authResponse);
    }
}