using JobsityApi.Controllers;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Tests;

public class MessageControllerTests
{
    const string USERNAME = "Bot";
    const string CHATROOM = "Financial 01";
    const string CONTENT = "Hello!";

    [Fact]
    public async Task ShouldNotChangeValuesOnController()
    {
        var serviceMock = new Mock<IMessageService>();
        serviceMock.Setup(r => r.GetByChatroomAsync(CHATROOM))
            .ReturnsAsync(new List<MessageViewModel>()
            {
                new MessageViewModel()
                {
                    Content=CONTENT,
                    CreatedOn = DateTime.Now,
                    Sender=It.IsAny<SenderViewModel>(),
                }
            });
        var botServiceMock = new Mock<IFinancialService>();
        botServiceMock.Setup(r => r.SendCommandAsync(CONTENT, CHATROOM));

        var controller = new MessageController(serviceMock.Object, botServiceMock.Object);
        var result = (OkObjectResult)await controller.Get(CHATROOM);

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.Equal(1, ((List<MessageViewModel>)result.Value).Count);
        Assert.Equal(CONTENT, ((List<MessageViewModel>)result.Value)[0].Content);
    }
}