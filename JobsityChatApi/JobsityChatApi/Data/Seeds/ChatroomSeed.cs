using JobsityChatApi.Models;

namespace JobsityChatApi.Data.Seeds;

public class ChatroomSeed : Seed<Chatroom>
{
    public override IList<Chatroom> Get() => new List<Chatroom>() {
        new Chatroom("Just Chatting 1"),
        new Chatroom("Just Chatting 2"),
        new Chatroom("Just Chatting 3"),
        new Chatroom("Just Chatting 4"),
        new Chatroom("Just Chatting 5"),
    };
}
