using BugSpotterBE.Models;

namespace BugSpotterBE.API
{
    public class TagAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/tags", (BugSpotterBEDbContext db) =>
            {
                return db.Tags
                .Select(t => new {
                    t.Id,
                    t.TagType,
                }).ToList();
            });

            app.MapPut("/tags/{postId}/{tagId}", (BugSpotterBEDbContext db, int postId, int tagId) =>
            {
                var postToAddTo = db.Posts.FirstOrDefault(p => p.Id == postId);
                var tagToAdd = db.Tags.FirstOrDefault(p => p.Id == tagId);
                if (postToAddTo != null && tagToAdd != null)
                {
                    postToAddTo.Tags = new List<Tag>();
                    postToAddTo.Tags.Add(tagToAdd);
                    db.SaveChanges();
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest("There was an issue adding tag to post");
                }
            });

        }
    }
}
