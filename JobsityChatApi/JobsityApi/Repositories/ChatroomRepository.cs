using JobsityApi.Data;
using JobsityApi.Models;
using JobsityApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobsityApi.Repositories;

public class ChatroomRepository : GenericRepository<Chatroom>, IChatroomRepository
{
    public ChatroomRepository(ApplicationDbContext context): base(context)
    {
    }
}
