using BugSpotterBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

public class BugSpotterBEDbContext : DbContext
{

    public DbSet<Collection> Collections { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }

    public BugSpotterBEDbContext(DbContextOptions<BugSpotterBEDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>().HasData(new Collection[]
        {
            new Collection { Id = 1, Name = "First Collection", UserId = 1, Favorite = true },
            new Collection { Id = 2, Name = "Bugs found on vacation", UserId = 2, Favorite = true }, 
            new Collection { Id = 3, Name = "Jumping Spiders", UserId = 3, Favorite = false}
        });
        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment { Id = 1, UserId = 1, PostId = 1, Content = "Wow! This one is so cool!" },
            new Comment { Id = 2, UserId = 2, PostId = 2, Content = "NEAT!"},
            new Comment { Id = 3, UserId = 2, PostId = 3, Content = "EWWWWWWW"}
        });
        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post { Id = 1, UserId = 1, CollectionId = 3, Image = "https://www.planetnatural.com/wp-content/uploads/2023/12/Jumping-Spider.jpg", Latitude = 36.2562, Longitude = -86.7144, Description = "Found this lil guy on the tree in my backyard!", Favorite = true },
            new Post { Id = 2, UserId = 2, CollectionId = 1, Image = "https://www.reconnectwithnature.org/getmedia/1d82fb8d-2743-463f-b5e4-f873f2583a7b/Praying-Mantis-Sugar-Creek-Preserve-Glenn_P_Knoblock-July-2022_9307.JPG?width=1500&height=1000&ext=.jpg", Latitude = 36.0156178, Longitude = -86.5819394, Description = "Almost ran over this one!", Favorite = false },
            new Post { Id = 3, UserId = 1, CollectionId = 3, Image = "https://assets2.cbsnewsstatic.com/hub/i/r/2016/06/07/cecfc35f-944e-4d79-a270-59e988507ed5/thumbnail/640x483/620c2bcfde9748fd2f23578b09279947/rtsg6uy.jpg?v=1d6c78a71b7b6252b543a329b3a5744d", Latitude = 36.17712, Longitude = -86.75051, Description = "Such pretty colors!", Favorite = true }
        });
        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
            new Tag { Id = 1, TagType = "Looking for Identification"},
            new Tag { Id = 2, TagType = "Casual Observation"},
            new Tag { Id = 3, TagType = "Scientific Study"},
            new Tag { Id = 4, TagType = "Educational Purpose"},
            new Tag { Id = 5, TagType = "Curiosity"}
        });
        modelBuilder.Entity<Suggestion>().HasData(new Suggestion[]
        {
            new Suggestion {Id = 1, SuggestionContent = "Phiddipus Audax", UserId = 2, PostId = 1},
            new Suggestion { Id = 2, SuggestionContent = "Praying Mantis", UserId = 1, PostId = 2 },   
        });
        modelBuilder.Entity<User>().HasData(new User[]
        {
            new User { Id = 1, Uid = "npm6sXBQ5nNCjt7upw1S7NRamLd2", UserName = "oopsAllSpiders", Bio = "I love jumping spiders!", City = "Madison", State = "Tennessee", EmailAddress = "gGroks92@gmail.com"},
            new User { Id = 2, Uid = "", UserName = "notAUser", Bio = "this is a test user", EmailAddress = "testEmail@gmail.com", City = "Darujhistan", State = "Seven Cities",}
        });
    }
}