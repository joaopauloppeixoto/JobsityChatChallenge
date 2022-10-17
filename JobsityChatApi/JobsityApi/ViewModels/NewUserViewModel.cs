namespace JobsityApi.ViewModels;

public class NewUserViewModel : AuthViewModel
{
    public string UserName { get; set; }

	public NewUserViewModel()
	{

	}

	public NewUserViewModel(string userName, string email, string password) : base(email, password)
	{
		UserName = userName;
	}
}
