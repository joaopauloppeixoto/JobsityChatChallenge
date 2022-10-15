namespace JobsityChatApi.Models;

public class Chatroom : IdentityModel
{
    public string Title { get; set; } = string.Empty;

	public Chatroom(string title)
	{
		Id = Guid.NewGuid();
		Title = title;
	}
}
