using JobsityApi.Models;

namespace JobsityApi.Data.Seeds;

public class ChatroomSeed : Seed<Chatroom>
{
    public override IList<Chatroom> Get() => new List<Chatroom>() {
        new Chatroom("Financial Chat 1", "Financial"),
        new Chatroom("Financial Chat 2", "Financial"),
        new Chatroom("Financial Chat 3", "Financial"),
        new Chatroom("Just Chatting 1", "Random"),
        new Chatroom("Just Chatting 2", "Random"),
    };
}
