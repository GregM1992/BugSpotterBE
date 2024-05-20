﻿using BugSpotterBE.Models;

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
                    var postsComments = db.Comments.Where(c => c.PostId == postId).ToList();
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

        }
    }
}
