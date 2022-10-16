using Microsoft.AspNetCore.Identity;

namespace JobsityApi.Models;

public class Message : IdentityModel
{
    public string Content { get; set; } = string.Empty;
    public IdentityUser Sender { get; set; } = new IdentityUser();
    public Chatroom SourceChatroom { get; set; } = new Chatroom("");
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
