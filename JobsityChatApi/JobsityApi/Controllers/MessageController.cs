using JobsityApi.Services;
using JobsityApi.Services.Interfaces;
using JobsityApi.Utils.CustomExceptions;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace JobsityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    public IMessageService _service { get; set; }
    public MessageController(IMessageService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("{chatroomTitle}")]
    public async Task<ActionResult<List<MessageViewModel>>> Get(string chatroomTitle)
    {
        return Ok(await _service.GetByChatroomAsync(chatroomTitle));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] NewMessageViewModel message)
    {
        var user = User.Claims.SingleOrDefault(w => w.Type == ClaimTypes.Name)?.Value.ToUpper();

        if (user == null)
            throw new InvalidUserException();

        await _service.PostAsync(message, user);

        return StatusCode(201);
    }
}
