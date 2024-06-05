using BugSpotterBE.Models;
using Microsoft.EntityFrameworkCore;

namespace BugSpotterBE.API
{
    public class SuggestionAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/suggestions/{postId}", (BugSpotterBEDbContext db, int postId) => // get all suggestions for single post by postId
            {
                try
                {
                var postsSuggestions = db.Suggestions.Include(c => c.User).Where(c => c.PostId == postId).Select(c => new
                {
                    c.Id,
                    c.UserId,
                    c.PostId,
                    c.SuggestionContent,
                    c.SuggestionId,
                    User = new
                    {
                        c.User.Id,
                        c.User.UserName,

                    }
                }).ToList();
                    return Results.Ok(postsSuggestions);
                }
                catch
                {
                    return Results.NotFound("This post has no suggestions yet");
                };
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
