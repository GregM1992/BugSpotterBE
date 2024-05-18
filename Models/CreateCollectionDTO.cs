namespace BugSpotterBE.Models
{
    public class CreateCollectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool Favorite { get; set; }
    }
}
