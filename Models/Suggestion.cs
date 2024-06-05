namespace BugSpotterBE.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string? SuggestionContent { get; set; }
        public string? SuggestionId { get; set; }  
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
    }
}
