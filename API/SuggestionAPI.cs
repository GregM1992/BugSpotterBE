using BugSpotterBE.Models;

namespace BugSpotterBE.API
{
    public class SuggestionAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/suggestions/{postId}", (BugSpotterBEDbContext db, int postId) => // get all suggestions for single post by postId
            {
                var postsSuggestions = db.Suggestions.Where(s => s.PostId == postId);
                if (postsSuggestions.Any())
                {
                    return Results.Ok(postsSuggestions);

                }
                else
                {
                    return Results.NotFound("There are no suggestions for this post yet");
                }
            });
            app.MapPost("/suggestions", (BugSpotterBEDbContext db, Suggestion newSuggestion) =>
            {
                try
                {
                db.Suggestions.Add(newSuggestion);
                db.SaveChanges();
                return Results.Created($"/suggestions/{newSuggestion.Id}", newSuggestion);
                }
                catch
                {
                    return Results.BadRequest("Something went wrong, check your data");
                }
            });
            app.MapPut("/suggestions/{suggestionId}", (BugSpotterBEDbContext db, int suggestionId, UpdateSuggestionDTO updatedSuggestion) =>
            {
                var suggestionToUpdate = db.Suggestions.FirstOrDefault(s => s.Id == suggestionId);
                if (suggestionToUpdate != null)
                {
                    suggestionToUpdate.SuggestionContent = updatedSuggestion.SuggestionContent;
                    db.SaveChanges();
                    return Results.Created($"/suggestions/{suggestionToUpdate.Id}", updatedSuggestion);
                }
                else
                {
                    return Results.BadRequest("Something went wrong, check your data");
                }
            });
            app.MapDelete("/suggestions/{suggestionId}", (BugSpotterBEDbContext db, int suggestionId) =>
            {
                var suggestionToDelete = db.Suggestions.FirstOrDefault(s => s.Id == suggestionId);
                if (suggestionToDelete != null)
                {
                    db.Suggestions.Remove(suggestionToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.BadRequest("This suggestion does not exist");
                }
            });
        }
    }
}
