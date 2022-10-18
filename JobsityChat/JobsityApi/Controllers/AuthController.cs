using AutoMapper;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Services;
using JobsityApi.Utils.CustomExceptions;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public IAuthService AuthService { get; set; }
    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] NewUserViewModel userRegistration)
    {
        await AuthService.RegisterUserAsync(userRegistration);
        return StatusCode(201);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<ActionResult> Authenticate([FromBody] AuthViewModel model)
    {
        var user = await AuthService.AuthAsync(model);

        return Ok(user);
    }

}
