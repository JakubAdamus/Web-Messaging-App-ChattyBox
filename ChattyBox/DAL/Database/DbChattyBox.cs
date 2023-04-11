﻿using DAL.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class DbChattyBox : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }
        public DbSet<FileMessage> FileMessages { get; set; }

        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbChattyBox(DbContextOptions<DbChattyBox> options) : base(options)
        {
           
        }

        private (byte[] passwordSalt, byte[] passwordHash) createPasswordHash(string password)
        {
            using var hmac = new HMACSHA512();
            return (hmac.Key, hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Chat>()
                .ToTable("Chats");

            modelBuilder.Entity<Chat>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<UserChat>()
                .HasKey(uc => new { uc.UserId, uc.ChatId });

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChats)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.Chat)
                .WithMany(c => c.UserChats)
                .HasForeignKey(uc => uc.ChatId);

            modelBuilder.Entity<UserChat>()
                .HasOne(uc => uc.Role)
                .WithMany(r => r.UserChats)
                .HasForeignKey(uc => uc.RoleId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Sender)
                .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat)
                .HasForeignKey(m => m.ChatId);


            modelBuilder.Entity<Message>()
                .UseTpcMappingStrategy();

            modelBuilder.Entity<FileMessage>()
                .ToTable("FileMessage", tb => tb.Property(e => e.Id)
                    .UseIdentityColumn(2, 2));

            modelBuilder.Entity<TextMessage>()
                .ToTable("TextMessages", tb => tb.Property(e => e.Id)
                    .UseIdentityColumn(1, 2));


            var user1 = createPasswordHash("123");
            var user2 = createPasswordHash("1234");

            List<UserChat> initUserChats = new List<UserChat>()
            {
                new UserChat { UserId = 1, ChatId = 1, RoleId = 1},
                new UserChat { UserId = 2, ChatId = 1, RoleId = 2}
            };

            modelBuilder.Entity<UserChat>().HasData(initUserChats.ToArray());

            List<Role> initRoles = new List<Role>()
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" }
            };

            modelBuilder.Entity<Role>().HasData(initRoles.ToArray());

            List<User> initUsers = new List<User>()
            {
                new User { Id=1, Email = "marcinq@gmail.com", Username="MarIwin", Created = DateTime.Now, PasswordHash = user1.passwordHash, PasswordSalt = user1.passwordSalt  },
              new User { Id = 2, Email = "tymonq@gmail.com", Username = "TymonSme", Created = DateTime.Now, PasswordHash = user2.passwordHash, PasswordSalt = user2.passwordSalt }
            };

            modelBuilder.Entity<User>().HasData(initUsers.ToArray());

            List<TextMessage> initTextMessages = new List<TextMessage>()
            {
                 new TextMessage {Id = 1,TimeStamp = new DateTime(2019, 1, 1), SenderId = 1, ChatId = 1, Content = "Hello1" },
                 new TextMessage { Id = 3, TimeStamp = new DateTime(2021, 1, 1), SenderId = 2, ChatId = 1, Content = "Hello2" }
            };

            modelBuilder.Entity<TextMessage>().HasData(initTextMessages.ToArray());

            List<FileMessage> initFileMessages = new List<FileMessage>()
            {
                new FileMessage {Id = 2,TimeStamp = new DateTime(2020, 1, 1), SenderId = 1, ChatId = 1, Name = "File1.txt",Path = "Path1"},
                new FileMessage { Id = 4, TimeStamp = new DateTime(2022, 1, 1), SenderId = 2, ChatId = 1, Name = "File2.txt", Path = "Path1"},
            };


            modelBuilder.Entity<FileMessage>().HasData(initFileMessages.ToArray());

            modelBuilder.Entity<Chat>().HasData(
                 new Chat { Created = DateTime.Now, Name = "Chat1", Id = 1 }
            );

        }

    }
}
