namespace JobsityApi.Models;

public class Chatroom : IdentityModel
{
    public string Title { get; set; } = string.Empty;
	public string? Topic { get; set; } = string.Empty;

	public Chatroom(string title, string? topic = null)
	{
		Id = Guid.NewGuid();
		Title = title;
		Topic = topic;
	}
}
