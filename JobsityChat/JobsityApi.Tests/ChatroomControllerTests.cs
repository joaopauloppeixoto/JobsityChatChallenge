using JobsityApi.Controllers;
using JobsityApi.Services.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Tests;

public class ChatroomControllerTests
{
    const string TITLE = "Title";
    const string TOPIC = "Topic";

    [Fact]
    public async Task ShouldNotChangeValuesOnController()
    {
        var serviceMock = new Mock<IChatroomService>();
        serviceMock.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<ChatroomViewModel>()
            {
                new ChatroomViewModel()
                {
                    Title=TITLE,
                    Topic=TOPIC,
                }
            });

        var controller = new ChatroomController(serviceMock.Object);
        var result = (OkObjectResult) await controller.Get();

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Value);
        Assert.Equal(1, ((List<ChatroomViewModel>)result.Value).Count);
        Assert.Equal(TITLE, ((List<ChatroomViewModel>)result.Value)[0].Title);
        Assert.Equal(TOPIC, ((List<ChatroomViewModel>)result.Value)[0].Topic);
    }
}