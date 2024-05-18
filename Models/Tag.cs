namespace BugSpotterBE.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? TagType { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
