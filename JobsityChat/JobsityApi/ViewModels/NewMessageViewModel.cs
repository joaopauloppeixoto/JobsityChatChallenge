namespace JobsityApi.ViewModels;

public class NewMessageViewModel
{
    public string Content { get; set; }
    public string ChatroomTitle { get; set; }
    public NewMessageViewModel()
    {

    }

    public NewMessageViewModel(string content, string chatroomTitle)
    {
        Content = content;
        ChatroomTitle = chatroomTitle;
    }
}
