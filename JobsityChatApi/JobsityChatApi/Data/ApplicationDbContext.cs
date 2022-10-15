﻿using JobsityApi.Data.Seeds;
using JobsityApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobsityApi.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chatroom> Chatrooms { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Chatroom>().HasIndex(u => u.Title).IsUnique();

        #region seeds
        builder.Entity<Chatroom>().HasData(new ChatroomSeed().Get());
        #endregion
    }
}