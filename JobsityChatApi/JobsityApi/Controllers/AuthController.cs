using AutoMapper;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.Utils.CustomExceptions;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Controllers;

[ApiController]
[Route("[controller]")]
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

}
