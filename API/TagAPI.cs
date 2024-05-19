namespace BugSpotterBE.API
{
    public class TagAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/tags", (BugSpotterBEDbContext db) =>
            {
                return db.Tags.ToList();
            });

        }
    }
}
