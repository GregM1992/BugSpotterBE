using BugSpotterBE.Models;
using Microsoft.EntityFrameworkCore;

namespace BugSpotterBE.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("comments/{postId}", (BugSpotterBEDbContext db, int postId) => //get single posts comments
            {
                try
                {
                    var postsComments = db.Comments.Include(c => c.User).Where(c => c.PostId == postId).Select(c => new
                    {
                        c.Id,
                        c.UserId,
                        c.PostId,
                        c.Content,
                        User = new
                        {
                            c.User.Id,
                            c.User.UserName,

                        }
                    }).ToList();
                
                return Results.Ok(postsComments);

                }
                catch
                {
                    return Results.NotFound("This post has no comments yet");
                };
            });

            app.MapPost("/comments", (BugSpotterBEDbContext db, Comment newComment) => //create comment
            {
                try
                {
                    db.Comments.Add(newComment);
                    db.SaveChanges();
                    return Results.Created($"/comments/{newComment.Id}", newComment);
                }
                catch
                {
                    return Results.BadRequest("There was an issue creating the comment, check your data");
                }
            });

            app.MapDelete("/comments/{commentId}", (BugSpotterBEDbContext db, int commentId) => // delete comment
            {
                var commentToDelete = db.Comments.FirstOrDefault(c => c.Id == commentId);
                if (commentToDelete != null)
                {
                    db.Comments.Remove(commentToDelete);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.BadRequest("This comment does not exist");
                }
            });

            app.MapPut("/comments/{commentId}", (BugSpotterBEDbContext db, int commentId, UpdateCommentDTO updatedComment) => //update comment
            {
                var commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == commentId);
                if (commentToUpdate != null)
                {
                    commentToUpdate.Content = updatedComment.Content;
                    db.SaveChanges();
                    return Results.Created($"/comments/{commentToUpdate.Id}", updatedComment);
                }
                else
                {
                    return Results.BadRequest("There was an issue updating this comment");
                }
                
            });

            app.MapGet("/comments/user/{userId}", (BugSpotterBEDbContext db, int userId) => // get users comments
            {
                var usersComments = db.Comments.Include(c => c.User).Where(c => c.UserId == userId).ToList();
                if (usersComments != null)
                {
                    return Results.Ok(usersComments);
                }
                else
                {
                    return Results.NotFound("This user has no comments");
                }
            });

        }
    }
}
