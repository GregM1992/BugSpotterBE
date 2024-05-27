namespace BugSpotterBE.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }
        public bool Favorite { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public int numberOfPosts {
            get
            {
                return Posts?.Count ?? 0;
            }
        }

    }
}
