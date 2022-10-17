using JobsityApi.Controllers;
using JobsityApi.Repositories.Interfaces;
using JobsityApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobsityApi.Tests;

public class AuthControllerTests
{
    const string EMAIL = "abc@abc.ab";
    const string PASSWORD = "abc123";
    const string NICKNAME = "abc";
    const string TOKEN = "token";

    [Fact]
    public async Task ShouldNotChangeValuesOnController()
    {
        var model = new AuthViewModel(EMAIL, PASSWORD);

        var serviceMock = new Mock<IAuthService>();
        serviceMock.Setup(r => r.AuthAsync(model))
            .ReturnsAsync(new UserViewModel(EMAIL, NICKNAME, TOKEN));
        var controller = new AuthController(serviceMock.Object);
        var result = (OkObjectResult)await controller.Authenticate(model);

        Assert.NotNull(result.Value);
        Assert.Equal(EMAIL, ((UserViewModel)result.Value).Email);
        Assert.Equal(TOKEN, ((UserViewModel)result.Value).Token);
        Assert.Equal(NICKNAME, ((UserViewModel)result.Value).Nickname);
    }

    [Fact]
    public async Task ShouldReturn201OnPost()
    {
        var model = new NewUserViewModel(NICKNAME, EMAIL, PASSWORD);

        var serviceMock = new Mock<IAuthService>();
        serviceMock.Setup(r => r.RegisterUserAsync(model))
            .ReturnsAsync(new UserViewModel(EMAIL, NICKNAME, TOKEN));
        var controller = new AuthController(serviceMock.Object);
        var result = (StatusCodeResult)await controller.RegisterUser(model);

        Assert.Equal(201, result.StatusCode);
    }
}