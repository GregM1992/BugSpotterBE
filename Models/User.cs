namespace BugSpotterBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Bio { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? EmailAddress { get; set; }
    }
}
