﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BugSpotterBE.Migrations
{
    [DbContext(typeof(BugSpotterBEDbContext))]
    [Migration("20240515195836_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BugSpotterBE.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Favorite")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Favorite = true,
                            Name = "First Collection",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Favorite = true,
                            Name = "Bugs found on vacation",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Favorite = false,
                            Name = "Jumping Spiders",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Wow! This one is so cool!",
                            Likes = 3,
                            PostId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "NEAT!",
                            Likes = 2,
                            PostId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "EWWWWWWW",
                            Likes = 8,
                            PostId = 3,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Favorite")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("TagId")
                        .IsUnique();

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollectionId = 3,
                            Description = "Found this lil guy on the tree in my backyard!",
                            Favorite = true,
                            Image = "https://www.planetnatural.com/wp-content/uploads/2023/12/Jumping-Spider.jpg",
                            Latitude = 36.2562,
                            Longitude = -86.714399999999998,
                            TagId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CollectionId = 1,
                            Description = "Almost ran over this one!",
                            Favorite = false,
                            Image = "https://www.reconnectwithnature.org/getmedia/1d82fb8d-2743-463f-b5e4-f873f2583a7b/Praying-Mantis-Sugar-Creek-Preserve-Glenn_P_Knoblock-July-2022_9307.JPG?width=1500&height=1000&ext=.jpg",
                            Latitude = 36.015617800000001,
                            Longitude = -86.581939399999996,
                            TagId = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CollectionId = 3,
                            Description = "Such pretty colors!",
                            Favorite = true,
                            Image = "https://assets2.cbsnewsstatic.com/hub/i/r/2016/06/07/cecfc35f-944e-4d79-a270-59e988507ed5/thumbnail/640x483/620c2bcfde9748fd2f23578b09279947/rtsg6uy.jpg?v=1d6c78a71b7b6252b543a329b3a5744d",
                            Latitude = 36.177120000000002,
                            Longitude = -86.750510000000006,
                            TagId = 3,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.Suggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Agrees")
                        .HasColumnType("integer");

                    b.Property<int>("Disagrees")
                        .HasColumnType("integer");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<string>("SuggestionContent")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Suggestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Agrees = 9,
                            Disagrees = 4,
                            PostId = 1,
                            SuggestionContent = "Phiddipus Audax",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Agrees = 2,
                            Disagrees = 0,
                            PostId = 2,
                            SuggestionContent = "Praying Mantis",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TagType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TagType = "Looking for Identification"
                        },
                        new
                        {
                            Id = 2,
                            TagType = "Casual Observation"
                        },
                        new
                        {
                            Id = 3,
                            TagType = "Scientific Study"
                        },
                        new
                        {
                            Id = 4,
                            TagType = "Educational Purpose"
                        },
                        new
                        {
                            Id = 5,
                            TagType = "Curiosity"
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "I love jumping spiders!",
                            City = "Madison",
                            EmailAddress = "gGroks92@gmail.com",
                            State = "Tennessee",
                            Uid = "npm6sXBQ5nNCjt7upw1S7NRamLd2",
                            UserName = "oopsAllSpiders"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "this is a test user",
                            City = "Darujhistan",
                            EmailAddress = "testEmail@gmail.com",
                            State = "Seven Cities",
                            Uid = "",
                            UserName = "notAUser"
                        });
                });

            modelBuilder.Entity("BugSpotterBE.Models.Post", b =>
                {
                    b.HasOne("BugSpotterBE.Models.Collection", null)
                        .WithMany("Posts")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugSpotterBE.Models.Tag", "Tag")
                        .WithOne("Post")
                        .HasForeignKey("BugSpotterBE.Models.Post", "TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BugSpotterBE.Models.Collection", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BugSpotterBE.Models.Tag", b =>
                {
                    b.Navigation("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
