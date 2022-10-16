using JobsityApi.Services;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatroomController : ControllerBase
{
    public IChatroomService _service { get; set; }
    public ChatroomController(IChatroomService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<ChatroomViewModel>>> Get()
    {
        return Ok(await _service.GetAll());
    }
}
