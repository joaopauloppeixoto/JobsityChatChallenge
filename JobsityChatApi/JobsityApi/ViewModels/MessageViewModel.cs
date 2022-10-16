namespace JobsityApi.ViewModels;

public class MessageViewModel
{
    public string Content { get; set; }
    public SenderViewModel Sender { get; set; }
    public DateTime CreatedOn { get; set; }
}
