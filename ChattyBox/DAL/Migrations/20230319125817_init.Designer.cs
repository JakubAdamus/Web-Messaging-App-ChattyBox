﻿// <auto-generated />
using System;
using DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DbChattyBox))]
    [Migration("20230319125817_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("MessageSequence");

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
                            Created = new DateTime(2023, 3, 19, 13, 58, 17, 569, DateTimeKind.Local).AddTicks(8159),
                            Name = "Chat1"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [MessageSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

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
                            Created = new DateTime(2023, 3, 19, 13, 58, 17, 569, DateTimeKind.Local).AddTicks(8087),
                            Email = "marcinq@gmail.com",
                            PasswordHash = new byte[] { 2, 214, 250, 227, 52, 148, 206, 86, 183, 189, 252, 114, 188, 87, 162, 108, 209, 246, 97, 252, 65, 156, 40, 91, 82, 156, 43, 95, 144, 101, 28, 76, 166, 185, 206, 63, 46, 240, 185, 178, 59, 126, 134, 207, 140, 153, 177, 195, 43, 47, 111, 50, 64, 150, 104, 155, 87, 233, 245, 75, 1, 51, 100, 175 },
                            PasswordSalt = new byte[] { 202, 70, 138, 147, 90, 193, 239, 208, 93, 234, 58, 159, 215, 28, 104, 127, 10, 89, 202, 214, 131, 4, 68, 38, 142, 25, 148, 214, 178, 154, 21, 118, 136, 5, 83, 223, 73, 221, 185, 90, 189, 114, 164, 187, 217, 27, 250, 112, 196, 93, 72, 223, 68, 247, 8, 211, 48, 135, 165, 152, 94, 162, 254, 183, 221, 169, 0, 101, 133, 60, 36, 253, 151, 69, 214, 211, 6, 235, 75, 213, 238, 72, 109, 43, 51, 37, 42, 252, 228, 253, 135, 66, 252, 201, 83, 227, 61, 247, 231, 62, 251, 226, 188, 30, 68, 8, 137, 123, 193, 158, 120, 211, 166, 121, 23, 46, 207, 45, 147, 215, 214, 20, 133, 57, 216, 173, 153, 39 },
                            Username = "MarIwin"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 3, 19, 13, 58, 17, 569, DateTimeKind.Local).AddTicks(8119),
                            Email = "tymonq@gmail.com",
                            PasswordHash = new byte[] { 17, 25, 234, 81, 186, 92, 130, 217, 104, 68, 79, 71, 233, 209, 175, 225, 152, 103, 15, 21, 54, 48, 22, 169, 64, 73, 150, 81, 200, 206, 160, 105, 17, 103, 108, 44, 167, 30, 235, 226, 17, 186, 93, 139, 48, 160, 207, 52, 195, 8, 51, 162, 105, 172, 120, 52, 245, 4, 96, 185, 187, 3, 0, 73 },
                            PasswordSalt = new byte[] { 2, 63, 134, 183, 45, 113, 95, 47, 93, 122, 198, 206, 252, 165, 176, 25, 16, 229, 37, 65, 226, 118, 147, 157, 10, 115, 101, 29, 76, 179, 182, 236, 227, 252, 139, 46, 211, 219, 224, 248, 120, 165, 176, 151, 8, 208, 205, 165, 49, 104, 108, 12, 123, 248, 210, 206, 238, 75, 86, 20, 51, 100, 121, 101, 63, 216, 119, 201, 1, 8, 253, 117, 228, 42, 66, 49, 18, 223, 96, 201, 76, 60, 19, 192, 191, 96, 22, 109, 132, 15, 87, 206, 67, 126, 31, 210, 247, 245, 57, 170, 56, 235, 105, 24, 26, 131, 73, 9, 241, 100, 28, 237, 172, 178, 89, 10, 138, 75, 217, 231, 146, 182, 85, 209, 73, 232, 29, 61 },
                            Username = "TymonSme"
                        });
                });

            modelBuilder.Entity("DAL.Database.Entities.UserChat", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("UserChats");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ChatId = 1
                        },
                        new
                        {
                            UserId = 2,
                            ChatId = 1
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

                    b.ToTable("FileMessages", (string)null);
                });

            modelBuilder.Entity("DAL.Database.Entities.TextMessage", b =>
                {
                    b.HasBaseType("DAL.Database.Entities.Message");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.ToTable("TextMessages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChatId = 1,
                            SenderId = 1,
                            TimeStamp = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Content = "Hello1"
                        },
                        new
                        {
                            Id = 2,
                            ChatId = 1,
                            SenderId = 2,
                            TimeStamp = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.HasOne("DAL.Database.Entities.User", "User")
                        .WithMany("UserChats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Database.Entities.Chat", b =>
                {
                    b.Navigation("Messages");

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