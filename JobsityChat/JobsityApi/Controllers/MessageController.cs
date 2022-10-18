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
    public IFinancialService FinancialService { get; set; }
    public MessageController(IMessageService service, IFinancialService financialService)
    {
        _service = service;
        FinancialService = financialService;
    }

    [Authorize]
    [HttpGet("{chatroomTitle}")]
    //ActionResult<List<MessageViewModel>>
    public async Task<IActionResult> Get(string chatroomTitle)
    {
        return Ok(await _service.GetByChatroomAsync(chatroomTitle));
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] NewMessageViewModel message)
    {
        if (message.Content.StartsWith('/'))
        {
            FinancialService.SendCommandAsync(message.Content, message.ChatroomTitle);
            return Accepted();
        }

        var user = User.Claims.SingleOrDefault(w => w.Type == ClaimTypes.Name)?.Value.ToUpper();

        if (user == null)
            throw new InvalidUserException();

        await _service.PostAsync(message, user);

        return StatusCode(201);
    }
}
