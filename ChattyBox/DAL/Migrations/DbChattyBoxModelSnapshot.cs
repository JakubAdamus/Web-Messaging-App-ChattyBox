﻿// <auto-generated />
using System;
using DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DbChattyBox))]
    partial class DbChattyBoxModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Database.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Chats", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 4, 11, 18, 12, 3, 933, DateTimeKind.Local).AddTicks(4454),
                            Name = "Chat1"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DAL.Database.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastLog")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 4, 11, 18, 12, 3, 933, DateTimeKind.Local).AddTicks(4357),
                            Email = "marcinq@gmail.com",
                            PasswordHash = new byte[] { 68, 202, 108, 195, 142, 206, 122, 56, 18, 173, 186, 112, 140, 252, 56, 98, 59, 152, 217, 183, 100, 56, 251, 27, 167, 77, 145, 105, 74, 252, 143, 156, 97, 179, 158, 234, 152, 97, 124, 102, 70, 51, 117, 38, 184, 21, 45, 172, 38, 133, 175, 230, 116, 58, 41, 86, 115, 87, 74, 8, 173, 53, 53, 73 },
                            PasswordSalt = new byte[] { 119, 101, 214, 84, 83, 34, 214, 158, 119, 103, 107, 227, 67, 255, 160, 72, 99, 43, 19, 236, 12, 78, 111, 247, 98, 11, 30, 100, 237, 64, 181, 78, 35, 118, 60, 96, 45, 197, 38, 70, 239, 145, 34, 122, 246, 192, 108, 123, 195, 229, 6, 38, 53, 125, 20, 91, 86, 121, 162, 169, 129, 161, 114, 221, 95, 24, 232, 91, 228, 178, 99, 217, 140, 89, 195, 129, 82, 71, 149, 148, 211, 114, 151, 239, 13, 25, 37, 219, 21, 41, 229, 202, 113, 183, 171, 75, 31, 8, 205, 120, 206, 105, 222, 151, 125, 135, 61, 13, 53, 157, 95, 124, 254, 178, 156, 170, 100, 144, 109, 103, 77, 98, 85, 58, 1, 155, 42, 219 },
                            Username = "MarIwin"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 4, 11, 18, 12, 3, 933, DateTimeKind.Local).AddTicks(4398),
                            Email = "tymonq@gmail.com",
                            PasswordHash = new byte[] { 60, 197, 84, 228, 205, 187, 149, 181, 47, 82, 240, 123, 249, 182, 49, 53, 217, 247, 61, 179, 77, 188, 52, 237, 150, 2, 83, 81, 30, 243, 99, 85, 154, 24, 200, 75, 145, 75, 96, 126, 7, 173, 143, 249, 122, 81, 96, 129, 163, 110, 213, 197, 238, 96, 108, 233, 8, 54, 58, 189, 104, 130, 193, 150 },
                            PasswordSalt = new byte[] { 231, 123, 28, 196, 119, 161, 192, 214, 244, 93, 241, 173, 255, 190, 108, 233, 242, 38, 187, 52, 71, 19, 46, 171, 157, 182, 202, 44, 86, 98, 168, 60, 125, 100, 22, 53, 91, 155, 140, 33, 166, 239, 142, 87, 162, 250, 68, 75, 247, 112, 17, 97, 210, 94, 241, 188, 209, 185, 196, 80, 105, 27, 236, 169, 176, 40, 101, 94, 246, 134, 2, 193, 245, 233, 139, 59, 34, 164, 172, 238, 230, 176, 148, 25, 181, 42, 200, 193, 125, 165, 237, 251, 250, 71, 19, 212, 68, 180, 84, 246, 243, 114, 92, 176, 72, 162, 27, 246, 125, 10, 80, 248, 50, 253, 10, 41, 83, 244, 217, 7, 95, 52, 114, 120, 150, 201, 196, 183 },
                            Username = "TymonSme"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.UserChat", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserChats");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ChatId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            ChatId = 1,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.FileMessage", b =>
                {
                    b.HasBaseType("DAL.Database.Entities.Message");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.ToTable("FileMessage", null, t =>
                        {
                            t.Property("Id")
                                .HasAnnotation("SqlServer:IdentityIncrement", 2)
                                .HasAnnotation("SqlServer:IdentitySeed", 2L)
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                        });

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ChatId = 1,
                            SenderId = 1,
                            TimeStamp = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "File1.txt",
                            Path = "Path1",
                            Size = 0.0
                        },
                        new
                        {
                            Id = 4,
                            ChatId = 1,
                            SenderId = 2,
                            TimeStamp = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "File2.txt",
                            Path = "Path1",
                            Size = 0.0
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.TextMessage", b =>
                {
                    b.HasBaseType("DAL.Database.Entities.Message");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.ToTable("TextMessages", null, t =>
                        {
                            t.Property("Id")
                                .HasAnnotation("SqlServer:IdentityIncrement", 2)
                                .HasAnnotation("SqlServer:IdentitySeed", 1L)
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChatId = 1,
                            SenderId = 1,
                            TimeStamp = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Content = "Hello1"
                        },
                        new
                        {
                            Id = 3,
                            ChatId = 1,
                            SenderId = 2,
                            TimeStamp = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Content = "Hello2"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.Message", b =>
                {
                    b.HasOne("DAL.Database.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Database.Entities.User", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DAL.Database.Entities.UserChat", b =>
                {
                    b.HasOne("DAL.Database.Entities.Chat", "Chat")
                        .WithMany("UserChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Database.Entities.Role", "Role")
                        .WithMany("UserChats")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Database.Entities.User", "User")
                        .WithMany("UserChats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Database.Entities.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserChats");
                });

            modelBuilder.Entity("DAL.Database.Entities.Role", b =>
                {
                    b.Navigation("UserChats");
                });

            modelBuilder.Entity("DAL.Database.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserChats");
                });
#pragma warning restore 612, 618
        }
    }
}
