namespace JobsityApi.ViewModels;

public class UserViewModel
{
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string Token { get; set; }

    public UserViewModel()
    {

    }

    public UserViewModel(string email, string nickname, string token)
    {
        Email = email;
        Nickname = nickname;
        Token = token;
    }
}
